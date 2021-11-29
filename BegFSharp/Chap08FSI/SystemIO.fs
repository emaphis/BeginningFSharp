//  The System.IO Namespace  - pg. 170

module SystemIO

open System.IO

// list all the files in the root of the C: drive
let files = Directory.GetFiles(@"c:\")

// Write out various information about the file
for filepath in files do
    let file = new FileInfo(filepath)
    printfn "%s\t%d\t%O"
        file.Name
        file.Length
        file.CreationTime


let dir = Directory.GetCurrentDirectory()

open System.IO

//test.csv: 
//Apples,12,25 
//Oranges,12,25 
//Bananas,12,25 

// open a test file and print the contents
let readFile() =
    let lines = File.ReadAllLines(__SOURCE_DIRECTORY__ + "/test.csv") 
    
    let printLine (line: string) =
        let items = line.Split([| ',' |])
        printfn "%O %O %O"
            items[0]
            items[1]
            items[2]

    Seq.iter printLine lines


readFile()
