type MagicCreature = {Name: string; Level: int; Attack: int}
let creatures = [
    {Name = "Dragon"; Level = 2; Attack = 20}
    {Name = "Orc"; Level = 1; Attack = 5}
    {Name = "Demon"; Level = 2; Attack = 10}
]

//-1 = less than, 1 = larger than, 0 = equal
let compareCreatures c1 c2 =
    if c1.Level < c2.Level then -1
    else if c1.Level > c2.Level then 1
    else if c1.Attack < c2.Attack then -1
    else if c1.Attack > c2.Attack then 1
    else 0

type People = string * string   //instead of creating a type with a record type, we can use a tuple

let people = [
    ("John", "Smith")
    ("Addison", "Nguyen")
]

//for searching methods, you need to provide a function (predicate) that tells it
//how to find the item
// find(), tryFind(), tryFindIndex() - refer to slides for definitions

let list = [1; 2; 3; 4]

let found = 
    list
    |> 