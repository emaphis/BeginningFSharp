// Introducing LINQ  - pg. 190

module Strangelights.LinqNamesByFunction

open Strangelights.LinqImports


/// query string methods using functions
let namesByFunction =
    (typeof<string>).GetMethods()
    |> where (fun m -> not m.IsStatic)
    |> groupBy (fun m -> m.Name)
    |> select (fun m -> m.Key, count m)
    |> orderBy (fun (_, m) -> m)


let printFunctions() =
    namesByFunction
    |> Seq.iter (fun (name, count) -> printf "%s - %i\n" name count)


//printFunctions()    
