////////////////////////////////////////////////////////
// 6.3 Modeling state  - pg. 75

// 6.3.1 Working with mutable data

// Now you try

// Listing 6.6 Managing state with mutable variables  pg. 76

/// initial state
let mutable petrol = 0.0

// set state
petrol <- 100.0

/// Modify state through mutation
let drive(distance) =
    if distance = "far" then
        petrol <- petrol / 2.0
    elif distance = "medium" then
        petrol <- petrol - 10.0
    else
        petrol <- petrol - 1.0
        

// Repeatedly modify state
drive("far")
drive("medium")
drive("short")
printf "%f" petrol



// 6.3.2 Working with immutable data  - pg 77

/// Listing 6.7 Managing state with immutable values
let drive2(petrol, distance) =
    if distance = "far" then
        petrol / 2.0
    elif distance = "medium" then
        petrol - 10.0
    else
        petrol - 1.0

let petrol2 = 100.0
let firstState = drive2(petrol2, "far")
let secondState = drive2(firstState, "medium")
let finalState = drive2(secondState, "short")
printfn "%f" finalState



//Now you try  - pg.79

//Let’s see how to make some changes to your drive code:
//    1 Instead of using a string to represent how far you’ve driven, use an integer.
//    2 Instead of far, check whether the distance is more than 50.
//    3 Instead of medium, check whether the distance is more than 25.
//    4 If the distance is > 0, reduce petrol by 1.
//    5 If the distance is 0, make no change to the petrol consumption. In other words, 
//    return the same state that was provided

let drive3(petrol, distance) =
    if distance > 50 then
        petrol / 2.0
    elif distance > 25 then
        petrol - 10.0
    elif distance > 0 then
        petrol - 1.0
    else
        petrol
    

let petrol3 = 100.0
let firstState3 = drive3(petrol3, 55)
let secondState3 = drive3(firstState3, 26)
let finalState3 = drive3(secondState3, 12)
printfn "%f" finalState3
