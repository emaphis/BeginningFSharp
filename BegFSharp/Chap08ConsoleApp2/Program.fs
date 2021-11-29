// Main App

open System
open SystemIOSequences

[<EntryPoint>]
let main args =
    wordCount()
    printfn "Done !!"
    Console.ReadKey(false) |> ignore
    0
