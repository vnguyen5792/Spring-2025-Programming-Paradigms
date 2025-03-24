let print (list: string list) =
    list
    |> List.iter(fun x -> printfn "%s" x )

//"changing a list"
let cards = ["ace"; "king"; "queen"]
let newList = "jack" :: cards

print newList

let list1 = [1;2;3]
let list2 = [4;5;6]
let list3 = List.append list1 list2


let otherCardList = ["9"; "10"]
let fulllist1 = 
    cards
    |> List.append otherCardList    //you can only append 2 lists together
//this is called partial application

//lists are created as linked lists in F# with head and tail properties
//to traverse through a list for a specified value, use .tail to move through the list and .head to get that ValueNone

printfn "%i" list3.Tail.Tail.Tail.Tail.Tail.Head    //i think this actually makes a sublist and gets the head

let deck = [1..5]

let drawCard (list: int list)=
    printfn "%i" list.Head
    list.Tail

let result = 
    deck
    |> drawCard
    |> drawCard
    |> drawCard
    |> drawCard
    |> drawCard
//the return value of the result is an empty list.
//so does this continue to create sublists or does it affect the main list

printfn "Deck: %A" result
printfn "Deck: %A" deck

//REVIEW OVER TUPLES
let hand: int list = []
let drawHand(tuple: int list * int list) = 
    let deck = fst tuple    //gets the first list from the tuple
    let draw = snd tuple    //gets the second list from the tuple
    let firstCard = deck.Head   //gets the head of the deck list
    
    //assigns hand the draw list while also appending the first card
    //using the @ alternative to list.append
    let hand = draw @ [firstCard]

    (deck.Tail, hand)

let d, h =
    (deck, hand)
    |> drawHand
    |> drawHand
    |> drawHand

//List.iter is used to perofrm a side-effect on each element without affecting the values
//for example, we've been using it mainly for printing

//List.map is used to apply a function to each element in the list and return a new list
//with the results
//********WRITE DOWN LIST.MAP ON CHEAT SHEET*******
//this is a good example for map and filter
// let squareAndOdd (values: int list) =
//     values
//     |> List.filter(fun x -> x % 2 <> 0)
//     |> List.map(fun x -> x * x + 1)

//record type? basically a class with only members
type Person = {FirstName: string; LastName: string}

//a list of the newly created Person
let (people: Person list) = [
    {FirstName="Albert"; LastName="Einstein"}
    {FirstName="Marie"; LastName="Curry"}
]

let nobelPrizeWinners = List.map(fun person -> person.FirstName + " " + person.LastName) people
printfn "%A" nobelPrizeWinners

//functions for sorting
//sort() - sorts in ascending order
//sortBy() - lets you specify the parameters to sort by. i.e. age with a person record
//sortWith() - lets you provide a comparator function

//sort()
let list = [4;3;1]
let sort(list: int list) = List.sort list
let print2(list: int list) = List.iter(fun x -> printfn "%i" x) list

list
    |> sort
    |> print2

//sortBy()
type Person2 = {Name: string; Age: int}

let people2 = [
    {Name = "addi"; Age = 20}
    {Name = "maddi"; Age = 40}
    {Name = "paddi"; Age = 30}
]

let sortedByAge = List.sortBy (fun (people: Person2) -> people.Age) people2
printfn "sorted by age %A" people2

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

// let compareCreatures c1 c2 =
//     match c1.Level, c2.Level with
//     | l1, l2 when l1 < l2 -> -1
//     | l1, l2 when l1 > l2 -> 1
//     match c1.Attack, c2.Attack with
//     | 


//first coding question
//basic F# - how to define functions, control flow, etc.

//loops, recursion, etc.

//second coding question
//sorting

//third question
//what we have learned so far in functional paradigm