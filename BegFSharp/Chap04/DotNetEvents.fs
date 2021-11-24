// Working with Events from .NET Libraries  pg. 85

module DotNetEvents

open System.Timers

let timedMessages() =
    // Define the timer:
    let timer = new Timer(Interval = 3000.0,
                          Enabled = true)

    // A counter to hold the current message:
    let mutable messageNo = 0

    // The messages to be shown:
    let messages = [ "bet"; "this"; "gets";
                     "really"; "annoying";
                     "very"; "quickly" ]

    // Add an event to the timer:
    timer.Elapsed.Add(fun _ ->
        // Print a message:
        printfn "%s" messages.[messageNo]
        messageNo <- messageNo + 1
        if messageNo = messages.Length then
            timer.Enabled <- false)

timedMessages()
