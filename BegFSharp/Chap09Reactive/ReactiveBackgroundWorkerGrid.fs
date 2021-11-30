// Reactive programing  - pg. 205
// Use data grid to display multiple results

module ReactiveDemo3

open System
open System.Windows.Forms
open System.ComponentModel
open ThreadingDemo
open System.Numerics


// Define a type to hold the results:
type Result =
    { Input: int;
      Fibonacci: BigInteger; }


let demoForm1 =
    let form = new Form()
    // Input text box:
    let input = new TextBox()
    // Button to launch processing:
    let button = new Button(Left = input.Right + 10, Text = "Go")
    // List to hold the results:
    let results = new BindingList<Result>()
    // Data grid view to display multiple results:
    let output = new DataGridView(Top = input.Bottom + 10, Width = form.Width, 
                                  Height = form.Height - input.Bottom + 10,
                                  Anchor = (AnchorStyles.Top 
                                            ||| AnchorStyles.Left 
                                            ||| AnchorStyles.Right 
                                            ||| AnchorStyles.Bottom),
                                  DataSource = results)

    // Create and run a new background worker:
    let runWorker() =
        let background = new BackgroundWorker()
        // Parse the input to an int:
        let input = Int32.Parse(input.Text)
        // Add the "work" event handler:
        background.DoWork.Add(fun ea ->
            ea.Result <- (input, fib input)) 
        // Add the work completed event handler:
        background.RunWorkerCompleted.Add(fun ea ->
            let input, result = ea.Result :?> (int * BigInteger)
            results.Add({ Input = input; Fibonacci = result; }))
        // Start the worker off:
        background.RunWorkerAsync()
 
    // Hook up creating and running the worker to the button:  
    button.Click.Add(fun _ -> runWorker())
    
    // Add the controls:
    let dc c = c :> Control
    form.Controls.AddRange([|dc input; dc button; dc output |])
    
    // Return the form:
    form
