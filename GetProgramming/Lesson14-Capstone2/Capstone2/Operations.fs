// 14.7 Writing a console application  - pg. 167

module Capstone2.Operations

open Capstone2.Domain
open System


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



/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs operationName auditFn operation amount account =
    let now = DateTime.UtcNow
    auditFn account (sprintf "%O: Performing a %s operation for $%M..." now operationName amount)
    let newAccount = operation amount account

    let accountIsUnchanged = (newAccount = account)

    if accountIsUnchanged then auditFn account (sprintf "%O: Transaction rejected!" now) 
    else auditFn account (sprintf "%O: Transaction accepted! Balance is now £%M." now newAccount.Balance)

    newAccount
