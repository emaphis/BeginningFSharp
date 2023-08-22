﻿module Tuples

    /// A simple tuple of integers.
    let tuple1 = (1, 2, 3)

    /// A function that swaps the order of two values in a tuple.
    ///
    /// F# Type Inference will automatically generalize the function to hava a
    /// generic type, meaning that it will work with any type.
    let swapElems (a, b) = (b, a)
    
    printfn $"The result of swapping (1, 2) is {(swapElems (1, 2))}"
    
    /// A tuple consisting of an integer, a string,
    /// and a double-precision floating point number.
    let tuple2 = (1, "fred", 3.145)

    printfn $"tuple1: {tuple1}\ttuple2: {tuple2}"

    /// Tuples are normally objects, but they can also be represented as structs.
    ///
    /// These interoperate completely with structs in C# and Visual Basice.Net;
    /// however, struct tuples aren not implicitly convertable with object tupels
    /// (often called reference tuples).
    ///
    /// The second line below will fail to compile because of this. 
    /// Uncomment it to see what happens.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int * int) = struct (1, 2)
    
    // Although you can:
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)
        
    printfn $"Struct Tuple: {sampleStructTuple}\nReference tuple made from the Struct Tuple: {(sampleStructTuple |> convertFromStructTuple)}"
