
open System
open System.Windows.Forms


// MyForm app
//open MyForms

// RecordsAsObjectsWithDrawing app
//open RecordsAsObjectsWithDrawing  // mainForm1

//open ObjectExpressionWithInterface  // mainForm2
open ObjectExpressionWithInterfaceAndOverride  // mainForm3

[<STAThread>]
[<EntryPoint>]
let main args =
    do Application.Run(mainForm3)
    0
