// Organizing code without classes 
// Lesson 12  - pg. 138

// 12.1 Using namespaces and modules pg. 130

// 12.1.1 Namespaces in F#

let file = @"C:\tmp\learnfs\foo.txt"

open System.IO
let lines = File.ReadAllLines file

printfn "%A" lines

