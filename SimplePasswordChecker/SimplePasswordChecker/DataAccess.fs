module DataAccess

open FSharp.Data

[<Literal>]
let connectionString = @"Server=tcp:fsharp-sql.database.windows.net,1433;Initial Catalog=Users;Persist Security Info=False;User ID=swernimo;Password=xPh7de6g;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

let getPreviousPasswords user =
    use cmd = new SqlCommandProvider<"select Id, Username, Password from dbo.[User] where Username = @username", connectionString, ResultType.Records>(connectionString)
    let results = cmd.Execute(username = user)
    results