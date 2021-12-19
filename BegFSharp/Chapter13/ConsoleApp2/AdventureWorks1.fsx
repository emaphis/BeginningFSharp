//module AdventureWorks1

//open FSharp.Data

#r  "nuget: FSharp.Data.SqlClient"

open FSharp.Data

//[<Literal>]
//let connectString =
        //@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AdventureWorks2019;Integrated Security=True"
 //       @"Server=(localdb)\MSSQLLocalDB;database=AdventureWorks2019;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True"

[<Literal>]
let connectString = 
    @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AdventureWorks2019;Integrated Security=True"



let findPeople surnameWildCard =
    use cmd = new SqlCommandProvider<"""
        SELECT * FROM Person.Person
            
        """, connectString>(connectString)

    cmd.Execute()


findPeople "xxx"
