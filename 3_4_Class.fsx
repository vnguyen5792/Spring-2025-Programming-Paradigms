//two different ways to iterate through a list
let cards = [1 .. 5]
List.iter(fun i -> printfn "%i" i) cards

for i in cards do printfn "%i" i

//map takes a function and a list as its arguements
//it then applies that transformation to the given list and returns the new list
let list = [1..3]
let newList = List.map(fun x -> x + 1) list

//filters through the given list by using the given function
let numbers = [1..5]
let newList2 = List.filter(fun x -> x % 2 = 0) numbers

let list2 = [4; 3; 1]
let sort (list: int list) = List.sort list //sorts ascending order [1; 3; 4]
let print (list: int list) = List.iter(fun x -> printfn "item %i" x) list

list2
    |> sort
    |> print


//practice
//square the odd values of list and add one. pipe Operators
//my attempt: creating seperate functions then calling them in pipeline
let oddNum = [1..10]
let oddSort (list: int list) = List.filter(fun x -> x % 2 <> 0) list
let squareAndAddOne (list: int list) = List.map(fun x -> x * x + 1) list
let print2 (list: int list) = List.iter(fun x -> printfn "%i" x) list

oddNum
    |> oddSort
    |> squareAndAddOne
    |> print2

//you can also directly pipeline the function to the list

oddNum
    |> List.filter(fun x -> x % 2 <> 0)
    |> List.map(fun x -> x * x + 1)
    |> List.iter(fun x -> printfn "%i" x)

//you can also create a function using pipelining which is done here
let squareAndOdd (values: int list) =
    values
    |> List.filter(fun x -> x % 2 <> 0)
    |> List.map(fun x -> x * x + 1)

let oddNumbers = [1..5]

let result = squareAndOdd oddNumbers
