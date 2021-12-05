// Now you try  - pg. 201


open System
open System.IO

let path = @"C:\"

let listDirectories path =
    let now = DateTime.UtcNow
    Directory.EnumerateDirectories(path)
    |> Seq.map (fun dir -> DirectoryInfo(dir))
    |> Seq.map (fun dirInfo ->
        (dirInfo.Name, dirInfo.CreationTimeUtc))
    |> Map.ofSeq
    |> Map.map (fun _ time ->(now - time).Days)



let test2(path) =
    let fileSeq = listDirectories  path
    for pair in fileSeq do
        printfn "%-25s %3i" pair.Key pair.Value

test2(path)
