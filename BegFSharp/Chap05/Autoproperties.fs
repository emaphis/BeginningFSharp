// Autoproperties  - pg. 117

module Autoproperties

// normal propterties

type CircleP() =
    let mutable radius = 0.0

    member x.Radius
        with get() = radius
        and set(r) = radius <- r

let c = CircleP()
c.Radius <- 99.9
printfn "Radius: %f" c.Radius


// autoproperties

type Circle() =
    member val Radius = 0.0
        with get, set 


let ca = Circle()
ca.Radius <- 99.9
printfn "Radius: %f" ca.Radius


// To make the property read-only omit the 'set' keyword
