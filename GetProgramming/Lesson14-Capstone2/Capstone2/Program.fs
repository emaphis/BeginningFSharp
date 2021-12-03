// 14.7 Writing a console application  - pg. 167
// The Main App - 14.7.1 Writing the program
// Run with custmer_name and beginning_balance

open System
open Capstone2.Domain
open Capstone2.Operations
//open Auditing


//////////////////////////////////
// User interface functions

/// Creat an account from an array of name and balance
/// Account ID is created automatically
let getAccountInfo(argv: string[]) =
    let customer = { Name = argv.[0] }
    let balance = decimal(argv.[1])
    { AccountID = Guid.NewGuid(); Owner = customer; Balance = balance;  }

/// Get next customer acction
let getAction(account) =
    printfn "\nCurrent balance is $%M" account.Balance
    printfn "(d)eposit, (w)ithdraw or e(x)it"
    Console.ReadLine()

/// Reaad acction ammount
let getAmount() =
    printf "\nAmount: "
    decimal(Console.ReadLine())



// Auditing specializations
let withdrawC = withdraw |> auditAs "withdraw" Capstone2.Auditing.consoleAudit
let depositC = deposit |> auditAs "deposit" Capstone2.Auditing.consoleAudit

s
/// Main application entry point
[<EntryPoint>]
let main argv =
    let mutable account = getAccountInfo(argv)

    while true do
        let action = getAction(account)
        if action = "x" then Environment.Exit 0
        let amount = getAmount()
        
        account <-
            if action = "d" then account |> depositC amount
            elif action = "w" then account |> withdrawC amount
            else account

    printfn "Final amount: $%O" account.Balance

    0 // return an integer exit code   
