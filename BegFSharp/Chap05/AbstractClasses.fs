// Abstract Classes  - pg. 118

module AbstractClasses


// a abstract class that represents a user 
// its constructor takes one parameter, 
// the user's name
[<AbstractClass>]
type User(name) =
    // the implementation of this method should hashes the
    // user's password and checks it against the know hash
    abstract Authenticate: evidense: string -> bool

    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name
