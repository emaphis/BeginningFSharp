// Using Objects and Instance Members from .NET Libraries  pg. 82 

module DotNetObjectsAndInstanceMembers

open System.IO

let dir = Directory.GetCurrentDirectory()

// create a FileInfo object
// ('new' is optional)
let file = new FileInfo("test.txt")

let bool1 = file.Exists

// test if the files exists,
// if not creat a file
if not file.Exists then
    use stream = file.CreateText()
    stream.WriteLine("hello world")
    file.Attributes <- FileAttributes.ReadOnly

// print the full file name
printfn "%s" file.FullName


// setting attributes inconstructors

// File name to test:
let filename = "test.txt"

// bind file to an option type, depending on whether
// the file exists or not
let file2 =
    if File.Exists(filename) then
        Some(new FileInfo(filename, Attributes = FileAttributes.ReadOnly))
    else
        None


open System

// an integer list
let intList =
    let temp = new ResizeArray<int>()
    temp.AddRange([| 1; 2; 3; 4 |])
    temp

// print each int using the ForEach method
intList.ForEach( fun i -> Console.WriteLine(i) )


// how to wrap a method that take a delgate with an F# function
let findIndex f arr = Array.FindIndex(arr, new Predicate<_>(f))

// define an array litteral
let rhyme = [| "The"; "cat"; "sat"; "on"; "the"; "mat"  |]

// print index of the first word ending in 'at'
printfn "First word ending in 'at' in the array: %i"
    (rhyme |> findIndex (fun w -> w.EndsWith("at")))
