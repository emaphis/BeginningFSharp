// Achieving code reuse in F#
// Lesson 13 - pg. 149


////////////////////////////////////
// 13.2 Implementing higher-order functions in F#  - pg. 154

// 13.2.1 Basics of higher-order functions

// Listing 13.5 Your first higher-order function in F#

type Customer = { Age: int }

let where filter customers =
    seq {
        for customer in customers do
            if filter customer then
                yield customer }  // Calling the filter function 
                                  // with customer as an argument


let customers = [ { Age = 21 }; { Age = 35 }; { Age = 36 } ]

let isOver35 customer = customer.Age > 35

let old1 = customers |> where isOver35
printfn "%A" old1

let old2 = customers |> where (fun customer -> customer.Age > 35)
printfn "%A" old2


// 13.2.2 When to pass functions as arguments  - pg. 155


////////////////////////////////////////////////
// 13.3 Dependencies as functions  - pg. 156


// Now you try  - pgl 156
open System

let printCustomerAge0  customer =
    if customer.Age < 13 then
        Console.WriteLine "Child"
    elif customer.Age < 18 then
        Console.WriteLine "Teenager"
    else
        Console.WriteLine "Adult"

let customers2 = [ { Age = 8 }; { Age = 15 }; { Age = 36 } ]

for customer in customers2 do
    printCustomerAge0 customer


// order version

// Listing 13.6 Injecting dependencies into functions  - pg. 157


let printCustomerAge writer customer =
    if customer.Age < 13 then
        writer "Child"
    elif customer.Age < 18 then
        writer "Teenager"
    else
        writer "Adult"


for customer in customers2 do
    printCustomerAge Console.WriteLine customer


for customer in customers2 do
    printCustomerAge (printfn "%s") customer


// Listing 13.7 Partially applying a function with dependencies

printCustomerAge Console.WriteLine { Age = 21 }


let printToConsole = printCustomerAge Console.WriteLine


for customer in customers2 do
    printToConsole customer


// Listing 13.8 Creating a dependency to write to a file  - pg. 158

open System.IO

let path = @"C:\tmp\output.txt"

// Creating a File System writer that’s compatible with printCustomerAge
let writeToFile text = File.WriteAllText(path, text)

let printToFile = printCustomerAge writeToFile

printToFile { Age = 21 }

let text = File.ReadAllText(path)
printfn "%s" text

