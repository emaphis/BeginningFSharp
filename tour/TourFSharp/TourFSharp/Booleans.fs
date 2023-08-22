module Booleans

    /// Booleans valuea are 'true' and 'false'
    let boolean1 = true
    let boolean2 = false

    /// Operators on booleans are 'no', '&&' and '||'
    let boolean3 = not boolean1 && (boolean2 || false)

    // This line used '%b' to print  a boolean value. This is type-safe.
    printfn $"The expression 'not boolean` && (boolean2 || false)' is %b{boolean3}"

