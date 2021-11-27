// PropertiesAndIndexers

module PropertiesAndIndexers

// a class with properties
type Properties() =
    let mutable rand = new System.Random()

    // a property definition
    member x.MyProp
        with get () = rand.Next()
        and set y = rand <- new System.Random(y)  // set the seed


// create a new instance of out class
let prop = new Properties()

// run som tests of the class
prop.MyProp <- 12
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp


// You can also declare abstract properties

// an intefacw with an abstract property
type IAbstractProperties =
    abstract MyProp: int
        with get, set

// a class that implements out interface
type ConcreteProperties() =
    let mutable rand = new System.Random()

    interface IAbstractProperties with
        member x.MyProp
            with get()  = rand.Next()
            and set(y) = rand <- new System.Random(y)
    

// create a new instance of out class
let prop2 = new ConcreteProperties()

// run som tests of the class  - Ugly
(prop2 :> IAbstractProperties).MyProp <- 12
printfn "%d" (prop2 :> IAbstractProperties).MyProp
printfn "%d" (prop2 :> IAbstractProperties).MyProp
printfn "%d" (prop2 :> IAbstractProperties).MyProp


// Indexers

// a class with indexer
type Indexers(vals: string[]) =
    // a normal indexer
    member x.Item
        with get y = vals[y]
        and  set y z = vals[y] <- z
    
    // an indexer with an unusual name
    member x.MyString
        with get y = vals[y]
        and  set y z = vals[y] <- z

// create a new instance of the indexer class
let index = new Indexers [| "One"; "Two"; "Three"; "Four" |]

// test the set indexers
index[0] <- "Five"
index.Item(2) <- "Six"
index.MyString(3) <- "Seven"

// test the get indexers
printfn "%s" index[0]
printfn "%s" (index.Item(1))
printfn "%s" (index.MyString(2))
printfn "%s" (index.MyString(3))
