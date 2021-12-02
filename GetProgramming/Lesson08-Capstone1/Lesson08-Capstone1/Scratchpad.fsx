


/// produce the amount distance traveled to a given destination
let getDistance(destination) =
    if destination = "Home" then 25
    elif destination = "Office" then 50
    elif destination = "Stadium" then 25
    elif destination = "Gas" then 10
    else failwith "Unkown destnation!"



// testing get distance
printfn "%b" (25 = getDistance "Home")
printfn "%b" (50 = getDistance "Office")
printfn "%b" (25 = getDistance "Stadium")
printfn "%b" (10 = getDistance "Gas")
printfn "%b" (-9999 = try getDistance "What?" with ex -> -9999)


    
/// calculate the amount of petrol remaining after driving a specific distance
let calculateRemainingPetrol(currentPetrol:int, distance:int) : int =
    let remaining = currentPetrol - distance  // assume 1 unit consumed per 1 unit driven
    if remaining < 0 then
        failwith "Out of gas!"
    remaining 



// testing calculateRemainingPetrol
let petrol1 = 100
let new1 = calculateRemainingPetrol(petrol1, 50)
printfn "%b" (50 = new1)
let new2 = calculateRemainingPetrol(new1, 45)
printfn "%b" (5 = new2)
printfn "%b" (-999 = try calculateRemainingPetrol(new2, 10) with ex -> -999)
 

// 8.4.3 Composing functions together  - pg 97
// build up higher level functions using composition


/// Return new Petrol amount given a destination
let driveTo(petrol, destination) =
    let distance = getDistance(destination)
    let remaining = calculateRemainingPetrol(petrol, distance)
    if (destination = "Gas") then remaining + 50
    else remaining


// testing drive to
let a = driveTo(100, "Office")
let b = driveTo(a, "Stadium")
let c = driveTo(b, "Gas")
let answer = driveTo(c, "Home")
printfn "%b" (answer = 40)



let getDestination() =
    "Home"


// the application
let mutable petrol = 100
let mutable drive = true

while drive do
    try 
        // get the destination from the user
        let destination = getDestination()
        printfn "Trying to drive to %s" destination
        // Get updated petrol from core code and mutate state
        petrol <- driveTo(petrol, destination)
        if petrol <= 0 then
            drive <- false
        printfn "Made it to %s! You have %i petrol left" destination petrol
    with ex -> printfn "Errof: %s" ex.Message

