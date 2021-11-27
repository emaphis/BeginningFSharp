// Private And Internal  - pg. 131

module PrivateAndInternal


// this is only visible in the current module
let private aPrivateBinding =  "Keep this private"

// this is only visible in the current assembly
let internal aInternalBinding =  "Keep this internal"


// This type will not be visible outside the current assembly
type internal MyUnion =
    | String of string
    | TwoString of string * string


type Thing() =
    // This member is only visible in the current module:
    member private x.PrivateThing() =
        ()

    // This member is only visible in the current assembly:
    member x.ExternalThing() =
        ()
