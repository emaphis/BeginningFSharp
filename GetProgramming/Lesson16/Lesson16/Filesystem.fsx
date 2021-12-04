// Try this  - pg. 196

open System.IO

let folderPath = @"C:\src"


/// Represents a directory path and a list of files that belong to that directory
type DirInfo = string * FileInfo list


/// given a path get a list of fileInfo in directory
let getFileList path =
    Directory.GetFiles(path)
    |> Array.toList
    |> List.map (fun file -> FileInfo(file))


/// get a list of files (DirInfo records) on a given path
/// list of files should be grouped by dirname
let getSubDirs (path : string) : DirInfo list =
    Directory.GetDirectories path   // get subdirectories of dir
    |> Array.toList
    |> List.collect getFileList     // get list of files in directories
    |> List.groupBy (fun file -> file.DirectoryName)


/// Parse path to a Directory name
let getDirName (path : string)  =
    let parts = path.Split('\\')
    parts.[parts.Length - 1]


////////////////////////////////////////////
/// Part 1

type DirRecord1 =
    { Name: string
      Size: int }

let createDirRecord1 (dirInfo : DirInfo) =
    let path, fileList = dirInfo
    { Name = getDirName path
      Size = fileList |> List.sumBy (fun file -> int(file.Length)) }

let getDirSizes path =
    getSubDirs path
    |> List.map (fun dirInfo -> createDirRecord1 dirInfo)
    |> List.sortByDescending (fun dir -> dir.Size)


getDirSizes folderPath


///////////////////////////////////////////////////////////
/// Part 2
type DirRecord2 =
    { Name: string
      Size: int
      NumFiles: int
      AvgSize: float
      Extensions: string list }

let createDirRecord2 (dirInfo : DirInfo) =
    let path, fileList = dirInfo
    let size = fileList |> List.sumBy (fun file -> int(file.Length))
    let numFiles = fileList.Length
    { Name = getDirName path
      Size = size
      NumFiles = numFiles
      AvgSize = float(size) / float(numFiles)
      Extensions =
       fileList
       |> List.map (fun file -> file.Extension)
       |> List.distinct }

let getDirInfo path =
    getSubDirs path
    |> List.map (fun dirInfo -> createDirRecord2 dirInfo)
    |> List.sortByDescending (fun dir -> dir.Size)


getDirInfo folderPath