// No you try  pg. 134

// Let’s revisit the simple driving and petrol example from lesson 6 and see whether you 
// can make the code more elegant by using pipelines.


// reverse the positing of the parameters to make a curriable funciton
// petrol should be the passed function
let drive distance petrol  =
    if distance = "far" then
        petrol / 2.0
    elif distance = "medium" then
        petrol - 10.0
    else
        petrol - 1.0


let petrol = 100.0

// old mehot
let firstState = drive "far" petrol
let secondState = drive "medium" firstState
let finalState = drive "short" secondState
printfn "%f" finalState


// using pipeline
petrol
|> drive "far"   // implicitly passing state in a chain
|> drive "medium"
|> drive "short"
|> printfn "%f"
