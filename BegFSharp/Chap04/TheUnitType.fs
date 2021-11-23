// The Unit Type  pg. 65

module TheUnitType

// A function which both takes and returns 'unit':
let aFunction() =
    ()

// calling a unit function
let () = aFunction ()
do aFunction ()
aFunction()

// Calling several functions which return unit:
let poem() = 
    printfn "I wandered lonely as a cloud" 
    printfn "That floats on high o'er vales and hills," 
    printfn "When all at once I saw a crowd," 
    printfn "A host, of golden daffodils" 

poem()


// ignore function return value
let getShorty() = "shorty"

let _ = getShorty()
// -- or --
ignore(getShorty())
// --or ---
getShorty() |> ignore
