module Rules

open System
open DataAccess

type Rule = string -> bool * string

(*
Create Rules for
    3) No password reuse
        a) query database for last 3 passwords
*)

let minLengthRule (pwd:string) =
    pwd.Length >= 8, "Password must be 8 characters long"

let requiredSymbols (pwd:string) =
    let containsUpper = pwd |> Seq.filter Char.IsLetter |> Seq.filter Char.IsUpper |> Seq.length > 0
    let containsLower = pwd |> Seq.filter Char.IsLetter |> Seq.filter Char.IsLower |> Seq.length > 0
    let containsNumber = pwd |> Seq.filter Char.IsDigit |> Seq.length > 0
    let containsSymbol = pwd |> Seq.filter Char.IsSymbol |> Seq.length > 0    
    containsLower && containsUpper && containsNumber && containsSymbol, "Password must contain 1 uppercase letter, 1 lowercase letter, 1 symbol and 1 number"

let preventSpaces (pwd:string) =
    let noSpaces = pwd.Trim() |> Seq.filter Char.IsWhiteSpace |> Seq.length = 0
    noSpaces, "Password cannot contain spaces"

let checkHistory (password:string) = 
    let previous = getPreviousPasswords "sean"
    let reused = previous |> Seq.filter (fun pwd -> pwd.Password = password) |> Seq.length = 0
    reused, "Cannot reuse previous passwords"

let rules : Rule list = [
    minLengthRule
    requiredSymbols
    preventSpaces
    checkHistory]

let validator (rules: Rule list) pwd =
    rules |> Seq.map (fun rule -> rule pwd) |> Seq.filter (fun (passed, _) -> passed = false) |> Seq.map (fun (_, error) -> error)