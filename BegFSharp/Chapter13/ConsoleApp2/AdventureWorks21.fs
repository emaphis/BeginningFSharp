module AdventureWorks21

open FSharp.Data

[<Literal>]
let connectionString = 
    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AdventureWorks2019;Integrated Security=True"

let runList() =
   use cmd = new SqlCommandProvider<"
       SELECT TOP(@topN) FirstName, LastName, SalesYTD 
       FROM Sales.vSalesPerson
       WHERE CountryRegionName = @regionName AND SalesYTD > @salesMoreThan 
       ORDER BY SalesYTD
       " , connectionString>(connectionString)

   cmd.Execute(topN = 3L, regionName = "United States", salesMoreThan = 1000000M) |> printfn "%A"
