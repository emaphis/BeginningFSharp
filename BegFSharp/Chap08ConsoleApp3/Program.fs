module Program

open System

open ListPersons
//open Alternate

[<EntryPoint>]
let main args =
    //listPersons()
    printRows()
    Console.ReadKey(false) |> ignore
    0


