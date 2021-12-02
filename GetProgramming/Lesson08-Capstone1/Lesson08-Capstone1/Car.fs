module Car


/// produce the amount distance traveled to a given destination
let getDistance(destination) =
    if destination = "Home" then 25
    elif destination = "Office" then 50
    elif destination = "Stadium" then 25
    elif destination = "Gas" then 10
    else failwith "Unkown destnation!"


    
/// calculate the amount of petrol remaining after driving a specific distance
let calculateRemainingPetrol(currentPetrol:int, distance:int) : int =
    let remaining = currentPetrol - distance  // assume 1 unit consumed per 1 unit driven
    if remaining < 0 then
        failwith "Out of gas!"
    remaining


/// Return new Petrol amount given a destination
let driveTo(petrol, destination) =
 let distance = getDistance(destination)
 let remaining = calculateRemainingPetrol(petrol, distance)
 if (destination = "Gas") then remaining + 50
 else remaining

