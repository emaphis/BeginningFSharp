// Interfaces  - pg. 108

module Interfaces

// an interface "IUser"
type IUser =
    // hases the user's pasword
    // the known has
    abstract Authenticate: evidense: string -> bool

    // gets the users logon message
    abstract LogonMessage: unit -> string


let logn(user: IUser) (pasword: string) =
    // authenticate user print appropriate message
    if user.Authenticate(pasword) then
        printfn "%s" (user.LogonMessage())
    else
        printfn "Logon failed"


// Implementation of Interfaces

// a very crude hasher
let hash (s: string) =
    s.GetHashCode()


// A User class which implements IUser:
type User(name, passwordHash) =
    interface IUser with

        // Authenticate implementation
        member x.Authenticate(password) =
            let hashResult = hash password
            passwordHash = hashResult

        // LogonMessage implementation:
        member x.LogonMessage() =
            sprintf "Hello, %s" name


// Create a new instance of the user
// -883706295 is the hash of "mypassword":
let user = User("Robert", -883706295)

let hashTest = hash "mypassword"

// Get the logon message by casting the IUser then calling LogonMessage
let LogonMessage = (user :> IUser).LogonMessage()


// Function to demonstrate logging on via IUser:
let logon(user: IUser) (pasword: string) =
    // authenticate user print appropriate message
    if user.Authenticate(pasword) then
        printfn "%s" (user.LogonMessage())
    else
        printfn "Logon failed"


// A successful logon attempt:
do logon (user :> IUser) "mypassword"

// failed logon attempt
do logon (user :> IUser) "guess"


// without casting

// A version of User which doesn't require callers to cast
// the User instance to the interface, to use the interface
// members:
type User2(name, passwordHash) =
    interface IUser with

        // Authenticate implementation
        member x.Authenticate(password) =
            let hashResult = hash password
            passwordHash = hashResult

        // LogonMessage implementation:
        member x.LogonMessage() =
            sprintf "Hello, %s" name
    
    // Expose Authenticate implemetation
    member x.Authenticate(password) = x.Authenticate(password)

    // Expose LogonMessage implementation:
    member x.LogonMessage() = x.LogonMessage()


// Create a new instance of the user
let user2 = User2("Robert", -883706295)

// Get the logon message by casting the IUser then calling LogonMessage
let LogonMessage1 = (user2 :> IUser).LogonMessage()

// A successful logon attempt:
do logon (user2 :> IUser) "mypassword"

// failed logon attempt
do logon (user2 :> IUser) "guess"
