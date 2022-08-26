// Data Binding  pg. 182

module ContactList

open System.Configuration
open System.Collections.Generic
open System.Data
open System.Data.SqlClient


/// create and open an SqlConnection object using the connection string
/// found in the configuration file for the given connection name
let openSQLConnection (connName:string) =
    let connSetting = ConfigurationManager.ConnectionStrings.[connName]
    let conn = new SqlConnection(connSetting.ConnectionString)
    conn.Open()
    conn


/// create and execute a read command for a connection using
/// the connection string found in the configuration file
/// for the given connection nam
let openConnectionReader connName cmdString =
    let conn = openSQLConnection(connName)
    let cmd = conn.CreateCommand(CommandText = cmdString,
                                 CommandType = CommandType.Text)
    let reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    reader


/// read a row from the data reader 
let readOneRow (reader: SqlDataReader) =
     if reader.Read() then
         let dict = new Dictionary<string, obj>()
         for x in [ 0 .. (reader.FieldCount - 1) ] do
            dict.Add(reader.GetName(x), reader.[x])
         Some(dict)
     else
        None


/// execute a query using a recursive list comprehension
let execQuery (connName: string) (cmdString: string) =
     use reader = openConnectionReader connName cmdString
     let rec read() =
         [
             let row = readOneRow reader
             match row with
             | Some r -> 
                yield r
                yield! read()
             | None -> ()
         ] 
     read()


// get the contents of the person table
let peopleTable =
    execQuery "MyConnection"
               "select top 10 * from Person.Person"


// Create an array of first and last name
let getContactList() =
    [| for row in peopleTable ->
         Printf.sprintf "%O %O"
            (row["FirstName"])
            (row["LastName"])|]

