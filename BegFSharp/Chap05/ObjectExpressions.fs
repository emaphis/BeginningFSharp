// ObjectExpressions  - pg. 100

module ObjectExpressions

open System
open System.Collections.Generic 

// a comparator that will compare strings in their reversed order
let comparer =
    { new IComparer<string>
      with
        member x.Compare(s1, s2) =
            // functionto reverse a string
            let rev (s: string) =
                new String(Array.rev (s.ToCharArray()))
            // reverse 1st string
            let reversed = rev s1
            // compare reversed string to 2nd strngs reversed
            reversed.CompareTo(rev s2) }


// Eurovision winners in a random order
let winners =
    [| "Sandie Shaw"; "Bucks Fizz"; "Dana International";
       "Abba"; "Lodrdi" |]


// print the winners
printfn "%A" winners
// sort the winners
Array.Sort(winners, comparer)
// print the winners again
printfn "%A" winners
