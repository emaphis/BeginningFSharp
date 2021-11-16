//module Literals

// some strings
let message = "Hello
World\r\n\t!"
let dir = @"c:\src\FSharp"

// a byte array
let bytes = "bytesbytesbytes"B

// some numberic types
let xA = 0xFFy
let xB = 0o7777un
let xC = 0b10010UL 

// print the results
let main() =
    printfn "%A" message
    printfn "%A" dir
    printfn "%A" bytes
    printfn "%A" xA
    printfn "%A" xB
    printfn "%A" xC

// call the main function
main()
