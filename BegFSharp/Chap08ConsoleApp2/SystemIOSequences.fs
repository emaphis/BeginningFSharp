// Using Sequences with System.IO  - pg. 172

module SystemIOSequences

open System
open System.IO
open System.Diagnostics


let wordCount() =
    // Get the "Private Bytes" performance counter
    let proc = Process.GetCurrentProcess()
    let counter = new PerformanceCounter("Process", 
                                         "Private Bytes", 
                                         proc.ProcessName)
 
    // Read the file
    //let lines = File.ReadAllLines(@"C:\Data\Gutenberg\TomJones\TomJones.txt")
    let lines = File.ReadLines(@"C:\src\Data\TomJones.txt")

    // Do a bery naive unique-word count (to prove we gat
    // the same results whichever way we access the file)
    let wordCount =
        lines
        |> Seq.map (fun line -> line.Split([| ' ' |]))
        |> Seq.concat
        |> Seq.distinct
        |> Seq.length

    printfn "Private bytes: %f" (counter.NextValue())
    printfn "Word count: %i" wordCount

