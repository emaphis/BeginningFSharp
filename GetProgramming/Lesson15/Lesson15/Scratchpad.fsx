// Working with collections in F#
// pg. 173

// 15.1 F# collection basics

type FootballResult =
  { HomeTeam: string
    AwayTeam: string
    HomeGoals: int
    AwayGoals: int }

let create (ht, hg) (at, ag) =
    { HomeTeam = ht; AwayTeam = at; HomeGoals = hg; AwayGoals = ag}


let results = 
  [ create ("Messiville", 1) ("Ronaldo City", 2)
    create ("Messiville", 1) ("Bale Town", 3)
    create ("Bale Town", 3) ("Ronaldo City", 1)
    create ("Bale Town", 2) ("Messiville", 1)
    create ("Ronaldo City", 4) ("Messiville", 2)
    create ("Ronaldo City", 1) ("Bale Town", 2) ]



// Now you try  - pg. 175
results
|> Seq.filter (fun rc -> rc.HomeGoals > rc.AwayGoals)
|> Seq.countBy (fun rc -> rc.AwayTeam)


// 15.1.1 In-place collection modifications  - pg.175

// Listing 15.2 An imperative solution to a calculation over data

open System.Collections.Generic

type TeamSummary = { Name : string; mutable AwayWins : int }
let summary = ResizeArray()

for result in results do
    if result.AwayGoals > result.HomeGoals then
        let mutable found = false
        for entry in summary do
            if entry.Name = result.AwayTeam then
                found <- true
                entry.AwayWins <- entry.AwayWins + 1
        if not found then
            summary.Add { Name = result.AwayTeam; AwayWins = 1 }
  
// for sorting
// object initializer
let comparer =
    { new IComparer<TeamSummary> with
        member this.Compare(x,y) =
            if x.AwayWins > y.AwayWins then -1
            elif x.AwayWins < y.AwayWins then 1
            else 0 }

summary.Sort(comparer)

summary.Count

// print summary
for team in summary do
    printfn "%s - %d" team.Name team.AwayWins



// 15.1.2 The collection modules  - pg. 176
// F#’s own version of the LINQ Enumerable library
// List Array Seq

// Listing 15.3 Standard pattern for F# collection module functions  - pg. 177

type Customer =
  { Name: string
    Country: string
    City: string }

let sequenceOfCustomers =
  [ { Name = "BBB"; Country = "USA"; City = "Washington" }
    { Name = "CCC"; Country = "Canada"; City = "London"}
    { Name = "III"; Country = "UK"; City = "London"}
    { Name = "DDD"; Country = "USA"; City = "Painesville"}
    { Name = "EEE"; Country = "Mexico"; City = "Montes"} ]

let arrayOfNumbers = [| 1; 2; 3; 4; 5 |]


// Passing a function into Seq.filter to get USA customers
let areFromUSA customer = (customer.Country = "USA")  // Dtun
let usaCustomer = Seq.filter areFromUSA sequenceOfCustomers

let numbersDoubled = Array.map (fun number -> number * 2) arrayOfNumbers

let customersByCity = List.groupBy (fun c -> c.City) sequenceOfCustomers

// Getting UK customers with Seq.filter and pipeline operator
let areFromUK cust = (cust.Country = "UK")
let ukCustomers = sequenceOfCustomers |> Seq.filter areFromUK

let tripledNumbers = arrayOfNumbers |> Array.map (fun number -> number * 3)

let customersByCountry = sequenceOfCustomers |> List.groupBy (fun c -> c.Country)


// 15.1.3 Transformation pipelines  - pg. 178

// Listing 15.4 A declarative solution to a calculation over data

// A standalone function to calculate whether a result is an away win
let isAwayWin result = result.AwayGoals > result.HomeGoals

results
|> List.filter isAwayWin
|> List.countBy(fun result -> result.AwayTeam)
|> List.sortByDescending (fun (_, awayWin) -> awayWin)



/////////////////////////////////////////////////////////
// 15.2 Collection types in F#  - pg. 182


// 15.2.2 Using .NET arrays  - pg. 182

// Listing 15.5 Working with .NET arrays in F#

// Creating an array by using [| |] syntax
let numbersArray = [| 1; 2; 3; 4; 6 |]
let firstNumber = numbersArray[0]  // Accessing an item by index
let firstThreeNumbers = numbersArray[0 .. 2] // Array-slicing syntax
numbersArray[0]  <- 99   // .NET arrays are mutable


// 15.2.3 Immutable lists

// Creating a list of six numbers
let numbers = [ 1; 2; 3; 4; 5; 6 ]
let numbersQuick = [ 1 .. 6 ]

// Decomposing a list into head and tail
let head :: tail = numbers
let moreNumbers = 0 :: numbers
let evenMoreNumbers = moreNumbers @ [ 7 .. 9 ]
