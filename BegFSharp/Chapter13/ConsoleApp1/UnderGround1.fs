module UnderGround1

// pg.

open FSharp.Data

type Stations = CsvProvider< @"C:\temp\StationsSample.csv",
                             HasHeaders = true,
                             Schema = "Zone(s)=string">


let ListStations() =
    let stations = Stations.Load(@"C:\temp\StationsSample.csv")

    for station in stations.Rows do
        printfn "%s is in %s"  station.Station station.``Zone(s)``