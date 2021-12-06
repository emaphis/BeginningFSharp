// Lesson 19 - Capstone 3

module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations



let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit


/// Checks whether the command is one of (d)eposit, (w)ithdraw, or e(x)it
let isValidCommand command =
    command = 'd' || command = 'w' || command = 'x'


/// Checks whether the command is the exit command.
let isStopCommand commamd = commamd = 'x'


/// Takes in a command and converts it to a tuple of the command and also an amount
let getAmount command =
    Console.WriteLine()
    Console.Write "Enter Amount: "
    command, Console.ReadLine() |> Decimal.Parse


/// Takes in an account and a (command, amount) tuple. It should then apply
/// the appropriate action on the account and return the new account back out again
let processCommand account (command, amount) =
    let account =
        if   command = 'd' then depositWithAudit amount account
        elif command = 'w' then withdrawWithAudit  amount account
        else account
    printfn "Current balance is $%M" account.Balance
    account


let commands = seq {
    while true do
        Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
        yield Console.ReadKey().KeyChar
        Console.WriteLine() }



[<EntryPoint>]
let main _ =
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
    let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit

    let openingAccount = { Owner = { Name = name }; Balance = 0M; AccountId = Guid.Empty } 

    printfn "Current balance is $%M" openingAccount.Balance

    let closingAccount =
        commands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmount
        |> Seq.fold processCommand openingAccount

 
    printfn ""
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0
