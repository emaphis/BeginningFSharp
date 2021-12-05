// Lession 18 - Folding your way to success  - pg. 206


//////////////////////////////////////////
// 18.1 Understanding aggregations and accumulators


// 18.1 Understanding aggregations and accumulators
// Sum, Average, Min, Max, and Count

// Listing 18.1 Example aggregation signatures
type Sum = int seq -> int
type Average = float seq -> float
type Count<'T> = 'T seq -> int


// 18.1.1 Creating your first aggregation function

// Listing 18.2 Imperative implementation of sum  - pg. 208
let sumI inputs =
    let mutable accumulator = 0;
    for input in inputs do
        accumulator <- accumulator + input
    accumulator


let acc1 = sumI [ 1; 2; 3; ]


// Now you try  - pg. 209

/// o calculate the length of a list - Imperitave
let lengthI inputs =
    let mutable accumulator = 0;
    for _ in inputs do
        accumulator <- accumulator + 1
    accumulator


let len1 = lengthI [ 1; 2; 3; 4; 5; ]
    

/// calcuate the max of a list
let maxI inputs =
    let mutable acc = -999999999
    for input in inputs do
        if input > acc then
            acc <- input
    acc


let max1 = maxI [ 9; 4; 2; 10; 11; 3; 2 ]


////////////////////////////////////////////
// 18.2 Saying hello to fold  - pg. 209

//type folder = ( 'State -> 'T -> 'State) -> state:'State -> source:seq<'T> -> 'State

// Listing 18.3 Implementing sum through fold  - pg 210
let sum inputs =
    Seq.fold (fun state input -> state + input) 0 inputs

let acc2 = sum [ 1; 2; 3; ]


// Listing 18.4 Looking at fold with logging
let sumL inputs =
    Seq.fold (fun state input -> 
        let newState = state + input
        printfn "Current state is %d, input is %d, new state is %d"
            state input newState
        newState)
        0
        inputs

let acc3 = sumL [ 1 .. 5 ]
(*
Current state is 0, input is 1, new state is 1
Current state is 1, input is 2, new state is 3
Current state is 3, input is 3, new state is 6
Current state is 6, input is 4, new state is 10
Current state is 10, input is 5, new state is 15
*)


// Now you try  - pg. 211

let length inputs =
    Seq.fold (fun state _ -> state + 1) 0 inputs

let len2 = length [ 1; 2; 3; 4; 5; ]


let max inputs =
    Seq.fold (fun state input ->
            if state > input then state
            else input)
         -99999999
         inputs

let max2 = max [ 9; 4; 2; 10; 11; 3; 2 ]



// 18.2.1 Making fold more readable  - pg 212

let sum1 inputs =
    Seq.fold (fun state input -> state + input) 0 inputs

// Using pipeline to move “inputs” to the left side
let sum2 inputs =
    inputs |> Seq.fold (fun state input -> state + input) 0

// Using the double pipeline to move both the initial state and “inputs” to the left side
let sum3 inputs =
    (0, inputs) ||> Seq.fold (fun state input -> state + input)

let sum4 = sum3 [ 1; 2; 3 ]


// 18.2.2 Using related fold functions  - pg 212

//  foldBack—Same as fold, but goes backward from the last element in the collection.
List.fold (fun acc x -> x :: acc) [] [ 1; 2; 3; 4; 5 ]
// => int list = [5; 4; 3; 2; 1]

List.foldBack (fun x acc -> x :: acc) [] [ 1; 2; 3; 4; 5]
// => int list = [1; 2; 3; 4; 5]


//  mapFold—Combines map and fold, emitting a sequence of mapped results and a final state
// ('State -> 'T -> 'U * 'State) -> 'State -> C<'T> -> C<'U> * 'State
let what = List.mapFold (fun x y ->  ("k", y) ) 0 [ 1; 2; 3; 4; 5 ]
// string list * int = (["k"; "k"; "k"; "k"; "k"], 5)

let poof = List.mapFold (fun x y -> (x, x+1)) 0 [ 1; 2; 3; 4 ]
// nt list * int = ([0; 1; 2; 3], 4)

//  reduce—A simplified version of fold, using the first element in the collection as the 
//   initial state, so you don’t have to explicitly supply one. Perfect for simple folds 
//   such as sum (although it’ll throw an exception on an empty input—beware!)
List.reduce (fun acc x -> acc + x) [ 1; 2; 3; 4 ]
// => 10

// scan—Similar to fold, but generates the intermediate results as well as the final 
//   state. Great for calculating running totals.
List.scan (fun acc x -> acc + x) 0 [ 1; 2; 3; 4; 5 ]
// => int list = [0; 1; 3; 6; 10; 15]

//  unfold—Generates a sequence from a single starting state. Similar to the yield keyword.
let sumUpTo (stop) = 
    List.unfold (fun x ->
                     if ( x >= stop) then None
                     else Some(x+1, x+1))
                0
sumUpTo(10)
// int list = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]



// 18.2.3 Folding instead of while loops  - pg.213

// Listing 18.6 Accumulating through a while loop
open System.IO

let mutable totalChars = 0
let st = new StreamReader(File.OpenRead @"C:\tmp\book.txt")

while (not st.EndOfStream) do
    let line = st.ReadLine()
    totalChars <- line.ToCharArray().Length

printfn "Total chars: %d" totalChars
st.Close()


// Listing 18.7 Simulating a collection through sequence expressions
let lines: string seq =
    seq {
        use st = new StreamReader(File.OpenRead @"C:\tmp\book.txt")
        while (not st.EndOfStream) do
            yield st.ReadLine()  }

let totalChars2 = lines |> Seq.fold (fun total line -> total + line.Length) 0

printfn "Total chars: %d" totalChars2


///////////////////////////////////
// 18.3 Composing functions with fold  - pg. 214

// Rules engine
//  Every string should contain three words.
//  The string must be no longer than 30 characters.
//  All characters in the string must be uppercase


// Listing 18.8 Creating a list of rules  -pg. 215

open System
type Rule = string -> bool * string

let rules: Rule list =
  [ fun text -> (text.Split ' ').Length = 3,  "Must be three word"
    fun text -> text.Length <= 30, "Max length is 30 characters"
    fun text -> text
                |> Seq.filter Char.IsLetter
                |> Seq.forall Char.IsUpper,  "All letters must be caps"]



