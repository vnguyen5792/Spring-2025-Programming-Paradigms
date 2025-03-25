// type MagicCreature = {Name: string; Level: int; Attack: int}
// let creatures = [
//     {Name = "Dragon"; Level = 2; Attack = 20}
//     {Name = "Orc"; Level = 1; Attack = 5}
//     {Name = "Demon"; Level = 2; Attack = 10}
// ]

// //-1 = less than, 1 = larger than, 0 = equal
// let compareCreatures c1 c2 =
//     if c1.Level < c2.Level then -1
//     else if c1.Level > c2.Level then 1
//     else if c1.Attack < c2.Attack then -1
//     else if c1.Attack > c2.Attack then 1
//     else 0

type People = string * string   //instead of creating a type with a record type, we can use a tuple

let people = [
    ("John", "Smith")
    ("Addison", "Nguyen")
]

//for searching methods, you need to provide a function (predicate) that tells it
//how to find the item
// find(), tryFind(), tryFindIndex() - refer to slides for definitions

let list = [1; 2; 3; 4]

//all functions will return a new list instead of the one passed in

//find()
let found = 
    list
    |> List.find(fun x -> x = 4)

//tryFind() - returns an option. an option is a built in discriminated union type with two union cases (idk what that means lol)
let findValue aValue aList =
    let found =
        aList
        |> List.tryFind(fun item -> item = aValue)

    match found with
    | Some value -> printfn "%i" value  //i think "some" and "none" and values from the built in DU
    | None -> printfn "Not found"

findValue 300 list

// let findPersonByName nameToFind personList =
//     let foundPerson =
//         personList
//         |> List.tryFind(fun person -> person.Name = nameToFind)
    
//     match foundPerson with
//     | Some value -> printfn "s" foudn

//tryFindIndex() - very similar to try find function
let found1 = List.tryFindIndex(fun x -> x = 4) list
match found1 with
    | Some index -> printfn "%i" index
    | None -> printfn "Not Found"

//sum()
let sum = List.sum [1..5]

//sumBy()
type OrderItem = {Name: string; Cost: int}

let orderItems = [
    {Name = "Xbox"; Cost = 500}
    {Name = "Book"; Cost = 10}
    {Name = "Movie Ticket"; Cost = 7}
]

let sum1 = List.sumBy(fun item -> item.Cost) orderItems

//average() - takes floats not integers
//averageBy() - acts similar to sumBy()

//Pure functions - deterministic. same input same output
//no side effects
