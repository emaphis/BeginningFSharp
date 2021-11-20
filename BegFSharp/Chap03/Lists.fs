// Lists  pg.38

module Lists

// all items on a list must be the same type

// build lists with '::' operator

// the empty list 
let emptyList = []

// list of one item 
let oneItem = "one " :: [] 

// list of two items
let twoItem = "one " :: "two " :: []


// shorthand syntax for lists
let shortHand = ["apples "; "pears"]

// '@' concatenates twoS lists
let twoLists = ["one, "; "two, "] @ ["buckle "; "my "; "shoe "]

// list of objects 
let objList = [box 1; box 2.0; box "three"]

// print the lists
let main() = 
    printfn "%A" emptyList 
    printfn "%A" oneItem 
    printfn "%A" twoItem 
    printfn "%A" shortHand 
    printfn "%A" twoLists 
    printfn "%A" objList

// call the main function
main()


// lists are immutable
// new lists are created by adding elements to existng lists

// create a list of one item
let one = ["one"]
// create a list of two items
let two = "two" :: one
// create a list of three items
let three = "three" :: two

// reverse the list of three items
let rightWayRound = List.rev three

// function to print the results 
let main2() = 
    printfn "%A" one 
    printfn "%A" two 
    printfn "%A" three 
    printfn "%A" rightWayRound 

// call the main function
main2()
