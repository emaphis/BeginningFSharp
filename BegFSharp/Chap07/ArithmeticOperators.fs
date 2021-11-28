// Arithmetic Operators  - pg. 148

module ArithmeticOperators

// The FSharp.Core.Operators Module 

// Apply some basic arithmetic operators:
let x1 = 1 + 1
let x2 = 1 - 1

// Uchecked arithmetic
//open FSharp.Core.Operators.Checked
//let x = System.Int32.MaxValue + 1


//The structural equality operator is = , 

// Declare a person record type:
type person = { name : string ; favoriteColor : string }

// Create some record instance:
let robert1 = { name = "Robert" ; favoriteColor = "Red" }
let robert2 = { name = "Robert" ; favoriteColor = "Red" }
let robert3 = { name = "Robert" ; favoriteColor = "Green" }


// Demonstrate structural equality:
printfn "(robert = robert2): %b" (robert1 = robert2)
printfn "(robert <> robert2): %b" (robert1 <> robert2)


// Structural comparison is also used to implement the > and < operators, 

// Demonstrate structural comparison:
printfn "(robert2 > robert3): %b" (robert2 > robert3)


// two records, structs, or discriminated union instances are physically
// equal, you can use the PhysicalEquality

// Demonstrate physical equality:
printfn "(LanguagePrimitives.PhysicalEquality robert1 robert2): %b" 
    (LanguagePrimitives.PhysicalEquality robert1 robert2)
