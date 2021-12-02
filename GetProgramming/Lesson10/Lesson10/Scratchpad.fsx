// Shaping Data with Records
// pg. 111


/////////////////////////////////////
// 10.1 POCOs done right: records in F#  - pg.114


// 10.1.1 Record basics

// Listing 10.4 Immutable and structural equality record in F#
type Address =
    { Street: string
      Town: string
      City: string }


// 10.1.2 Creating records  - pg. 115

// Listing 10.5 Constructing a nested record in F#
type Customer =
     { Forename : string
       Surname : string
       Age : int
       Address : Address
       EmailAddress : string }

let customer1 =
     { Forename = "Joe"
       Surname = "Bloggs"
       Age = 30
       Address =
        { Street = "The Street"
          Town = "The Town"
          City = "The City" }
       EmailAddress = "joe@bloggs.com" }


let city1 = customer1.Address.City
printfn "%s" city1



// Now you try  - pg. 117

type Car =
    { Make: string
      Manufacturer: string
      Engine: string
      Size: float
      NumberOfDoors: int }

let buick1 =
    { Make = "Reagal"
      Manufacturer = "Buick"
      Engine = "V8" 
      Size = 5.6
      NumberOfDoors = 2}

let size1 = buick1.Size
let make1 = buick1.Make

printfn "%s %f" make1 size1


////////////////////////////////////////////
// 10.2 Doing more with records  - pg. 117

// 10.2.1 Type inference with records

// Listing 10.6 Providing explicit types for constructing records

// Explicitly declaring the type of the address valueS
let address2 : Address = 
     { Street = "The Street"
       Town = "The Town"
       City = "The City" }


// Explicitly declaring the type that the Street 
// field belongs to
let addressExplicit =
 { Address.Street = "The Street"
   Town = "The Town"
   City = "The City" }


// Figure 10.4  Type inference correcty identifies the tupe of the address
// object
let printAddress address =
    printfn "Address is %s, %s"
        address.Street
        address.City

printAddress address2


// 10.2.2 Working with immutable records  - pg. 119

// Listing 10.7 Copy-and-update record syntax
let updatedCustomer1 =
    { customer1 with
        Age = 31
        EmailAddress = "joe@bloggs.co.uk"  }


// 10.2.3 Equality checking  - pg. 120

// Listing 10.8 Comparing two records in F#

let isSameAddress = (address2 = addressExplicit)

printfn "%b" isSameAddress


// Now you try  - pg. 120

// 1 Define a record type, such as the Address type shown earlier.
type Address1 =
  { Home: string
    City: string
    Zip: int }

// 2 Create two instances of the record that have the same values.
let addr1 =
  { Home = "111 Fifth Ave."
    City = "Painesville"
    Zip = 44077 }

let addr2 =
  { Home = "111 Fifth Ave."
    City = "Painesville"
    Zip = 44077 }    

// 3 Compare the two objects by using =, .Equals, and System.Object.ReferenceEquals.
let b1 = (addr1 = addr2)
let b2 = addr1.Equals(addr2)
let b3 = System.Object.ReferenceEquals(addr1, addr2)

// 4 What are the results of all of them? Why?
printfn "%b %b %b" b1 b2 b3
// structural equality vs. reference equality

// 5 Create a function that takes in a customer and, using copy-and-update syntax,
//   sets the customer’s Age to a random number between 18 and 45.

// 6 The function should then print the customer’s original and new age, before 
//   returning the updated customer record

/// Update customer with a reandom age
let updateCustomerAge customer =
    let newAge = System.Random().Next(27) + 18
    printfn "Old Age = %i, New Age = %i" customer.Age newAge
    { customer with
        Customer.Age = newAge }

let customer2 = updateCustomerAge customer1
let customer3 = updateCustomerAge customer2
let customer4 = updateCustomerAge customer3


/// 10.3 Tips and tricks with records  - pg. 121

// 10.3.1 Refactoring


// 10.3.2  Shadowing  - pg 122
// F# allows you to reuse existing named bindings.
// requires do notation for updating identity  - see page 1125
do
  let myHome = { Street = "The Street"; Town = "The Town"; City = "The City" }
  let myHome = { myHome with City = "The Other City" }
  let myHome = { myHome with City = "The Third City" }
  printAddress myHome


// FSI repl has an implied `do`


// Try this  - pg 124.
// 1 Model the Car example from lesson 6, but use records to model the state of the Car.
// see Petrol.fsx

