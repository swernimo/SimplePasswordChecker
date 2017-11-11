module DataAccess

open FSharp.Data

[<Literal>]
let connectionString = @"some connection string"

let getPreviousPasswords user =
    use cmd = new SqlCommandProvider<"select Id, Username, Password from dbo.[User] where Username = @username", connectionString, ResultType.Records>(connectionString)
    let results = cmd.Execute(username = user)
    results