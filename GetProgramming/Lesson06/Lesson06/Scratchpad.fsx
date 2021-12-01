// Working with immutable data  - pg. 70


//////////////////////////////////
// 6.2 Being explicit about mutation  - pg. 72

// 6.2.1 Mutablility basics in F#


// Listing 6.1 Creating immutable values in F#  - pg. 72
let name = "issac"
name = "kate"  // lol boolean

// Listing 6.2 Trying to mutate an immutable value  - pg. 73
//name <- "kate"
// error FS0027: This value is not mutable. Consider using the mutable keyword,


// Listing 6.3 Creating a mutable variable  - pg. 73.
let mutable name1 = "issac"
name1 <- "kate"


// 6.2.2 Working with mutable objects  - pg. 73

// Listing 6.4 Working with mutable objects
// see WindowsForms project



////////////////////////////////////////////////////////
// 6.3 Modeling state  - pg. 75

// See Petrol.fsx








