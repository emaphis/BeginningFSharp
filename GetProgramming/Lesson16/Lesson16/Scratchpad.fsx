// Lession 16 - Useful collecion functions - pg. 186


//////////////////////////////////////
// 16.1 Mapping functions  - pg. 16.1
// takes a collection and returns a collection.


type Person = { Name : string; Town : string }

let persons =
    [ { Name = "Isaac"; Town = "London"}
      { Name = "Sara"; Town = "Birmingham" }
      { Name = "Tim"; Town = "London" }
      { Name = "Michelle"; Town = "Manchester" } ]


// 16.1.1 map
// mapping:('T -> 'U) -> list:'T list -> 'U list

List.map (fun person -> person.Town) persons


// Listing 16.1 map
let numbers = [ 1 .. 10 ]
let timesTwo n = n * 2

let outputImperative = ResizeArray()
for number in numbers do
    outputImperative.Add(number |> timesTwo)
printfn "%A" outputImperative

let outputFunctional = numbers |> List.map timesTwo
printfn "%A" outputFunctional


// Tuples in higher-order functions
let tupleList = [ "Isaac", 30; "John", 25; "Sarah", 18; "Faye", 27 ]
tupleList |> List.map (fun (name, age) -> age * 2)


// 16.1.2  iter  - pg. 188
// action:('T -> 'unit) -> list:'T list -> unit

List.iter (fun person -> printfn "Hello, %s" person.Town) persons

persons |> List.iter (fun person -> printfn "Hello, %s" person.Town)



// 16.1.3 collect  - pg 189
// mapping:('T -> 'U list) -> list:'T list -> 'U list
// SelectMany, FlatMap, Flatten, and even Bind.

// Listing 16.2 collect  - pg.180
type Order = { OrderId : int }
type Customer = { CustomerId : int; Orders : Order list; Town : string }
let customers : Customer list =
    [{ CustomerId = 10
       Orders = [ { OrderId = 55 }; { OrderId = 30 }; { OrderId = 78 } ]
       Town = "Manchester" }
     { CustomerId = 18
       Orders = [ { OrderId = 46 }; { OrderId = 22 } ]
       Town = "London" }
     { CustomerId = 14
       Orders = [ { OrderId = 11 }; { OrderId = 34 }; { OrderId = 47 }; { OrderId = 88 } ]
       Town = "Birmingham" }]

// Collecting all orders for all customers into a single list
let orders : Order list = customers |> List.collect(fun c -> c.Orders)

printfn "%A" orders


// 16.1.4 pairwise  - pg 190
// list:'T list -> ('T * 'T) list

[ 1; 2; 3; 4; 5 ] |> List.pairwise


// Listing 16.3 Using pairwise within the context of a larger pipeline
open System

[ DateTime(2010,5,1)   // A list of dates
  DateTime(2010,6,1)
  DateTime(2010,6,12)
  DateTime(2010,7,3) ]
|> List.pairwise                    // Pairwise for adjacent dates
|> List.map(fun (a, b) -> b - a)    // Subtracting the dates from one another as a TimeSpan
|> List.map(fun time -> time.TotalDays)


[ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15 ]
|> List.windowed 3


////////////////////////////////////////////////////
// 16.2 Grouping functions  - pg. 192

// 16.2.1 groupBy
// projection: ('T -> 'Key) -> list: 'T list -> ('Key * 'T list) list

persons |> List.groupBy (fun person -> person.Town)


// 16.2.2 countBy  - pg 192
// projection: ('T -> 'Key) -> list: 'T list -> ('Key * int) list

persons |> List.countBy (fun person -> person.Town)


// 16.2.3 partition
// predicate: ('T -> bool) -> list: 'T list -> ('T list * 'T list)

let londonCustomers, otherCustomers =
    customers |> List.partition(fun cust -> cust.Town = "London")


/////////////////////////////////////////////
// 16.3 More on collections  - pg. 194


// 16.3.1 Aggregates

// Listing 16.5 Simple aggregation functions in F#
let data = [ 1.0 .. 10.0 ]
let total = data |> List.sum
let average = data |> List.average
let max = data |> List.max
let min = data |> List.min


// 16.3.3 Converting between collections

// Listing 16.6 Converting between lists, arrays, and sequences
let numberOne =
    [ 1 .. 5 ]
    |> List.toArray
    |> Seq.ofArray
    |> Seq.head
