
open AdventureWorks1

// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let list = findPeople "%sen"

//printfn "%s"  (list.ToString())

for item in list do
    printfn "item  =  %i, %s, %s"
        item.BusinessEntityID item.FirstName item.LastName

