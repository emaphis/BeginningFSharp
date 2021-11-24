// Control Flow  pg. 77

module ControlFlow


// imperitive 'if' doesn't need an 'elss'
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Sunday then
    printfn "Sunday Playlest: Lazy On A Sonday Afternoon - Queen"


// but you can use one
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then 
    printfn "Monday Playlist: Blue Monday - New Order"
else 
    printfn "Alt Playlist: Fell In Love With A Girl - White Stripes" 


// if scope is determined by whitespace
if System.DateTime.Now. DayOfWeek = System.DayOfWeek.Tuesday then 
    printfn "Tuesday Playlist: Ruby Tuesday - Rolling Stones" 
printfn "Everyday Playlist: Eight Days A Week - Beatles"


if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Friday then 
    printfn "Friday Playlist: Friday I'm In Love - The Cure" 
    printfn "Friday Playlist: View From The Afternoon - Arctic Monkeys" 


// for loops

// an araray for words
let words = [| "Red"; "Lorry"; "Yellow"; "Lorry" |]

// use a for loop to pring each element
for word in words do
    printfn "%s" word


// a Ryunosuke Akutagawa haiku array 
let ryunosukeAkutagawa = [| "Green "; "frog,"; 
    "Is"; "your"; "body"; "also"; 
    "freshly"; "painted?" |] 

// for loop over the array printing each element
for index = 0 to Array.length ryunosukeAkutagawa - 1 do
    printf "%s " ryunosukeAkutagawa[index]


// reverse
// a Shuson Kato hiaku array (backwards) 
let shusonKato = [| "watching."; "been"; "have"; 
    "children"; "three"; "my"; "realize"; "and"; 
    "ant"; "an"; "kill"; "I"; 
    |] 

// loop over the array backwards printing each word 
for index = Array.length shusonKato - 1 downto 0 do 
    printf "%s " shusonKato.[index]


// using range notation

// count upwards
for i in 0..10 do
    printfn "%i green bottles" i 

// Count upwards in tens 
for i in 0..10..100 do 
    printfn "%i green bottles" i  


// while loop

// a Matsuo Basho hiaku in a mutable list 
let mutable matsuoBasho = [ "An"; "old"; "pond!"; 
    "A"; "frog"; "jumps"; "in-"; 
    "The"; "sound"; "of"; "water" ]

while (List.length matsuoBasho > 0) do
    printf "%s " (List.head matsuoBasho)
    matsuoBasho <- List.tail matsuoBasho
