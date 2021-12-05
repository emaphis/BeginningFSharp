// Maps, Dictionaries and Sets  - pg. 197

////////////////////////////////////////////
// 17.1 Dictionaries


// 17.1.1 Mutable dictionaries in F#

// Listing 17.1 Standard dictionary functionality in F#  - pg. 198

open System.Collections.Generic

let inventory = Dictionary<string,float>()
inventory.Add("Apples", 0.33)
inventory.Add("Oranges", 0.23)
inventory.Add("Bananas", 0.45)

inventory.Remove "Oranges"

let bananas = inventory["Bananas"]
//let oranges = inventory["Oranges"]
// System.Collections.Generic.KeyNotFoundException: T


// Listing 17.2 Generic type inference with Dictionary

let inventory2 = Dictionary<_,_>()
inventory2.Add("Apples", 0.33)

let inventory3 = Dictionary()
inventory3.Add("Apples", 0.33)


// 17.1.2 Immutable dictionaries
// Immuable C# dictinary

// Listing 17.3 Creating an immutable IDictionary  -pg. 199

// Creating a (string * float) list of your inventory
let list = [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.45 ] 
let inventory4 =  dict(list)

let bananas4 = inventory.["Bananas"]

//inventory4.Remove("Bananas")
// error FS0039: The value, namespace, type or module 'inventory4' is not defined. Maybe you want one of the following:

/// Creating full dictionary
let dict1 =
    [ "Apples", 10; "Bananas", 20; "Grapes", 15 ]
    |> dict
    |> Dictionary


///////////////////////////////////////////////
// 17.2 The F# Map  - pg. 200
//  Immutable key value lookup.


// Listing 17.4 Using the F# Map lookup

// Creating a (string * float) list of your inventory
let inventory5 =
    [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.45 ]
    |> Map.ofList  // list to map

// Retrieving an item
let apples5 = inventory5["Apples"]
// item doesn't exist
//let pineapples5 = inventory.["Pineapples"]


// Copying the map with a new item added or removed
let newInventory =
    inventory5
    |> Map.add "Pineapples" 0.87
    |> Map.remove "Apples"


// 17.2.1 Useful Map functions  - pg. 201

// Listing 17.5 Using the F# Map module function

let cheapFruit, expensiveFruit =
    inventory5
    |> Map.partition(fun fruit cost -> cost < 0.3)


// Now you try  - pg. 201
// see Filesystem.fsx


///////////////////////////////////
// 17.3  Sets  - pg. 203

// Listing 17.6 Creating a set from a sequence

// input data
let myBasket = [ "Apples"; "Apples"; "Apples"; "Bananas"; "Pineapples" ]
let fruitsILike = myBasket |> Set.ofList   // convert to a set


// Listing 17.7 Comparing List- and Set-based operations

// Creating a second basket of fruits
let yourBasket = [ "Kiwi"; "Bananas"; "Grapes" ]

// Combining the two baskets by using @, then distinct
let allFruitsList = (myBasket @ yourBasket) |> List.distinct

//Creating a second set
let fruitsYouLike = yourBasket |> Set.ofList

// “Summing” two Sets together performs a Union operation
let allFruits = fruitsILike + fruitsYouLike


// Listing 17.8 Sample Set-based operations  - pg. 204

// Gets fruits in A that are not in B
let fruitsJustForMe = allFruits - fruitsYouLike

// Gets fruits that existin both A and B
let fruitsWeCanShare = fruitsILike |> Set.intersect fruitsYouLike

// Are all fruits inA also in B?
let doILikeAllYourFruits = fruitsILike |> Set.isSubset fruitsYouLike
