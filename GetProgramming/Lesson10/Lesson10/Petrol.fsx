// Try this  - pg 124.
// 1 Model the Car example from lesson 6, but use records to model the state of the Car.


/// A Car
type Car =
  { Model : string
    Color : string
    Petrol : float }
        

let far = 50 
let medium = 25
let home = 0


/// Caluclate new pertol givne a distance
let calulatePetrol(petrol, distance) =
    if distance > far then
        petrol / 2.0
    elif distance > medium then
        petrol - 10.0
    elif distance > home then
        petrol - 1.0
    else
        petrol

/// drive the car a distance
let drive(car, distance) =
    let newPetrol = calulatePetrol(car.Petrol, distance)
    { car with Petrol = newPetrol }
  

let car = 
  { Model = "Chevy"
    Color = "Red"
    Petrol = 100.0}


do 
    let car = drive(car, 55)
    let car = drive(car, 26)
    let car = drive(car, 12)
    printfn "Petrol: %f" car.Petrol
