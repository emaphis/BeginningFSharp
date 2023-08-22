﻿module StringManipulation

    /// Strings use double quotes.
    let string1 = "Hello"
    let string2 = "world"

    /// Strings can also use '@' to create verbatim string literal.
    /// This will ignore exape characters such as '\', '\n', '\t', etc.
    let string3 = @"C:\Program Files\"

    /// String literals can also use tripple-quotes.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// String concatenation is normally done with the '+' operator.
    let helloWorld = string1 + " " + string2

    // This line uses '%s' to print a string value. This is type-safe.
    printfn "%s" helloWorld

    /// Substrings use the indexer notation.  This line extracts the first 7
    /// characters as a substring.
    /// Note that like many languages, Strings are zero-indexed in F#
    let substring = helloWorld[0..6]
    printfn $"{substring}"
