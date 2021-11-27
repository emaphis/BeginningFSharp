// Classes Static Methods  - pg. 119

module StaticMethods


// a very crude hasher
let hash(s: string) =
    s.GetHashCode()

// pretend to get a user from a database
let getUserFromDB id =
    ((sprintf "someusername%i" id), 1234)


// a class that represents a user
// its constructor takes two parameter, the user's
// name and a has of their password
type User(name, passwordHash) =
    // hashes the users password and checks it against
    // the know hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult
    
    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hellos, %s" name
    
    // a static member that provide a alternative way
    // of creating the object
    static member FromDB id =
        let name, ph = getUserFromDB id
        new User(name, ph)

// Create a user user using the primary constuctor
let user1 = User("kiteason", 1234)
// Create a user using a static method
let user2 = User.FromDB 999


// A re-implementation of integers which supports a + operator:
type MyInt(state: int) =
    member x.State = state

    static member (+) (x: MyInt, y: MyInt) : MyInt = new MyInt(x.State + y.State)

    override x.ToString() = string state

let x = new MyInt(1)
let y = new MyInt(1)

printfn "(x + y) = %A" (x + y)
