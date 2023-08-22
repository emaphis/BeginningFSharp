module Sequences

    /// This is the empty sequence
    let seq1 = Seq.empty

    /// This is a sewuence of values
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello";  yield "world"; yield "again" }

    /// This is an on-demand sequence form 1 to 1000.
    let numbersSeq = seq { 1 .. 1000 }
    
    /// This is a sequence producing the words "hello" and "world"
    let seq3 =
        seq { for word in seq2 do 
                if word.Contains("l") then 
                    yield word }

    /// This is a sequence producing the even number up to 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)
    
    let rnd = System.Random()
    
    /// This is an infinite sequence which is a random walk.
    /// This example uses 'yield!' to return each element of a subsequence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x +  rnd.NextDouble() - 0.5 )}
    
    /// This example show the first 100 elements pf the random walk.
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList

    printfn $"First 100 elements of a random walk: {first100ValuesOfRandomWalk}"
