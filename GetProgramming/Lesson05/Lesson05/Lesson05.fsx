// Lesson 5 - Trusting the compiler -pg 63

// Exampled 5.1
let name = "Ed Maphis"
name.ToLower()
let number = 123
//number.ToLower()



// 5.2 type-inference basics


/// Listing 5.5 Explicit type annotations in F#
let add (a: int, b: int) : int =
    let answer: int = a + b
    answer

printfn "%i"  (add (3, 7))


// Listing 5.8  Infered types arguements in F#  - pg 65

// Creating a generic list, but omitting the type arguement

open System.Collections.Generic
let numbers = List<_>()
numbers.Add(10)
numbers.Add(20)

// This is also legal
let otherNumbers = List()
otherNumbers.Add(10)
otherNumbers.Add(20)


// Listing 5.9 Automatic generalization of a function  - pg. 66
let createList(first, second) =
    let output = List()
    output.Add(first)
    output.Add(second)
    output

let otherNumbers2 = createList(10, 20)

printfn "%O" otherNumbers2



// 5.3 Following the breadcrumbs  - pg. 66

/// Listing 5.10 Complex type-inference example - pg 67
let sayHello(someValue) =
    let innerFucntion(number) =
        if number > 10 then  123
        elif number > 20 then 125
        else 130

    let resultOfInner =
        if someValue < 10 then innerFucntion(5)
        else innerFucntion(15)

    10 + resultOfInner


let result1 = sayHello(10)
let result2 = sayHello(9)


