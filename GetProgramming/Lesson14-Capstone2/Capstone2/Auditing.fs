// 14.7 Writing a console application  - pg. 167

module Capstone2.Auditing

open Capstone2.Domain

open System.IO


/// Auditor that prints to console
let consoleAudit account message =
    let msg = sprintf "Account %A performed operation '%s', Balance is now $%A " account.AccountID message account.Balance
    printfn "%s" msg


/// hardcoded path to log files
let dir = @"C:\tmp\learnfs\capstone2\"


/// Auditor that writes to filesystem
let fileSystemAudit account message =
    let owner = account.Owner.Name
    let outDir = sprintf "%s%s" dir owner
    Directory.CreateDirectory(outDir) |> ignore
    let filePath = sprintf "%s\%s.txt" outDir owner
    File.AppendAllLines(filePath, [ message ])
