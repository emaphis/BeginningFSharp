// Additional Constructors  - pg. 108

module AdditionalConstructors


// a class that represents a user
// its constructor takes two parameters, the user's
// name and a hask of their password
type User(name, passwordHash) =
    // Store the password hash in a mutable let
    // binding, so it can be changed later:
    let mutable passwordHash = passwordHash

    // An additonal constructor to create a user given the
    // raw password
    new(name: string, password: string) =
        User(name, (hash password))
    
    // Hashes the user's password and checks it against
    // the know hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult
    
    // Gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // Changes the users password:
    member x.ChangePassword(password) =
        passwordHash <- hash password


let user1 = User("kiteason", 1234)
printfn "*** %s" (user1.LogonMessage())
