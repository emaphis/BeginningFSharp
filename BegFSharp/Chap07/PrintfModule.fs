// The FSharp.Text.Printf Module  - pg. 160

module PrintfModule

open System

// Print a string:
Printf.printf "Hello %s\n" "Robert"

// Uncomment this to see an error:
//Printf.printf "Hello %s" 1


// Types are often inferred from the
// format string of a printf call:
let myPrintInt x = 
    Printf.printf "An integer: %i" x 


// Print π in various formats:
let pi = Math.PI

Printf.printfn "%f" pi 
Printf.printfn "%1.1f" pi 
Printf.printfn "%2.2f" pi 
Printf.printfn "%2.8f" pi


// Write to a string
let s = Printf.sprintf "Hello %s\r\n" "string"
printfn "%s" s
// prints the string to a .NET TextWriter
fprintf Console.Out "Hello %s\r\n" "TextWritter"
// create a strubg that will be place
// in an exception message
//failwith "Hello %s" "exception"

