// Pattern Matching Against Lists  pg. 40

module PatternMatchingLists

// The regular way to work with F# lists is to use pattern matching and recursion.

// list to be concatenated 
let listOfList = [[2; 3; 5]; [7; 11; 13]; [17; 19; 23; 29]]

// defininition of a concatenation function
let rec concatList l =
    match l with
    | head :: tail -> head @ (concatList tail)
    | [] -> []

// call the function
let primes = concatList listOfList

// print the results 
printfn "%A" primes


// function that attempts to find various sequences
let rec findSequence l =
    match l with
    // match a lisst containing exactly 3 numbers
    | [x; y; z] -> 
        printfn "List 3 numbers in the list were %i %i %i" x y z
    // match a list of 1, 2, 3 in a row
    | 1 :: 2 :: 3 :: tail ->
        printfn "Found sequence 1, 2, 3 within the list"
        findSequence tail
    // if neither case matches and items remain
    // recursivley call the function
    | head :: tail -> findSequence tail
    | [] -> ()

// some test data 
let testSequence = [1; 2; 3; 4; 5; 6; 7; 8; 9; 8; 7; 6; 5; 4; 3; 2; 1]

// call the function
findSequence testSequence


// Higher order functions

let rec addOneAll list =
    match list with
    | head :: tail -> head + 1 :: addOneAll tail
    | [] -> []

printfn "(addOneAll [1; 2; 3]) = %A" (addOneAll [1; 2; 3])

let rec map func list =
    match list with
    | head :: tail -> func head :: map func tail
    | [] -> []

let result = map ((+) 1) [1; 2; 3]

printfn "result = %A" result
