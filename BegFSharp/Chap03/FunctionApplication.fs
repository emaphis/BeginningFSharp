// Function Application  pg 21

module FunctionApplication


// Function application simply means calling a function with some arguments .

let add x y = x + y

let result1 = add 4 5
let result2 = add 6 7

printfn "(add 4 5) = %i" result1
printfn "(add 6 7) = %i" result2

let result3 = add result1 result2

printfn "result3 = %i" result3

// pipe operator '|>'
// let (|>)  x f = f x chains function calls

let result4 = 0.5 |> System.Math.Cos

let result5 = add 6 7 |> add 4 |> add 5
