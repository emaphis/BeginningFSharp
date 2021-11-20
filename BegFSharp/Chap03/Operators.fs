// Operators  pg. 29

module Operators


// using '+' to concatenate strings
let rhyme = "Jack " + "and " + "Jill"

printfn "%s" rhyme


// dates and timespans
open System

let oneYearLater = DateTime.Now + new TimeSpan(365, 0, 0, 0, 0)

printfn "%A" oneYearLater

// The operator is now a function, and its parameters will appear after the operator:
let result = (+) 3 4

let add = (+)

let result2 = add 3 4 

printfn "%i, %i" result result2

// characters you can used in operators  !%&*+-./<=>@^|~ 

// You can redefine operators .. use with care
let (+*)  a b = (a + b) * a * b

printfn "(1 +* 2) = %i" (1 +* 2)
