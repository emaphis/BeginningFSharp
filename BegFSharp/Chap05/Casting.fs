// Casting  - pg. 120

module Casting

// upcasting
// Upcasts change a value’s static type to one of its ancestor types. 

// Upcast a string to an object:
let myObject = ("This is a string" :> obj)

open System.Windows.Forms

// Upcast some Windows controls to Control
// so that they can go into the same collection:
let myControls =
    [| (new Button() :> Control);
       (new TextBox() :> Control;);
       (new Label() :> Control) |]


// boxing a vlue  - puting it on the managed heap to pass around as a reference
let boxedInt = (1 :> obj)


// down casting
// A downcast changes a value’s static type to one of its descendant types;

// Make another array of controls upcast to Control:
let moreControls = 
    [| (new Button() :> Control); 
       (new TextBox() :> Control) |]

// Pick one of the controls access a property which
// all controls have in common, and return it as
// a control:
let control = 
    let temp = moreControls[0] 
    temp.Text <- "Click Me!" 
    temp 

// Cast the control to its 'real' type (Button) and
// access a property that is specific to buttons,
// and return it as a Button
let button =  
    let temp = (control :?> Button) 
    temp.DoubleClick.Add(fun e -> MessageBox.Show("Hello") |> ignore) 
    temp
 