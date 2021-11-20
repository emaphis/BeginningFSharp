// Recursion  pg. 28

module Recursion

// To use recursion use the rec keyword:

// a function to generate Fibonacci numbers
let rec fib x =
    match x with
    | 1 -> 1
    | 2 -> 1
    | x -> fib (x - 1) + fib (x - 2)


// call the function and print the results
printfn "(fib 2) = %i" (fib 2)
printfn "(fib 6) = %i" (fib 6)
printfn "(fib 11) = %i" (fib 11)
printfn "(fib 24) = %i" (fib 24)
