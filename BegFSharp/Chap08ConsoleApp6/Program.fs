// Data Binding and the DataGridView Control - pg. 185

open System.Windows.Forms
open ContactList

let form =
    let frm = new Form()
    let grid = new DataGridView(Dock = DockStyle.Fill)
    frm.Controls.Add(grid)
    grid.DataSource <- dataSet.Tables[0]
    frm


[<EntryPoint>]
let main argv = 
    // Show the form:   
    do Application.Run(form)
    0
