
open UndergroundHTML

printfn "Hello from F#"

[<Literal>]
let connectionString = 
    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AdventureWorks2019;Integrated Security=True"

do ListStations()