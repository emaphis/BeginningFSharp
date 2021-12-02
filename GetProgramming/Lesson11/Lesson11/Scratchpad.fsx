// Building Composable Functions  - pg. 125


////////////////////////////////////////
// 11.1 Partial function application

// Listing 11.1 Passing arguments with and without brackets - pg. 126

/// Tupled function:  int * int -> int
let tupledAdd(a, b) = a + b
let answer1 = tupledAdd(5, 10)

// Curried function:  inf -> int -> int
let currendAdd a b = a + b
let answer2 = currendAdd 5 10


// Listing 11.2 Calling a curried function in steps - pd. 127

// Creating a function in curried form
let add first second = first + second

// Partially applying "add" to tet a new function:  int -> int
let addFive = add 5

// calling addFive
let fifteen = addFive 10
printfn "%d" fifteen


//////////////////////////////////////////
// 11.2 Constraining functions  - pg 128

// Listing 11.3 Explicitly creating wrapper functions in F#
open System

let buildDT year month day = DateTime(year, month, day)

let buildDtThisYear month day = buildDT DateTime.UtcNow.Year month day
let buildDtThisMonth day = buildDtThisYear DateTime.UtcNow.Month day

// Listing 11.4 Creating wrapper functions by currying
let buildDtThisYearC = buildDT DateTime.UtcNow.Year
let buildDTThisMonthC = buildDtThisYearC DateTime.UtcNow.Month


// Now you try   - pg.129

// Create a simple wrapper function, writeToFile, for writing data to a text file:

//1 The function should take in three arguments in this specific order:
//    a date—the current date
//    b filename—a filename
//    c text—the text to write out

open System
open System.IO

/// Wtrites to file given date filename and text
let writeToFile (date:DateTime) filename text =
    let path = sprintf "%s-%s.txt" (date.ToString "yyMMdd") filename
    File.WriteAllText(path, text)


let dir = System.IO.Directory.GetCurrentDirectory()

// Listing 11.6 Creating constrained functions

// Creating a constrained version of the function to print with today’s date
let writeToToday = writeToFile DateTime.UtcNow.Date
let writeToTomorrow = writeToFile (DateTime.UtcNow.Date.AddDays 1.)

// Creating a moreconstrained version to print with a specific filename
let writeToTodayHelloWorld = writeToToday "hello-world"


// Calling a constrained version to create a file with today’s date and “first-file”
writeToToday "first-file" "The quick brown fox jumped over the lazy dog"
writeToTomorrow "second-file" "The quick brown fox jumped over the lazy dog"

// Calling the more-constrained version—only the final argument is required
writeToTodayHelloWorld "The quick brown fox jumped over the lazy dog"

// see in:  C:\Users\emaph\AppData\Local\Temp



// 11.2.1 Pipelines  - pg. 131

// Listing 11.7 Calling functions arbitrarily
let checkCreation (creationDate:DateTime) =
    if (DateTime.UtcNow - creationDate).TotalDays > 7. then sprintf "Old"
    else sprintf "New"


// creating the data first, and passing as a temporaty value
let time =
    // Temporary value to store the directory
    let directory = Directory.GetCurrentDirectory()
    // Using the temporary value in a subsequent method call
    Directory.GetCreationTime directory

checkCreation time

// Listing 11.8 Simplistic chaining of functions
checkCreation( Directory.GetCreationTime(Directory.GetCurrentDirectory()) )


// Listing 11.9 Chaining three functions together using the pipeline operator  - pg. 132
Directory.GetCurrentDirectory()   // Returns a string
    |> Directory.GetCreationTime  // Takes in a string, returns a DateTime
    |> checkCreation              // Takes in a DateTime, prints to the console


// Listing 11.10 Sample F# pipelines and DSLs  - pg. 133

// Piped function chain
//let answer = 10 |> add 5 |> timesBy |> add 20 |> add 7 |> timesBy 3

// loadCustomer 17 |> buildReport |> convertTo Formats.PDF |> postToQueue

(*
let customersWithOverdueOrders =
    getSqlConnection “DevelopmentDb”
    |> createDbConnection
    |> findCustomersWithOrders Status.Outstanding (TimeSpan.FromDays 7.0)
*)


// No you try  pg. 134
// see Petrol.fsx


///////////////////////////////////////////
// 11.3 Composing functions together  - pg. 135

// Listing 11.13 Automatically composing functions
let CheckCurrentDirectoryAge =
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime
    >> checkCreation


let description = CheckCurrentDirectoryAge()
printfn "%s" description
