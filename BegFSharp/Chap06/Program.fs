// Main program

open SomeOtherModule
open ModuleTwo

// signature files
open SignatureFiles
let useSignature() =
    //let funNum = Functions.notSoFunckyFunction 3
    Functions.funckyFunction "Charley"

[<EntryPoint>]
let main args =
    do ModuleExecutionTwo.funct()
    printfn "Hello from F#"
    printfn "%s" (testFun())
    printfn "%s" (useSignature())
    printfn "%s" (testModuleTwo())
    0