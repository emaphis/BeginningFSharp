// Records as Objects  pg. 94

module RecordsAsObject


open System.Drawing

// a Shape record that will act as our object
type Shape =
    { Reposition: Point -> unit;
      Draw: unit -> unit }


// create a new instance of Shape
let makeShape initPos draw =
    // currPos is the internal state of the object
    let currPos = ref initPos
    { Reposition =
        // the Repositon number updates the internal state
        (fun newPos -> currPos.Value <- newPos );
      Draw =
        // draw the shape passing the curren position
        // to gien draw function
        fun () -> draw currPos.Value; }


// "draws" a shape, prints out the shapes name and postion
let draw shape (pos: Point) =
    printfn "%s, with x = %i and y = %i" shape pos.X pos.Y


// creates a new circle shape
let circle initPos =
    makeShape initPos (draw "Cirlce")


// creates a new square shape 
let square initPos = 
    makeShape initPos (draw "Square")


// list of shapes in their initial postions
let shapes =
    [ circle (new Point (10, 30));
      square (new Point (30, 20)) ]


// draw all the shapes
let drawShapes() =
    shapes |> List.iter (fun s -> s.Draw())


let main() =
    drawShapes()  // draw the shapes
    // mova all the sahpes
    shapes |> List.iter (fun s -> s.Reposition (new Point (40, 40)))
    drawShapes()  // draw the shapes


// start the program
do main()
