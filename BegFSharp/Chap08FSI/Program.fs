// Main App

open System
//open SystemXML
open Strangelights.LinqNamesByFunction


[<EntryPoint>]
let main args =
    printfn "Hello from F#"
    //printFruits()
    printFunctions()
    Console.ReadKey(false) |> ignore
    0
