// Shaping Data with Tupeles.  pg. 101

/////////////////////////////////////
// 9.2 Tuple basics


/// Listing 9.3 Returning arbitrary data pairs in F#
let parseName (name: string) =
    let parts = name.Split(' ')
    let forename = parts[0]
    let surname = parts[1]
    forename, surname    // returns a tuple


let name = parseName("Issac Abraham")
let forename, surname = name

let fname, sname = parseName("Isaac Abraham")


// a tuple of three values
let a = "isaac", "abraham", 35.


// Now you try  - pg. 104

open System

let parse(person: string) =
    let parts = person.Split(' ')
    let playername = parts[0]
    let game = parts[1]
    let score = Int32.Parse(parts[2])
    playername, game, score


let playername, game, score = parse("Mary Asteroids 2500")

printfn "%s %s %i" playername game score



///////////////////////////////////////
// 9.3  More complex tuples


// 9.3.1 Tuple type signatures

let nameAndAge = "Joe", "Blogs", 28
//val nameAndAge: string * string * int 


// 9.3.2 Nested tuples

// Listing 9.4 Returning more-complex arbitrary data pairs in F# - pg 106

//Creating a nested tuple
let nameAndAge1 = ("Joe", "Bloggs"), 28
// val nameAndAge1: (string * string) * int

// Deconstructing a tuple
let name1, age1 = nameAndAge1

let (forename1, surname1), theAge = nameAndAge1



// 9.3.3 Wildcards  - pg. 107

// Listing 9.5 Using wildcards with tuples
let nameAndAge2 = "Jane", "Smith", 25  // ignore age
let forename2, surname2, _ = nameAndAge2


// 9.3.4 Type inference with tuples  - pg. 107

// Listing 9.6 Type inference with tuples in F#
let explicit : int * int = 10, 5
let implicit = 10, 5

let addNumbers arguments =
    let a, b = arguments
    a + b


let num1 = addNumbers(explicit)
let num2 = addNumbers(implicit)


// Listing 9.7 Genericized functions with tuples
let addNumbers1 arguments =
    let a, b, c, _ = arguments
    a + b

// val addNumbers1: int * int * 'a * 'b -> int

let num3 = addNumbers1(10, 4, 'A', 3.5)
