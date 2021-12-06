module Capstone3.FileRepository
// Lesson 19 - Capstone 3

open Capstone3.Domain
open System.IO
open System

let private accountsPath =
    let path = @"C:\temp\accounts"
    Directory.CreateDirectory path |> ignore
    path

let private findAccountFolder owner =
    let folders = Directory.EnumerateDirectories(accountsPath, sprintf "%s_*" owner)
    if Seq.isEmpty folders then ""
    else
        let folder = Seq.head folders
        DirectoryInfo(folder).Name

let private buildPath(owner, accountId:Guid) = sprintf @"%s\%s_%O" accountsPath owner accountId

/// Logs to the file system
let writeTransaction accountId owner transaction =
    let path = buildPath(owner, accountId)
    path |> Directory.CreateDirectory |> ignore
    let filePath = sprintf "%s/%d.txt" path (DateTime.UtcNow.ToFileTimeUtc())
    let line = Transaction.serialized transaction
    File.WriteAllText(filePath, line)
