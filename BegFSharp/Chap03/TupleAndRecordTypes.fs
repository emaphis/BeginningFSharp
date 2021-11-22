// Tuple and Record Types  pg. 37

module TupleAndRecordTypes

// Tuples are a way of quickly and conveniently composing values into a
//  group of values

// Bind a tuple using "," syntax:
let pair = true, false
let b1, b2 = pair
let b3, _ = pair
let _, b4 = pair

// Declare type alias for a type
type Name = string 
type Fullname = string * string

// ...and use that alias later as a type specifier:
let fullNameToString (x: Fullname) =
    let first, second = x in
    first + " " + second


// Record types use  for small groups of named fields:

// define an organization with unique fields
type Organization1 = { boss: string; lackeys: string list }

// Create an instance of this organization
let rainbow =
    { boss = "Jeffery";
      lackeys = [ "Zippy"; "George"; "Bungle" ] }


// If field names are the same between two record types,
// you can disambiguate by specifing which you mean:

// Define tow organizations with overlapping fields
type Organization2 = { chief: string; underlings: string list }
type Organization3 = { chief: string; indians: string list }

// create an instance of Organization2
let (thePlayers: Organization2) =
    { chief = "Peter Qunce";
      underlings = [ "Francis Flute"; "Robin Starveling";
                     "Tom Snout"; "Snug"; "Nick Bottom"  ] }

// Create an instance of Organization3
let (wayneManor0: Organization3) =
    { chief = "Batman"; 
      indians = [ "Robin"; "Alfred" ] }

// Access a field from a record type:
printfn "wayneManor.chief = %s" wayneManor0.chief


// accessing fields

// define an orginize type
type Organization = { chief: string; indians: string list }

// create an instance of this type
let wayneManor =
    { chief = "Batman"; 
      indians = [ "Robin"; "Alfred" ] }

// access a field from this type
printfn "wayneManor.cheif = %s" wayneManor.chief

// records are immutble, to update create a new compy with changes

// Create a modified instance of a record type:
let wayneManor' =
    { wayneManor with indians = [ "Alfred" ] }

// print out the two organizations 
printfn "wayneManor = %A" wayneManor 
printfn "wayneManor' = %A" wayneManor'


// accessing structure fields with pattern matching

// type representing a couple
type Couple = { him: string; her: string }

// list of couples
let couples = 
    [ { him = "Brad" ; her = "Angelina" }; 
      { him = "Becks" ; her = "Posh" }; 
      { him = "Chris" ; her = "Gwyneth" }; 
      { him = "Michael" ; her = "Catherine" } ]

// function to find "David" from a list of couples
let rec findDavid l =
    match l with
    | { him = x; her = "Posh" } :: tail -> x
    | _ :: tail -> findDavid tail
    | [] -> failwith "Couldn't find David"

// print the results 
printfn "%A" (findDavid couples)


//
let rec findPartner soughtHer l =
    match l with
    | { him = x; her = her } :: tail when her = soughtHer -> x
    | _ :: tail -> findPartner soughtHer tail
    | [] -> failwith "Couldn't find David"


// print the results 
printfn "%A" (findPartner "Posh" couples)
