// F# Types with Members - pg. 97

module FSharpTypesWithMembers


// a point type
type Point =
    { Top: int;
      Left: int }
    with
        // the swap member create a new point
        member x.Swap() =
            { Top = x.Left;
              Left = x.Top }

// create a new point
let myPoint =
    { Top = 3;
      Left = 7 }


// print the initial point
printfn "%A" myPoint
// create a new point with the coord swapped
let nextPoint = myPoint.Swap()
// print the new point
printfn "%A" nextPoint


// Union types can have member functions, too.

// a type representing the amount of a specific drink
type DrinkAmount =
    | Coffee of int
    | Tea of int
    | Water of int
    with
        // get a string representation of the value
        override x.ToString() =
            match x with
            | Coffee x -> Printf.sprintf "Coffee: %i" x
            | Tea x -> Printf.sprintf "Tea: %i" x
            | Water x -> Printf.sprintf "Water: %i" x


//  create a new instance of DrinkAmount
let t = Tea 2

// print out the string
printfn "%s" (t.ToString())
