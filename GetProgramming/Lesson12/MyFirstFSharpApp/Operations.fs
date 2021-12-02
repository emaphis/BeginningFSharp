// Now you try  - pg. 145

// Listing 12.3 Declaring a module that references a namespace

module Operations

open Domain

let getInitials customer =
    customer.FirstName[0], customer.LastName[0]

let isOlderThan age customer =
    customer.Age > age

