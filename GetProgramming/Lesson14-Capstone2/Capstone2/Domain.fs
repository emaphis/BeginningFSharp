// 14.7 Writing a console application  - pg. 167

module Capstone2.Domain

open System


/// A named customer of the bank
type Customer =
  { Name: string }


/// A Customer's account with the bank
type Account =
  { AccountID: Guid
    Owner: Customer
    Balance: Decimal }
