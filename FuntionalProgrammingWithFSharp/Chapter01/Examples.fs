module Examples

// 1.1 Values, types, identifiers and declarations  - pg. 1

let num1 = 2*3 + 4
printfn "num1 = %d" num1


let price = 125

let extension = price * 20

let b1 = extension / price  = 20

printfn "%d %d %b" price extension b1


// 1.2 Simple function declarations  - pg. 2

// area function: circleArea(r) = π*r^2.

printfn "%A" System.Math.PI
// 3.141592654

let circleArea r = System.Math.PI * r * r

let cir1 =  circleArea 1.0
let cir2 = circleArea (2.0)

printfn "c1 = %f, c2 = %f" cir1 cir2


// Comments  - pg. 3

(* Area of circle with ratdius r *)
let circleArea1 r = System.Math.PI * r * r

// Area of circle with radius r
let circleArea2 r = System.Math.PI * r * r


// 1.3 Anonymous functions. Function expressions  pg. 4

let circleArea3 = fun r -> System.Math.PI * r * r
let num2 = circleArea3 2.0

// Function expressions with patterns

let daysOfMonth'  =
    function
    | 2 -> 28 // February
    | 4 -> 30 // April
    | 6 -> 30 // June
    | 9 -> 30 // September
    | 11 -> 30 // November
    | _ -> 31  // All other months


let daysOfMonth = function
    | 2        -> 28  // February
    | 4|6|9|11 -> 30  // April, June, September, November
    | _        -> 31  // All other months

daysOfMonth 3

daysOfMonth 9


// 1.4 Recursion  pg. 6

let rec fact =
    function
    | 0 -> 1
    | n -> n * fact(n-1)

fact 16


// 1.5 Pairs  pg. 11


