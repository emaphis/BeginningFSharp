// Main App

open System
open SystemXML

[<EntryPoint>]
let main args =
    printfn "Hello from F#"
    printFruits()
    Console.ReadKey(false) |> ignore
    0
