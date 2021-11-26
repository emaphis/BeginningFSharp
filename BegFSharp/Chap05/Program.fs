
open System
open System.Windows.Forms


// MyForm app
//open MyForms

// [<STAThread>]
// [<EntryPoint>]
// let main args =
//     Application.SetHighDpiMode(HighDpiMode.SystemAware) |> ignore
//     Application.EnableVisualStyles();
//     Application.SetCompatibleTextRenderingDefault(false);
//     Application.Run(new Form1());
//     0 // return an integer exit code


// RecordsAsObjectsWithDrawing app
open RecordsAsObjectsWithDrawing

[<STAThread>]
[<EntryPoint>]
let main args =
    do Application.Run(mainForm)
    0
