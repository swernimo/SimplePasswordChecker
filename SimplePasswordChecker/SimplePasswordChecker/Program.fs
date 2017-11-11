// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Rules
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    validator rules "abc1234!" |> printfn "%A"
    0 // return an integer exit code
