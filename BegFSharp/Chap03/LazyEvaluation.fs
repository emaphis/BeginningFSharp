// Lazy Evaluation  pg. 62

module LazyEvaluation


// Define a computation which will not be executed straight away:
let lazyValue = lazy ( 2 + 2 )

// Trigger evaluation of the computation:
let actualValue = lazyValue.Force()

// Print the value:
printfn "%i" actualValue


// lazy side effects

// Define a computation which has a side effect:
let lazySideEffect =
    lazy
        ( let temp = 2 + 2 
          printfn "%i" temp
          temp )

// Trigger evaluation of the computation the first time;
// the side effect occurs:  
printfn "Force value the first time: " 
let actualValue1 = lazySideEffect.Force()

// Trigger evaluation of the computation the second time;
// the side effect does not occur
printfn "Force value the second time: " 
let actualValue2 = lazySideEffect.Force()
printfn "%i" actualValue2


// lazy datastructures

// the lazy list definition 
let lazyList = 
    Seq.unfold 
        (fun x -> 
            if x < 13 then 
                // if smaller than the limit return 
                // the current and next value 
                Some(x, x + 1) 
            else 
                // if great than the limit 
                // terminate the sequence 
                None) 
        10

// print the results 
printfn "%A" lazyList


// create an infinite list of Fibonacci numbers 
let fibs = 
    Seq.unfold 
        (fun (n0, n1) -> 
            Some(n0, (n1, n0 + n1))) 
        (1I,1I)

// take the first twenty items from the list 
let first20 = Seq.take 20 fibs

// print the finite list 
printfn "%A" first20
