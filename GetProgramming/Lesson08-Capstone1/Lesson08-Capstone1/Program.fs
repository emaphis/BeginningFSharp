/// Calculate the petrol useg for a given trip.

open System
open Car


let getDestination() =
    Console.Write("Enter destination (Home, Office, Stadium, Gas): ")
    Console.ReadLine()


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
    with ex -> printfn "Error: %s" ex.Message

