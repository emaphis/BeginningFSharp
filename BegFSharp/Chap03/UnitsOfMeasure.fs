// Units of Measure  pg 58

module UnitsOfMeasure

// A unit of measure for meters:
[<Measure>]type m
// A distance in meters:
let meters = 1.0<m>


// define some units of measure 
[<Measure>]type liter
[<Measure>]type pint

let ratio = 1.0<liter> / 1.76056338<pint>

// a function to convert pints to liters
let convertPintToLiter pints =
    pints * ratio


let vol1 = 2.5<liter>
let vol2 = 2.5<pint>

let newVol = vol1 + (convertPintToLiter vol2)

// using a format placeholder with a unit-of-measure value (>= F# 4.0) 
printfn "The volume is %f" vol1
printfn "The new volume is %f" newVol
