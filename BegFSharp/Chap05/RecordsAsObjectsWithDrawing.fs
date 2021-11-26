// // Records as Objects with drawing   pg. 96

module RecordsAsObjectsWithDrawing

open System 
open System.Drawing 
open System.Windows.Forms


// a Shape record that will act as our object
type Shape =
    { Reposition: Point -> unit;
      Draw: Graphics -> unit }


// create a new instance of Shape
let movingShape initPos draw =
    // currPos is the internal state of the object
    let currPos = ref initPos in
    { Reposition =
        // the Repositon number updates the internal state
        (fun newPos -> currPos.Value <- newPos );
      Draw =
        // draw the shape passing the curren position
        // to gien draw function
        (fun g -> draw currPos.Value g); }



// "draws" a shape, prints out the shapes name and postion
let movingCircle initPos diam =
    movingShape initPos (fun pos g -> 
        g.DrawEllipse(Pens.Blue, pos.X, pos.Y, diam, diam))


// create a new square Shape
let movingSquare initPos size =
    movingShape initPos (fun pos g ->
        g.DrawRectangle(Pens.Blue, pos.X, pos.Y, size, size))


// list of shapes in their inital positions 
let shapes = 
    [ movingCircle (new Point (10,10)) 20; 
      movingSquare (new Point (30,30)) 20; 
      movingCircle (new Point (20,20)) 20; 
      movingCircle (new Point (40,40)) 20; ]

// create the form to show the items
let mainForm1 =
    let form = new Form()
    let rand = new Random()
    // add an event handler to draw the shapes
    form.Paint.Add(fun e ->
        shapes |> List.iter (fun s ->
            s.Draw e.Graphics))
    // add an event handler to move the shapes
    // when the user clicks on the form
    form.Click.Add(fun e ->
        shapes |> List.iter (fun s -> 
            s.Reposition(new Point(rand.Next(form.Width), rand.Next(form.Height)))
            form.Invalidate()))
    form

