
open System
open System.Windows.Forms

// Defininitions of mainForms from examples
//open MyForms  // mainForm0
//open RecordsAsObjectsWithDrawing  // mainForm1
//open ObjectExpressionWithInterface  // mainForm2
//open ObjectExpressionWithInterfaceAndOverride  // mainForm3
open AccessingBaseClassMembers  // mainForm4

[<STAThread>]
[<EntryPoint>]
let main args =
    do Application.Run(mainForm4)
    0
