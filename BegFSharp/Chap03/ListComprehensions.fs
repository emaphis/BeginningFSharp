// List Comprehensions  pg. 42

module ListComprehensions

//The simplest comprehensions specify range

// create some list comprehensions 
let numericList = [ 0 .. 9 ]
let alpherSeq = seq { 'A' .. 'Z' }

// print them 
printfn "%A" numericList
printfn "%A" alpherSeq

// ranges with multiples
let multiplesOfThree = [ 0 .. 3 .. 30 ]
let revNumericSeq = [ 9 .. -1 .. 0 ]

// print them 
printfn "%A" multiplesOfThree
printfn "%A" revNumericSeq


// List comprehensions can be created from loops

// a sequence of squares
let squares =
    seq { for x in 1 .. 10 -> x * x }

// print the sequence
printfn "%A" squares


// The yield keyword allows you to decide whether or not
//  a particular item should be added to the collection.

// a sequence of even numbers
let evens n =
    seq { for x in 1 .. n do 
            if x % 2 = 0 then yield x }

// print the sequence
printfn "%A" (evens 10)


// It’s also possible to use list comprehensions to iterate in two
// or more dimensions b

// sequence of tuples representing points
let squarePoints n =
    seq { for x in 1 .. n do
            for y in 1 .. n do
                yield x, y}

// print the sequence
printfn "%A" (squarePoints 3)
