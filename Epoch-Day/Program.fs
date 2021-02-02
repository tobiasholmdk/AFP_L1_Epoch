open System

// Opgave 1.2
let isLeap (year:int)=
    if ( year % 400 = 0 && year % 100 <> 0 || year % 4 = 0 && year % 100 <> 0 ) then true
    else false
    
// Opgave 1.3
let daysToEndYear (year:int) =
    let LeapYears = List.filter isLeap [1970..year]
    ((year-1970)*365) + (List.length LeapYears)
  
// Opgave 1.4    
let daysToEndMonth (month, year) =
    let correction = match month with
                     | 1 -> 0
                     | _ when isLeap year -> 1
                     | _ -> 2
    (367*month+5)/12 - correction + daysToEndYear (year-1)

// Opgave 1.5 
let epochDay(day, month, year) =
    day + daysToEndMonth (month, year)              
                     
[<EntryPoint>]
let main argv =
    while true do
        let result = epochDay( Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine( result );
    0 // return an integer exit code