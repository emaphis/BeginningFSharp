// Now you try  - pg. 74

// Listing 6.4 Working with mutable objects

open System
open System.Windows.Forms

[<STAThread>]
[<EntryPoint>]
let main args =
    let form = new Form(Text = "Hello from F#!", Width = 300, Height = 300)

    do Application.Run(form)
    0
