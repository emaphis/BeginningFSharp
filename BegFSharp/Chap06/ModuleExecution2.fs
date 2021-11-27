// Module Execution  - pg 134.

module ModuleExecutionTwo

// these two lines should be printed first 
printfn "This is the first line" 
printfn "This is the second"

// a functo to access ModuelExecutionOne
let funct() =
    printfn "%i" ModuleExecutionOne.n

//funct()
