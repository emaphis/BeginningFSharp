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



// examples
let customer2 = { Name = "Matt" }

let account2 =
  { AccountID = Guid.Empty
    Owner = customer2
    Balance = 100M }


let balance2 =   (account2 |> deposit 50M |> withdraw 25 |> deposit 10M).Balance
printf "Balance should be 135M: %A" balance2

