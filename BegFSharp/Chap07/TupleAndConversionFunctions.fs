// Tuple and ConversionFunctions  - pg. 151

module TupleAndConversionFunctions

// Tuple Functions

// Get the first and second elements of a tuple
printfn "(fst (1, 2)): %i" (fst (1, 2))
printfn "(snd (1, 2)): %i" (snd (1, 2))


// The Conversion Functions

open System

// Convert an int into an enum:
let dayInt = int DateTime.Now.DayOfWeek
let (dayEnum: DayOfWeek) = enum dayInt

printfn "%i" dayInt
printfn "%A" dayEnum

