// Defining Classes  - pg. 104

module Classes

// a very crude hasher
let hash (s : string) =
    s.GetHashCode()


// a class that represent a user
// its consturcor takes tow parameters, the user's
// name and a has of their password
type User(name, passwordHash) =

    // hashes the user's password and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // gets the user's logon message
    member x.LogonMessage() =
        sprintf "Hello, %s" name
    

// Create a user using the primary constructor
let user1 = User("kiteeason", 1234)
// Access a method of the User instance
printfn "*** %s" (user1.LogonMessage())


// A class that represents a user,
// its constructor takes three parameters, the User's
// first name, last name and a hash of thier password:
type User2(firstName, lastName, passwordHash) =
    // Calculate the user's full name and store if for later use
    let fullName = Printf.sprintf "%s %s" firstName lastName
    // Print the users fullname as object is being constructer:
    do printfn "User: %s" fullName

    // Hashes the user's password and checks it againsst
    // the know hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash - hashResult

    // Retrieves the user's full name:
    member x.GetFullname() = fullName


// updating a class's state

// A class that represents a user;
// its constructor takes two parameters, the user's
// name and a hash of their password.
// This version can 'change' the password by
// returning a new instance with the new password:
type User3(name, passwordHash) =
    // Hashes the users password and checks it against
    // the known hash:
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // Gets the user's logon message:
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // creates a copy of the user with the password changed 
    member x.ChangePassword(password) = 
        new User3(name, hash password) 


// mutable object

// a class that represents a user 
// its constructor takes two parameters, the user's 
// name and a hash of their password
type User4(name, passwordHash) =
    // store the password hash in a mutable let
    // binding, os it can be changed later
    let mutable passwordHash = passwordHash
    
    // Hashes the users password and checks it against
    // the known hash:
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // Gets the user's logon message:
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // creates a copy of the user with the password changed 
    member x.ChangePassword(password) = 
        passwordHash <- hash password 
