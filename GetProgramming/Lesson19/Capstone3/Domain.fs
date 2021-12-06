// Lesson 19 - Capstone 3

namespace Capstone3.Domain

open System

type Customer = { Name : string }
type Account = { AccountId : Guid; Owner : Customer; Balance : decimal }
type Transaction = { Amount : decimal; Operation : string; Timestamp : DateTime; Accepted : bool }


module Transaction =
    let serialized transaction =
        sprintf "%O***%s***%M***%b"
            transaction.Timestamp
            transaction.Operation
            transaction.Amount
            transaction.Accepted
