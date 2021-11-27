// Namespace 4  - pg.128
// Opening Namespace and Moduels

module Namespaces4

// Call a method using its full name:
System.Console.WriteLine("Hello world")


// Open a namespace and call a method using
// its short name:
open System

Console.WriteLine("Hello world 2")


// Open a namespace to a certain level
open System.Collections

// // Call a method using the rest of the namespace:
// create an instance of a dictionary
let wordCountDict =
    new Generic.Dictionary<string, int>()
