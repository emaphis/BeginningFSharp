// QuotedCode

module QuotedCode


// Quote the integer one:
let quotedInt = <@ 1 @>

// Print the quoted integer:
printfn "%A" quotedInt


// The following example defines an identifier and uses it in a quotation: 

// define a identifier n
let n = 1
// quote the identifier
let quotedId = <@ n @>

// print the quoted identifier
printfn "%A" quotedId


// a function

// define a function
let inc x = x = x + 1
// quote the function applied to a value
let quotedFun = <@ inc 1 @>

// print the quotation
printfn "%A" quotedFun


// The next example shows how to apply an operator to two values

open Microsoft.FSharp.Quotations

// quote an operator applied to two operands
let quotedOp = <@ 1 + 1 @>

printfn "%A" quotedOp


// quote an anonymous function
let quotedAnonFun = <@ fun x -> x + 1 @>

// print the quotation 
printfn "%A" quotedAnonFun


// Quotations are simply a discriminated union of Microsoft.FSharp.Quotations.Expr ;

open Microsoft.FSharp.Quotations.Patterns 

// a function to interpret very simple quotations
let interpretInt exp =
    match exp with
    | Value (x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int)
    | _ -> printfn "not an int"


// test the function 
interpretInt <@ 1 @> 
interpretInt <@ 1 + 1 @>


open Microsoft.FSharp.Quotations.Patterns 
open Microsoft.FSharp.Quotations.DerivedPatterns

// a function to interpret very simple quotations 
let rec interpret exp = 
    match exp with 
    | Value (x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int) 
    | SpecificCall <@ (+) @> (_, _, [l;r]) -> interpret l 
                                              printfn "+" 
                                              interpret r 
    | _ -> printfn "not supported"  


// test the function 
interpret <@ 1 @> 
interpret <@ 1 + 1 @> 


// this defines a function and quotes it 
[<ReflectedDefinition>] 
let inc' n = n + 1 

// fetch the quoted defintion 
let incQuote = <@@ inc' @@> 

// print the quotation 
printfn "%A" incQuote 
// use the function 
printfn "inc 1: %i" (inc' 1) 
