// The FSharp.Reflection Module  - pg. 152

module Reflection

// Reflection Over Types
// Reflection over types lets you examine the types that make up a particular value 
// or type

open FSharp.Reflection

let printTupleTypes (x: obj) =
    let t = x.GetType()
    if FSharpType.IsTuple t then
        let types = FSharpType.GetTupleElements t
        printf "("
        types
        |> Seq.iteri
            (fun i t ->
                if i <> Seq.length types - 1 then
                    printf "%s * " t.Name
                else
                    printf "%s" t.Name)
        printf " )"
    else
        printfn "not a tuple"


printTupleTypes ("hello world", 1)


// Reflection Over Values
// Reflection over values lets you examine the values that make up a particular 
// composite value

//open FSharp.Reflection

let printTupleValues (x: obj) =
    if FSharpType.IsTuple(x.GetType()) then
        let vals = FSharpValue.GetTupleFields x
        printf "("
        vals
        |> Seq.iteri
            (fun i v ->
                if i <> Seq.length vals - 1 then
                    printf "%A, " v
                else
                    printf "%A" v)
        printf " )"
    else
        printfn "not a tuple"


printTupleValues ("hello world", 1)

