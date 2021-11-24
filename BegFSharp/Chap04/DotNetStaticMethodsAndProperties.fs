// Calling Static Methods and Properties from .NET Libraries  pg. 80

module DotNetStaticMethodsAndProperties

open System.IO

let dir = Directory.GetCurrentDirectory()

// test whether a file test.txt" exist
if File.Exists(@"test.txt") then
    printfn "The file \"test.txt\" is present"
else
    printfn "The file \"test.txt\" does not exist"


// You can treat any .NET mehod as a F# function

// list of files to test 
let files1 = [ "test1.txt"; "test2.txt"; "test3.txt" ]

// test if each file exists/
let results1 = List.map File.Exists files1

// print the results
printfn "%A" results1


// NET methods behave as if they take tuples as arguments, you can also treat a method that has 
// more than one argument as a value.

// list of files names and desired contents 
let files2 = [ "test1.bin", [| 0uy |]; 
               "test2.bin", [| 1uy |]; 
               "test3.bin", [| 1uy; 2uy |]] 

// iterate over the list of files creating each one 
List.iter File.WriteAllBytes files2


// currying - wrap the method to curry

// import the File.Create function 
let create size name = 
    File.Create(name, size, FileOptions.Encrypted)

// list of files to be created 
let names = [ "test1.bin"; "test2.bin"; "test3.bin" ]

// open the files create a list of streams 
let streams = List.map (create 1024) names


// named arguemnts

// open a file using named arguemtns
let file = File.Open(path = "test.txt",
                     mode = FileMode.Append,
                     access = FileAccess.Write,
                     share = FileShare.None)

// now close it.
file.Close()
