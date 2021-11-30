// Reactive Programming  - pg. 202

module ThreadingDemo

let fibs =
    (1I, 1I) |> Seq.unfold
        (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)))

/// Calculate Fibonacci numbersS
let fib n = Seq.item n fibs
