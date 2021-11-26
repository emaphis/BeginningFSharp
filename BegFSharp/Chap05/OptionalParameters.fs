// Optional Parameters  - pg. 107

module OptionalParameters

// A class with an optional parameter in its constructor:
type aClass(?someState: int) =
    let state =
        match someState with
        | Some x -> string x
        | None -> "<no input>"
    
    member x.PrintState (prefix, ?postfix) =
        match postfix with
        | Some x -> printfn "%s %s%s" prefix state x
        | None -> printfn "%s %s" prefix state


// Construct an instance without a value for the optional parameter:
let aClass1 = new aClass()
// Construct an instance with a value for the optional parameter:
let aClass2 = new aClass(109)

aClass1.PrintState("There was")
aClass2.PrintState("Input was:", ", which is nice.")
