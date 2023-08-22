module SingleCaseDiscriminatedUnions

    // Single-case DUs are often used for domain modeling.  This can buy you extra type safety.
    // over primative types such as strings and ints.
    //
    // Single-case DUs cannot be implicitly converted to or from the type they wrap.
    // For example, a function which takes and Address cannont accept a string as
    // that input, or vice versa.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // You can easily instantiate a single-case DU as follows.
    let address1 = Address "111 Alf Way"
    let name1 = Name "Alf"
    let ssn1 = SSN 1234567890

    /// When you need the value, you can unwrap the underlying value with a simple function.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    /// Printing single-case DUs is simple with unwrapping functions.
    printfn $"Address: {address1 |> unwrapAddress}, Name: {name1 |> unwrapName}, and SSN: {ssn1 |> unwrapSSN}"

