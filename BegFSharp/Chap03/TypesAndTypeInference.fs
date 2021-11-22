// Types and Type Inference  pg 41

module TypesAndTypeInference

// infered types

let aString = "Spring time in Paris"
let anInt = 42

let makeMessage x = (Printf.sprintf "%i" x) + " days to spring time" 
let half x = x / 2 

// multiple parameters (curried) vs. tuples

let div1 x y = x / y
let div2 (x, y) = x / y

let divRemainder x y = x / y, x % y

// generic types - type parameterization
let doNothing x = x

// constrained types
let doNothingToAnInt (x: int) = x
let intList = [ 1; 2; 3 ]

let (stringList: list<string>) = [ "one"; "two"; "three" ]
