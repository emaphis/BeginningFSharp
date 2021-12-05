// Lesson 19 - Capstone 3

module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations



/// Checks whether the command is one of (d)eposit, (w)ithdraw, or e(x)it
let isValidCommand command =
    command = 'd' || command = 'w' || command = 'x'


/// Checks whether the command is the exit command.
let isStopCommand commamd = commamd = 'x'


/// Takes in a command and converts it to a tuple of the command and also an amount
let getAmount command =
    if command = 'd' then command, 50M
    elif command = 'w' then command, 25M
    else command, 0M

/// Takes in an account and a (command, amount) tuple. It should then apply
/// the appropriate action on the account and return the new account back out again
let processCommand account (command, amount) =
    if   command = 'd' then deposit amount account
    elif command = 'w' then withdraw amount account
    else account




[<EntryPoint>]
let main _ =
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
    let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit

    let openingAccount = { Owner = { Name = name }; Balance = 0M; AccountId = Guid.Empty } 

    let closingAccount =
        // Fill in the main loop here...
        let commands = [ 'd'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w' ]
        commands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmount
        |> Seq.fold processCommand openingAccount
        //openingAccount

    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0
