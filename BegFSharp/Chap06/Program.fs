// Main program

open SomeOtherModule

// signature files
open SignatureFiles
let useSignature() =
    //let funNum = Functions.notSoFunckyFunction 3
    Functions.funckyFunction "Charley"

[<EntryPoint>]
let main args =
    printfn "Hello from F#"
    printfn "%s" (testFun())
    printfn "%s" (useSignature())
    0