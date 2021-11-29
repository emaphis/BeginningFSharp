// Data Binding  pg. 182


open System.Windows.Forms
open ContactList

let form =
    let frm = new Form()
    let contats = getContactList()
    let combo = new ComboBox(Top=8, Left=8, DataSource=contats)
    frm.Controls.Add(combo)
    frm

[<EntryPoint>]
let main argv = 
    // Show the form:   
    do Application.Run(form)
    0
