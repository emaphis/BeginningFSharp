// Lesson 19 - Capstone 3
// pg. 129


#load "Domain.fs"
#load "Operations.fs"

open Capstone3.Operations
open Capstone3.Domain
open System
open System.IO


//////////////////////////////////////////////
// 19.2 Removing mutability


// Now you try  - pg. 222

/// Checks whether the command is one of (d)eposit, (w)ithdraw, or e(x)it
let isValidCommand command =
    command = 'd' || command = 'w' || command = 'x'


/// Checks whether the command is the exit command.
let isStopCommand commamd = commamd = 'x'


/// Takes in a command and converts it to a tuple of the command and also an amount
let getAmount (command:char) =
    if command = 'd' then command, 50M
    elif command = 'w' then command, 25M
    else command, 0M

;;
/// Takes in an account and a (command, amount) tuple. It should then apply
/// the appropriate action on the account and return the new account back out again
let processCommand account (command:char, amount) =
    if   command = 'd' then deposit amount account
    elif command = 'w' then withdraw amount account
    else account


// Listing 19.1 Creating a functional pipeline for commands  - pg. 221

let openingAccount =
    { Owner = { Name = "Isaac" }; Balance = 0M; AccountId = Guid.Empty }


let account =
    let commands = [ 'd'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w' ]
    commands
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount

