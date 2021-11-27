//  Opening Namespaces and Modules  - pg. 128
namespace Modules3


// A module of operators
module MyOps =
    // check equality via hash code:
    let (===) x y =
        x.GetHashCode() = y.GetHashCode()

module AnotherModule =

    // Open the MyOps module
    open MyOps

    // use the tripple equal operator
    let equal = 1 === 1
    let nEqual = 1 === 2
