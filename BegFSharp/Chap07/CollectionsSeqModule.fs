// The FSharp.Collections.Seq Module  - pg. 154

module CollectionsSeqModule


////////////////////////////////////
// The map and iter Functions

let myArray = [|1; 2; 3|]

// Take an array and double its elements,
// treating it as a sequence:
let myNewCollection =
    myArray
    |> Seq.map (fun x -> x * 2)

printfn "%A" myArray

// Iterate over the sequence, printing the elements:
myNewCollection |> Seq.iter (fun x -> printf "%i ... " x)


/////////////////////////////////
// The concat Function
// concat: #seq< #seq<'a> > -> seq<'a>

open System.Collections.Generic

let myList =
    let temp = new List<int[]>()
    temp.Add([| 1; 2; 3 |])
    temp.Add([| 4; 5; 6 |])
    temp.Add([| 7; 8; 9 |])
    temp

printfn "%A" myList

// Flatten a list of lists into a single sequence:
let myCompletList = Seq.concat myList

printf "%A" myCompletList

// Iterate over the sequence, printing the elements:
myCompletList |> Seq.iter (fun x -> printf "%i ... " x)


////////////////////////////////////////
// The fold Function
// e ('b -> 'a -> 'b) -> 'b -> #seq<'a> -> 'b

let myPhrase = [|"How"; "do"; "you"; "do?"|]

// Build a string from a sequence of strings
// using Seq.fold:
let myCompletePhrase =
    myPhrase
    |> Seq.fold (fun acc x -> acc + " " + x) ""

printfn "%s" myCompletePhrase


//////////////////////////////////////////
// The exist and forall Functions
// ('a -> bool) -> #seq<'a> -> bool

let intArray = [| 0; 1; 2; 3; 4; 5; 6; 7; 8; 9 |]

// Check a sequence for an integer which is a 
// multiple of two
let existsMultipleOfTwo =
    intArray
    |> Seq.exists (fun x -> x % 2 = 0)

// Check that a sequence consists entirely of
// integers which is a multiple of two:
let allMultipleOfTwo =
    intArray
    |> Seq.forall (fun x -> x % 2 = 0)


printfn "existsMultipleOfTwo: %b" existsMultipleOfTwo
printfn "allMultipleOfTwo: %b" allMultipleOfTwo



////////////////////////////////////////////////////
// The filter, find, and tryFind Functions
// filter: ('a -> bool) -> #seq<'a> -> seq<'a>
// find: ('a -> bool) -> #seq<'a> -> 'a
// tryFind: ('a -> bool) -> #seq<'a> -> 'a option

let shortWordList = [|"hat"; "hot"; "bat"; "lot"; "mat"; "dot"; "rat";|]


// Filter a list of words which ends with "at":
let atWords =
    shortWordList
    |> Seq.filter (fun x -> x.EndsWith("at"))

// Find the first word ending with "ot":
let otWord =
    shortWordList
    |> Seq.find (fun x -> x.EndsWith("ot"))

// Try to find the first word ending with "tt":
let ttWord =
    shortWordList
    |> Seq.tryFind (fun x -> x.EndsWith("tt"))


atWords |> Seq.iter (fun x -> printf "%s ... " x) 
printfn "" 
printfn "%s" otWord 
printfn "%s" (match ttWord with | Some x -> x | None -> "Not found") 


////////////////////////////////////////
// The choose Function 
// choose: ('a -> 'b option) -> #seq<'a> -> seq<'b>

let floatArray = [|0.5; 0.75; 1.0; 1.25; 1.5; 1.75; 2.0 |]

// Take a list of floating-point numbers and multiply them by 2. 
// If the value is an integer, it is returned. Otherwise, it is 
// filtered out.
let integers =
    floatArray |>
    Seq.choose
        (fun x ->
            let y = x * 2.0
            let z = floor y
            if y - z = 0.0 then
                Some (int z)
            else
                None)

integers |> Seq.iter (fun x -> printf "%i ... " x)


////////////////////////////////////
// The init and initInfinite Functions
// init: int -> (int -> 'a) -> seq<'a>
// initInfinite: (int -> 'a) -> seq<'a>

open System

// Create a sequence of ten 1s using Seq.init:
let tenOnes = Seq.init 10 (fun _ -> 1)
// Create a 'infinite' sequence of integers:
let allIntegers = Seq.initInfinite (fun x -> Int32.MinValue + x)
// Take the first 10 integers from the 'infinite' sequence:
let firstTenInts = Seq.take 10 allIntegers


tenOnes |> Seq.iter (fun x -> printf "%i ... " x)
printfn ""
printfn "%A" firstTenInts


///////////////////////////////////////////
// The unfold Function
// unfold:  -> 'a * 'b option


// Create a Fibonacci sequence using Seq.unfold:
let fibs =
    (1,1) |> Seq.unfold
        (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)))

let first20 = Seq.take 20 fibs
printfn "%A" first20
//first20 |> Seq.iter (fun x -> printf "%i, " x)


// Create a sequence which terminates at a threshold:
let decayPattern =
    Seq.unfold
        (fun x ->
            let limit = 0.01
            let n = x - (x / 2.0)
            if n > limit then
                Some(x, n)
            else
                None)
        10.0


decayPattern |> Seq.iter (fun x -> printf "%f .. " x)


//////////////////////////////////////////
// The cast Function
// cast: 
// work with non-generic function

open System.Collections


let floatArrayList =
    let temp = new ArrayList()
    temp.AddRange([| 1.0; 2.0; 3.0 |])
    temp


// Convert a non generic collection to a generic one
// using Seq.cast:
let (typedFloatSeq: seq<float>) = Seq.cast floatArray

typedFloatSeq |> Seq.iter (fun x -> printf "%f .. " x)
