// The Mutable Keyword  pg. 77

module MutableValues

// The Mutable Keyword 

// a mutalbe identifier
let mutable phrase = "How can I be sure, "

// print the phrase
printfn "%s" phrase

// update the phrase
phrase <- "In a world that's constantly chnaging"

// print the phrase
printfn "%s" phrase


let mutable number = "one"
//number <- 1


// domstration of redefining x
let redefineX() =
    let x = "One"
    printfn "Redefining:\r\nx = %s" x
    if true then
        let x = "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// demonstration of mutating x
let mutableX() =
    let mutable x = "One"
    printfn "Mutating:\r\nx = %s" x
    if true then
        x <- "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// run the demo
redefineX()
mutableX()


// mutating before F# 4.0
let mutableY() =
    let mutable y = "One"
    printfn "Mutating:\r\ny = %s" y
    let f() =
        // this causes an arror as
        // mutables can't be captured
        y <- "Two"
        printfn "y = %s" y
    f()
    printfn "y = %s" y

mutableY()


// Defining Mutable Records

// a record with a mutable field
type Couple = { Her: string; mutable Him: string }

// create an instance of the record
let theCouple = { Her = "Elizabeth Tayler "; Him = "Nicky Hilton" }

// function to change the contents of
// tkhe record over time
let changeCouple() =
    printfn "%A" theCouple
    theCouple.Him <- "Michel Wilding"
    printfn "%A" theCouple
    theCouple.Him <- "Micheal Todd"
    printfn "%A" theCouple
    theCouple.Him <- "Eddie Fisher"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "John Warner" 
    printfn "%A" theCouple
    theCouple.Him <- "Larry Fortensky"
    printfn "%A" theCouple 

// call the function
changeCouple()    

// Uncomment the next line to see an error:
//theCouple.Her <- "Sybil Williams"



// The Reference Type

// You can use a ref type as another kind of
// updatable value:

// createing a ref type
let phrase1 = ref "Inconsistency" 

phrase1.Value <- "new phrase"

let ref1 = phrase1.Value


// total contents of an array
let totalArray() =
    // define an array literal
    let array = [| 1; 2; 3 |]
    
    // define a counter
    let total = ref 0
    
    // loop over the array
    for x in array do
        // keep a running total
        total.Value <- total.Value + x
    
    // print the total
    printfn "total: %i" total.Value


totalArray()

// multiople functions using a ref

// capture the inc, dec, and show functions
let inc, dec, show =
    // define the sharesd state
    let n = ref 0

    // a function to increment
    let inc() =
        n.Value <- n.Value + 1

    // a function to decrement
    let dec () =
        n.Value <- n.Value - 1
    
    // a function to show the current state
    let show() =
        printfn "%i" n.Value

    // return the function to the top level
    inc, dec, show

// test the functions
inc()
inc()
dec()
show()

// From F# 4.0 onwards, the preceding code can be rewritten using a mutable value, like so
let inc1, dec1, show1 =
    // define the shared state
    let mutable n = 0

    // a function to increment
    let inc1() =
        n <- n + 1
    
    // a dunction to decrement
    let dec1() =
        n <- n - 1

    // a runction to show the current state
    let show1() =
        printfn "%i" n
    
    // return the functions to the top level
    inc1, dec1, show1

// test the functions
inc1()
inc1()
dec1()
show1()
