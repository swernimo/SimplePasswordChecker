open System.Security.Cryptography
open System.Text

let getPasswordHash (password:string) = 
    use sha512 = SHA512.Create()
    ASCIIEncoding.UTF8.GetBytes password |> sha512.ComputeHash |>Seq.fold (fun str byte -> str + byte.ToString("x2")) ""
    
    //let bytes = ASCIIEncoding.UTF8.GetBytes password
    //let hash = sha512.ComputeHash bytes
    //hash |> Seq.fold (fun str byte -> str + byte.ToString("x2")) ""
    

getPasswordHash "Abc123"