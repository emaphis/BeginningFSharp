// Pattern Matching  pg. 88

module DotNetPatternMatching

// list of objects
let simpleList = [ box 1; box 2.0; box "three" ]

// a function that pattern matches over the
// type of the object it is passed
let recognizeType (item : obj) =
    match item with
    | :? System.Int32  -> printfn "An integer"
    | :? System.Double -> printfn "A double" 
    | :? System.String -> printfn "A string" 
    | _ -> printfn "Unknown type"


// iterate over the list of objects
List.iter recognizeType simpleList


// list of objects 
let anotherList = [ box "one"; box 2; box 3.0 ]

// pattern match and print value
let recognizeAndPrintType (item : obj) =
    match item with
    | :? System.Int32 as x -> printfn "An integer: %i" x
    | :? System.Double as x -> printfn "A double %f" x
    | :? System.String as x -> printfn "A string: %s" x
    | x -> printfn "An object: %A" x 

// interate over the list pattern matching each item 
List.iter recognizeAndPrintType anotherList


// Oattern matching over exceptions
try
    // look at current time and raise an exception
    // based on whether the second is a multiple of 3
    if System.DateTime.Now.Second % 3 = 0 then
        raise (new System.Exception())
    else
        raise (new System.ApplicationException())
with
    | :? System.ApplicationException ->
        // this will handle "ApplicationException" case
        printfn "A second that was not a multiple of 3"
    | _ ->
        // this will handle all other exceptions
        printfn "A second that was a multiple of 3"
