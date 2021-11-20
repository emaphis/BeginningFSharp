// Partial Application  pg. 32

module PartialApplication

// funtion that takes a tuple

let sub (a, b) = a - b

// Un-comment this line to see an error:
//let subFour = sub 4  // error

let sub1 a b  = a - b

let subFour = sub1 4

printfn "%i"  (subFour 3)
