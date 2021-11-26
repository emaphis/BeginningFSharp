//  The | > Operator  pg. 90

module ForwardPipeOperator

// the definition of the pipe-forward operator
let (|>|) x f = f x

// pipe the parameter 0.5 to the sim function
let result = 0.5 |> System.Math.Sin


// let-to-right inference

let intList = [ 1; 2; 3; ]

let printInt = printf "%i "

List.iter printInt intList


open System

// a date list
let importantDates = [ new DateTime(1066, 10, 14);
                       new DateTime(1999, 01, 01);
                       new DateTime(2999, 12, 31) ]

// printing function
let printInt2 = printf "%i "

// case 1: type annotation required
List.iter (fun (d: DateTime) -> printInt2 d.Year) importantDates

// case 2: no type annotation required
importantDates |> List.iter (fun d -> printInt2 d.Year)


// chaining methods to gether

// grab a list of all methods in memory
let methods = AppDomain.CurrentDomain.GetAssemblies()
                |> List.ofArray
                |> List.map (fun assm -> assm.GetTypes() )
                |> Array.concat
                |> List.ofArray
                |> List.map ( fun t -> t.GetMethods() )
                |> Array.concat

// print the list
printfn "%A" methods
