// Main program

open SomeOtherModule

[<EntryPoint>]
let main args =
    printfn "Hello from F#"
    printfn "%s" (testFun())
    0