// testing Result<'a, 'b>

let divide1 (x:int) (y:int) : int = x / y

let good1 = divide1 10 2
let bad1 = divide1 10 0

// Like the built in.
type Result2<'a, 'b> =
    | Ok2 of 'a
    | Error2 of 'b

let divide2 x y =
    match y with
    | 0 -> Error "Attempt to divide by zero"
    | _ -> Ok (x / y)


let good2 = divide2 10 2
let bad2 = divide2 10 0

/// Custom error to replace string
type DivideError =
    | AttemptedDivideByZero

let divide3 x y =
    match y with
    | 0 -> Error AttemptedDivideByZero
    | _ -> Ok (x / 2)


let good3 = divide3 10 2
let bad3 = divide3 10 0


// Double the result of the division
let calculate x y =
    divide3 x y
    |> Result.map (fun value -> value * 2)

let good4 = calculate 10 2
let bad4 = calculate 10 0
