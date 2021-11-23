// Arrays  pg. 73

module Arrays

// define an array literal
let rhymeArray =
    [| "Went to market";
       "Stayed home";
        "Had roast beef";
        "Had none"|]

// unpack the array into identifiers
let firstPiggy = rhymeArray[0]
let secondPiggy = rhymeArray[1]
let thirdPiggy = rhymeArray[2]
let fourthPiggy = rhymeArray[3]


// update elements of the array 
rhymeArray.[0] <- "Wee," 
rhymeArray.[1] <- "wee," 
rhymeArray.[2] <- "wee," 
rhymeArray.[3] <- "all the way home" 

// give a hort name to the new line characters
let nl = System.Environment.NewLine

// print out the identifiers & arra
printfn "%s%s%s%s%s%s%s"
    firstPiggy nl
    secondPiggy nl
    thirdPiggy nl
    fourthPiggy
printfn "%A" rhymeArray


// jagged array litteral
let jagged = [| [| "one" |]; [| "Two"; "Three" |] |]


// unpac elements form the arrays
let singleDim = jagged[0]
let itemOne = singleDim[0]
let itemTwo = jagged[1][0]

// print some of the upacked elements
printfn "%s %s" itemOne itemTwo


// create a square array, 
// initally populated with zeros 
let square = Array2D.create 2 2 0

// populate the array
square[0,0] <- 1
square[0,1] <- 2
square[1,0] <- 3
square[1,1] <- 4

// print the array
printfn "%A" square


// define Pascals's triangle as an
// array literal
let pascalsTriangle = 
    [| [|1|]; 
       [|1; 1|]; 
       [|1; 2; 1|]; 
       [|1; 3; 3; 1|]; 
       [|1; 4; 6; 4; 1|]; 
       [|1; 5; 10; 10; 5; 1|]; 
       [|1; 6; 15; 20; 15; 6; 1|]; 
       [|1; 7; 21; 35; 35; 21; 7; 1|]; 
       [|1; 8; 28; 56; 70; 56; 28; 8; 1|]; |] 

// collect elements from the jagget array
// assigning them to a square array
let numbers =
    let length = (Array.length pascalsTriangle) in
    let temp = Array2D.create 3 length 0 in
    for index = 0 to length - 1 do
        let naturelIndex = index - 1 in
        if naturelIndex >= 0 then
            temp.[0, index] <- pascalsTriangle.[index].[naturelIndex]
            let triangularIndex = index - 2 in
            if triangularIndex >= 0 then
                temp.[1, index] <- pascalsTriangle.[index].[triangularIndex]
        let tetrahedralIndex = index - 3 in
        if tetrahedralIndex >= 0 then
            temp.[2, index] <- pascalsTriangle.[index].[tetrahedralIndex]
    done
    temp

// print the array
printfn "%A\n" numbers


//  Array Comprehensions

// an array of characters
let chars = [| '1' .. '9' |]

// an array of tuples of numbere, squares
let squares =
    [| for x in 1 .. 9 -> x, x*x |]

// print out both arrays
printfn "%A" chars
printfn "%A" squares


// Array Slicing
let arr = [|1; 3; 5; 7; 11; 13|] 
// Get a slice from the array:
let middle = arr[1..4] // [|3; 5; 7; 11|]

// Omit the starting or ending index to start from 
// the beginning or end of the input array:
let start = arr[..3]
let tail = arr[1..]


// multi-dimensional slicing
let ocean = Array2D.create 100 100 0

// create a ship
for i in 3..6 do
    ocean[i, 5] <- 1

// Pull out an area to hit by a 'shell'
let hitArea = ocean[2..5, 2..5]


// We cab see a rectangular by 'radar':
let radarArea = ocean[3..4, *]
