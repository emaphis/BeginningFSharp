// Custom Attributes  - pg. 141

module CustomAttributes

open System

/// function one
/// <b> - Use functionTwo instead
[<Obsolete>]
let functionOne() = "done"


let done1 = functionOne()


/// function two
/// <p>  - Use functionThree instead </p>
[<Obsolete("it is a pointless function anyway!")>] 
let functionTwo () = () 


let whatEver = functionTwo()


[<Obsolete>] 
type OOThing = class 
    [<Obsolete>] 
    val stringThing : string 
    
    [<Obsolete>] 
    new() = {stringThing = ""} 
    
    [<Obsolete>] 
    member x.GetTheString () = x.stringThing 
end


[<Obsolete>] 
/// some exmmple function  - dont use
let example1() =
    let thing = new OOThing()
    let str = thing.stringThing
    let str2 = thing.GetTheString()
    str, str2


let st1, st2 = example1()

printfn "%s - %s" st1 st2
