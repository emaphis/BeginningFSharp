// Capstone 2  - pg. 160


/////////////////////////////////////
// 14.4 Creating a domain  - pg. 162

open System

/// A named customer of the bank
type Customer =
  { Name: string }


/// A Customer's account with the bank
type Account =
  { AccountID: Guid
    Owner: Customer
    Balance: Decimal }


// examples

let cust1 =
   { Name = "Sam"}

let account1 =
  { Owner = cust1
    AccountID = Guid.Empty
    Balance = 100.0M }

let id_1 = account1.AccountID



//////////////////////////////////////
// 14.5 Creating behaviors  - pg 162

// Listing 14.1 Sample function signature for deposit functionality  - pg. 163

/// Deposits an amount into an account
//let deposit (amount: decimal) (account: Account) : Account =
//    { AccountID = Guid.Empty; Owner = { Name = "Sam" }; Balance = 10M }


/// Deposits an amount into an account
let deposit amount account =
    let newBalance = account.Balance + amount
    { account with Balance = newBalance }


/// Withdraw an amount from an account
let withdraw amount account =
    let newBalance = account.Balance - amount
    if (newBalance >= 0M) then
        { account with Balance = newBalance }
    else account



// operations examples
let customer2 = { Name = "Matt" }

let account2 =
  { AccountID = Guid.Empty
    Owner = customer2
    Balance = 100M }


let account2a =   (account2 |> deposit 50M |> withdraw 25 |> deposit 10M)
printfn "Balance should be 135M: %A" account2a.Balance

// over withdraw should return old account
let balance2a = (withdraw 150M account2a).Balance
printfn "Balance should be 135M: %A" balance2a



/////////////////////////////////////////////////
// 14.6 Abstraction and reuse through higher-order functions - pg. 163

// Listing 14.3 Creating pluggable audit functions


open System.IO
let dir = @"C:\tmp\learnfs\capstone2\"

//let outDir = sprintf "%s%s" dir account1.Owner.Name
//let filePsth = sprintf "%s\%s.txt" outDir account1.Owner.Name

/// Auditor that writes to filesystem
let fileSystemAudit account message =
    let owner = account.Owner.Name
    let outDir = sprintf "%s%s" dir owner
    Directory.CreateDirectory(outDir) |> ignore
    let filePath = sprintf "%s\%s.txt" outDir owner
    File.AppendAllLines(filePath, [ message ])


/// Auditor that prints to console
let consoleAudit account message =
    let msg = sprintf "Account %A performed operation '%s', Balance is now $%A " account.AccountID message account.Balance
    printfn "%s" msg



// Listing 14.4 Testing functions through scripts  pg. 164

let customer = { Name = "Isacc" }
let account = { AccountID = Guid.Empty; Owner = customer; Balance = 90M }

// Test out withdraw
let newAccount = account |> withdraw 10M
printfn "Should be 80M: %A" newAccount.Balance

// test out console auditor
consoleAudit account "Testing console audit"
//fileSystemAudit account "Testing file system audit"



// 14.6.1 Adapting code with higher-order functions

// Listing 14.5 Signature for an orchestration of higher-order function  pg. 165

/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs (operationName:string) (auditFn:Account -> string -> unit)
            (operation:decimal -> Account -> Account) (amount:decimal)
            (account:Account) : Account =
    let now = DateTime.UtcNow
    auditFn account (sprintf "%O: Performing a %s operation for £%M..." now operationName amount)
    let newAccount = operation amount account

    let accountIsUnchanged = (newAccount = account)

    if accountIsUnchanged then auditFn account (sprintf "%O: Transaction rejected!" now) 
    else auditFn account (sprintf "%O: Transaction accepted! Balance is now £%M." now newAccount.Balance)

    newAccount


// testing

// Calling the “raw” deposit and withdraw functions
let testAcct1 =
    account
    |> deposit 100M
    |> withdraw 50M

printfn "Should be 140M: %A" testAcct1.Balance


// Creating new “decorated” versions of deposit and withdraw with console
// auditing through currying
let withdrawWithConsoleAudit = auditAs "withdraw" consoleAudit withdraw
let depositWithConsoleAudit = auditAs "deposit" consoleAudit deposit

let withdrawWithFSAudit = auditAs "withdraw" fileSystemAudit withdraw
let depositWithFSAudit = auditAs "deposit" fileSystemAudit deposit


// Calling the “decorated” versions of deposit and withdraw
account
|> depositWithConsoleAudit 100M
|> withdrawWithConsoleAudit 50M


// File System
//account
//|> depositWithFSAudit 100M
//|> withdrawWithFSAudit 50M
