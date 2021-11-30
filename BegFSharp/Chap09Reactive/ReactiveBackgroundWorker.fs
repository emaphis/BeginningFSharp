// Reactive programing  - pg. 203
// fix this using the background worker: 

module ReactiveDemo2


open System
open System.Windows.Forms
open System.ComponentModel
open ThreadingDemo


let demoForm1 =
    let form = new Form()
    // input text box
    let input = new TextBox()
    // button to launch processing
    let button = new Button(Left= input.Right + 10, Text = "Go")
    // label to display the result
    let output = new Label(Top = input.Bottom + 10, Width = form.Width,
                           Height = form.Height - input.Bottom + 10,
                           Anchor = (AnchorStyles.Top
                           ||| AnchorStyles.Left
                           ||| AnchorStyles.Right
                           ||| AnchorStyles.Bottom))

    /// creat and run a new background worker
    let runWorker() =
        let background = new BackgroundWorker()
        // parse the input to an int
        let input = Int32.Parse(input.Text)

        // add the "work" event handler
        background.DoWork.Add(fun ea ->
            ea.Result <- fib input)

        // add the work completed event handler
        background.RunWorkerCompleted.Add(fun ea ->
            output.Text <- Printf.sprintf "%A" ea.Result)

        // start the worker off
        background.RunWorkerAsync()



    // hook up creating and running the worker to the button
    button.Click.Add( fun _ -> runWorker())

    // add the controls
    let dc c = c :> Control
    form.Controls.AddRange([| dc input; dc button; dc output |])

    // return form
    form