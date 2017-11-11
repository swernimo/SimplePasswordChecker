module DataAccess

open FSharp.Data
open Users

[<Literal>]
let connectionString = @"some connection string"

let getPreviousPasswords user =
    use cmd = new SqlCommandProvider<"select ID, username, password from dbo.[User] where Username = @username", connectionString, ResultType.Tuples>(connectionString)
    let results = cmd.AsyncExecute(username = user) |> Async.RunSynchronously |> Seq.map (fun (id, name, pwd) -> {Id = id; Username = name; Password = pwd;})
    results