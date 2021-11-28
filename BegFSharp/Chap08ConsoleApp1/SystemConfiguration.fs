namespace SystemConfiguration
// The System.Configuration Namespace  - pg. 167

open System

// This will only work in a compiled context, not in F# Interactive.

module Demo =

    open System.Configuration


    // read an application setting
    let setting = ConfigurationManager.AppSettings.["MySetting"]
    
    // print the setting 
    printfn "My Setting: %s\n" setting

    // get the connection string
    let connectionStringDetails =
        ConfigurationManager.ConnectionStrings.["MyConnectionString"]

    // print the details 
    printfn "Connection details:\n%s\r\n%s\n"
        connectionStringDetails.ConnectionString
        connectionStringDetails.ProviderName

    // open the machine config
    let config = 
        ConfigurationManager.OpenMachineConfiguration()

    // print the names of all sections
    printfn "Machine Config:"
    for x in config.Sections do
        printfn "%s" x.SectionInformation.Name

    [<EntryPoint>]
    let main args =
        printfn "Press a key to exit."
        Console.ReadKey(false) |> ignore
        0
