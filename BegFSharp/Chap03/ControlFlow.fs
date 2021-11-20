// Control Flow  pg 37

module ControlFlow

// if ... then ... else ...  construct

// Use 'if' to return a different value under
// different circumstances:
let result1 =
    if System.DateTime.Now.Second % 2 = 0 then
        "heads"
    else
        "tails"

printfn "%A" result1

// if ... then ... else ... expression is just a convenient shorthand 
// for pattern matching over a Boolean value.

// 'match' is often an alternative to 'if':
let result2 =
    match System.DateTime.Now.Second % 2 = 0 with
    | true -> "heads"
    | false -> "tails"

printfn "%A" result2


// if you require results of different types 'box' the results

let result3 =
    if System.DateTime.Now.Second % 2 = 0 then
        box "heads"
    else
        box false

printfn "%A" result3
