// Identifiers and 'let' bindings  pg 21

module IdentifiersAndLetBindings

// a literal value
let x = 42

// a binding (declaring) a function the hard way
let myAdd = fun x y -> x + y

// another function declartion
let raisePowerTwo x = x ** 2.0


let n = 10

let add a b = a + b
let result = add n 4

printfn "result = %i" result


// Identifier names

let x' = 43

// unicode
let 标识符 = 42 

//double tick marks ( `` )
let ``more? `` = true 

// keyword name
let ``class`` = "style" 

/// scope

// function to calculate a midpoint
// identing defines scope
let halfWay a b = 
    let dif = b - a 
    let mid = dif / 2 
    mid + a 

// call the function and print the results 
printfn "(halfWay 5 11) = %i" (halfWay 5 11) 
printfn "(halfWay 11 5) = %i" (halfWay 11 5) 

// 'in' key word
let halfWay2 a b =
    let dif = b - a in
    let mid = dif / 2 in
    mid + a

printfn "(halfWay2 5 11) = %i" (halfWay2 5 11) 
printfn "(halfWay2 11 5) = %i" (halfWay2 11 5) 

// When identifiers are out of scope (as define by indenting)
// it's a compiler error to use them:
let printMessage() =
    let message = "Help me"
    printfn "%s" message


// Un-comment the next line to see the error
//printfn "%s" message

// Within a function you can re-bind an identifier using
// another value
// (This i not the same as variable assignment)
let SafeUpperCase (s: string) =
    let s = if s = null then "" else s
    s.ToUpperInvariant()

printfn "%s" (SafeUpperCase "uppercase")


// You canre-bind an identifer using a different type
// (This is non the same as dynamic typing)
let changeType() =
    let x = 1
    let x = "change me"
    // uncomment next line to see the error
    //let x = x + 1
    printfn "%s" x

// When you bind using the same name in an inner scope,
let printMessages() =
    let message = "Important"
    printfn "%s" message;
    // Define an innter function that redefines value of message:
    let innerFun() =
        let message = "Very Important"
        printfn "%s" message
    // Call the inner function
    innerFun ()
    // Fineally print the first message again
    printfn "%s" message


// Funtions can return functions
let calculatePrefixFunction prefix =
    // caluclate prefix
    let prefix' = Printf.sprintf "[%s]: " prefix
    // Define a function to preform prefixing
    let prefixFunction appendee =
        Printf.sprintf "%s%s" prefix' appendee
    prefixFunction

// Create a prefix function.
let prefixer = calculatePrefixFunction "DEBUG"

printfn "%s" (prefixer "My error message")
