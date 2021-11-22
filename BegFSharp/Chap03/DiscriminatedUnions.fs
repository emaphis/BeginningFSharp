// Union or Sum Types - Discriminated Unions  pg. 

module DiscriminatedUnions

// discriminated union (DU) to represent various measures of volume:
type Volume =
    | Liter of float
    | UsPint of float
    | ImperialPint of float

//Create instances of each type of volume:
let vol1 = Liter 2.5 
let vol2 = UsPint 2.5
let vol3 = ImperialPint (2.5)


// union type using field labels
type Shape =
    | Square of side:float
    | Rectangle of width:float * height:float
    | Circle of radius:float


// Create an instance of union type withoug using the field label
let sq = Square 1.2
// Create an instance of a union type using the field label
let sq2 = Square(side = 1.2)
// Create an instance of a union type using multiple field labels
// and assigning the field out-of-order
let rect3 = Rectangle(height = 3.4, width = 1.2)


// deconstruct with pattern matching

// type representing volumes 
type Volume2 =
    | Liter2 of float
    | UsPint2 of float
    | ImperialPint2 of float

let vol4 = Liter2 2.5 
let vol5 = UsPint2 2.5
let vol6 = ImperialPint2 (2.5)

// some functions to convert between volumes
let convertVolumeToLiter x =
    match x with
    | Liter2 x  -> x
    | UsPint2 x -> x * 0.473
    | ImperialPint2 x -> x * 0.586

let convertVolumeUSPint x =
    match x with
    | Liter2 x  -> x * 2.113
    | UsPint2 x -> x
    | ImperialPint2 x -> x * 1.201

let convertVolumeImperialPint x =
    match x with
    | Liter2 x  -> x * 1.760
    | UsPint2 x -> x * 0.833
    | ImperialPint2 x -> x

// a function to print a volume
let printVolumes x =
    printfn "Volume in liters = %f, 
in us pints = %f, 
in imperial pints = %f" 
        (convertVolumeToLiter x) 
        (convertVolumeUSPint x) 
        (convertVolumeImperialPint x)

// print the results
printVolumes vol4
printVolumes vol5
printVolumes vol6


//  Type Definitions with Type Parameters 

// you place the type being parameterized between the keyword type and
// the name of the type,

// definition of a binary tree 
type 'a BinaryTree =
    | BinaryNode of 'a BinaryTree * 'a BinaryTree
    | BinaryValue of 'a

// create an instance of a binary tree 
let tree1 =
    BinaryNode (
        BinaryNode ( BinaryValue 1, BinaryValue 2 ),
        BinaryNode ( BinaryValue 3, BinaryValue 4 ) )


// you place the types being parameterized in angle brackets after the type name,

// definition of a tree 
type Tree<'a> =
    | Node of Tree<'a> list
    | Value of 'a

// create an instance of a tree 
let tree2 =
    Node( [ Node( [ Value "one"; Value "Two" ] );
        Node ( [ Value "three"; Value "four" ] ) ] )


// function to print the binary tree 
let rec printBinaryTreeValues x = 
    match x with 
    | BinaryNode (node1, node2) -> 
        printBinaryTreeValues node1 
        printBinaryTreeValues node2 
    | BinaryValue x -> 
        printf "%A, " x 

// function to print the tree 
let rec printTreeValues x = 
    match x with 
    | Node l -> List.iter printTreeValues l 
    | Value x -> 
        printf "%A, " x 


// print the results 
printBinaryTreeValues tree1 
printfn "" 
printTreeValues tree2
