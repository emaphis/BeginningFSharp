// Modules2

module SomeOtherModule

// Unpack the values defined in each demo moduel
let x = ModuleDemo.FirstModule.n
let y = ModuleDemo.SecondModule.n
let z = ModuleDemo.SecondModule.ThirdModule.n

// test function
let testFun() =
    sprintf "%i %i %i" x y z
