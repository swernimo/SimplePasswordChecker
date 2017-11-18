module Auth

open System.Security.Cryptography
open System.Text

let getPasswordHash (password:string) = 
    use sha512 = SHA512.Create()
    ASCIIEncoding.UTF8.GetBytes password |> sha512.ComputeHash |>Seq.fold (fun str byte -> str + byte.ToString("x2")) ""