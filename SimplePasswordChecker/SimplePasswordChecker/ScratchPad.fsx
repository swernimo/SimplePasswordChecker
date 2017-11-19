open System.Security.Cryptography
open System.Text

let getPasswordHash (password:string) = 
    use sha512 = SHA512.Create()
    ASCIIEncoding.UTF8.GetBytes password |> sha512.ComputeHash |>Seq.fold (fun hash byte -> hash + byte.ToString("x2")) ""
    
    //let bytes = ASCIIEncoding.UTF8.GetBytes password
    //let hash = sha512.ComputeHash bytes
    //hash |> Seq.fold (fun str byte -> str + byte.ToString("x2")) ""

//let getPasswordHash (password: string) =
//    use sha512 = SHA512.Create()
//    let bytes = ASCIIEncoding.UTF8.GetBytes password
//    let hashAsBytes = sha512.ComputeHash bytes
//    let hash = hashAsBytes |> Seq.fold (fun str byte -> str + byte.ToString("x2")) ""
//    hash
    //let mutable hashString = ""
    //for b in hashAsBytes do
    //    hashString <- hashString + b.ToString("x2")
    //hashString

getPasswordHash "Abc123"
//getPasswordHashCSharp "Abc123"