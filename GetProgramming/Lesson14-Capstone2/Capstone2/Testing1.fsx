/////////////////////////////////////////////////////////
// 14.8 Referencing files from scripts - pg. 169

// Listing 14.8 Accessing .fs files from a script

#load "Domain.fs"
#load "Operations.fs"
#load "Auditing.fs"

open Capstone2.Operations
open Capstone2.Domain
open Capstone2.Auditing
open System


let withdraw = withdraw |> auditAs "withdraw" consoleAudit
let deposit = deposit |> auditAs "deposit" consoleAudit

let customer = { Name = "Isaac" }
let account = { AccountID = Guid.NewGuid(); Owner = customer; Balance = 90M }


account
|> withdraw 50M
|> deposit 50M
|> deposit 100M
|> withdraw 50M
|> withdraw 350M

account
