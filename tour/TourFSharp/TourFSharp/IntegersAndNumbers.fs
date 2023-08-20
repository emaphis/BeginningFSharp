module IntegersAndNumbers

    /// This is a sample integer.
    let sampleInteger = 176

    /// This is a sample floating point number.
    let sampleDouble = 4.1

    /// This computed a new number by some arithmetic.  Numberic types are
    /// converted using functions 'int', 'double' and so on.
    let sampleInteger2 = (sampleInteger/4 + 5 - 8) + int sampleDouble

    /// This is a list of numbers from 0 to 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// This is a list of all tuples containing all the numbers from 0 to 99
    /// and their squares.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // The next line prints a list that inclues tuples, using an interpolated
    // string
    printfn $"The table of squares from 0 to 99 is:\n{sampleTableOfSquares}"
