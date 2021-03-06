// Exceptions and Exception Handling  pg. 60


module Exceptions


// define an exception type
exception WrongSecond of int

// list of prime numbers
let primes =
    [ 2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47; 53; 59 ]


// function to test if current second is prime
let testSecond() =
    try
        let currentSecond = System.DateTime.Now.Second in
        // test if current second is in the list of primes
        if List.exists (fun x -> x = currentSecond) primes then
            // use the failwith function to raise an exception
            failwith "A prime second"
        else
            // raise the WrongSecond exception
            raise (WrongSecond currentSecond)
    with
    // catch the wron second exception
    WrongSecond x ->
        printf "The current was %i, which is not prime" x


// call the functon
testSecond()

// finally

// function to write to a file 
let writeToFile() = 
    // open a file 
    let file = System.IO.File.CreateText(@"Chap03//test.txt") 
    try 
        // write to it 
        file.WriteLine("Hello F# users") 
    finally 
        // close the file, this will happen even if 
        // an exception occurs writing to the file 
        file.Dispose() 


// call the function 
writeToFile()
