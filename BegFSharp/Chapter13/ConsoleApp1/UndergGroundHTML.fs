module UndergroundHTML

// pg. 291

open FSharp.Data

type Stations = HtmlProvider< @"https://simple.wikipedia.org/wiki/List_of_London_Underground_stations">

let ListStations() =
    let stations = Stations.Load(@"https://simple.wikipedia.org/wiki/List_of_London_Underground_stations")

    let list = stations.Tables.Html.Body().Attribute

    //tations.TablesContainer.

    //for item in list do
    //    printfn "item: %A" item

    printfn "%A" list
