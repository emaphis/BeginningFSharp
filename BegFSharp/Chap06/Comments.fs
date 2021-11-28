// Comments.fs

module Comments

// this is a single-line comment

(* this is a comment *)

(* this
   is a
   comment
*)


// Doc Comments

/// this is an explanation
let myString = "this is a string"


// The following is a doc comment where the tags have been explicitly written out:

/// <summary> 
/// divides the given parameter by 10 
/// </summary> 
/// <param name="x">the thing to be divided by 10</param>
let divTen x = x / 10


//
// generating the documentation
// fsc -doc doc.xml Comments.fs


// Comments for Cross-Compilation

// who cares
