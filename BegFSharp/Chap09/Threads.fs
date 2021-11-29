// Threads, Memory, Locking, and Blocking  - pg. 198

module Threads

open System.Threading


/// explicit threading
let main() =
    // Create a new thread passing it a lambda function:
    let thread = new Thread( fun () ->
        // Print a message on the newly created thread
        printfn "Created thread: %i" Thread.CurrentThread.ManagedThreadId)

    // Start the new thread
    thread.Start()

    // Print a message onthe original thread
    printfn "Original thread: %i" Thread.CurrentThread.ManagedThreadId

    // Wait for the created in exit:
    thread.Join()


do main()

