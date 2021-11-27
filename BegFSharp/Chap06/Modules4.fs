// Giving Modules Aliases  - pg. 130
namespace Modules4

// Give an alias to the Array3 module
module ArrayThreeD  = Microsoft.FSharp.Collections.Array3D


module AnotherModule =
    // create an matrix uisng the module alias
    let matrix =
        ArrayThreeD.create 3 3 3 1
