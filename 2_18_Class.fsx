//for loops
let list = [1; 2; 3; 4; 5;]
for i in list do
    printfn "%d" i

for i in 1 .. 10 do
    printfn "%i" i

for c in 'a' .. 'z' do
    printfn "%c" c

for i in 1 .. 3 .. 10 do
    printfn "%i" i

for i in 10 .. -1 .. 1 do
    printfn "%i" i

//for to
for i = 1 to 10 do
    printfn "%d" i

//this sequence generates two values from 1 to 10 with the second value being squared
let seq1 = seq {for i in 1 .. 10 -> (i, i*i)}
for(a, asqr) in seq1 do
    printfn "%d squared is %d" a asqr

let beginning x y = x - 2*y
let ending x y = x + 2*y
let function3 x y =
    for i = (beginning x y) to (ending x y) do
        printfn "%d" i

function3 5 2

let list1 = [1; 2; 3; 4; 5; 6]

let mutable count = 0;
for _ in list1 do
    count <- count + 1

printfn "The total number of elements in list1: %d" count

let mutable quit = false
let num = 11

while not quit do
    printfn "Guess a number: "
    let guess = System.Console.ReadLine()
    let guessNum = int guess
    if guessNum = num then
        quit <- true
        printfn "You guessed correctly! %i is the secret number" guessNum
    else
        printfn "%i is incorrect. The secret number is in the range of (10 to 15)" guessNum

while not quit do
    printfn "Guess a number: "
    let guess = System.Console.ReadLine()
    
    match int guess with
    | guessNum when guessNum = num ->
        quit <- true
        printfn "You guessed correctly! %i is the secret number" guessNum
    | guessNum ->
        printfn "%i is incorrect. The secret number is in the range of (10 to 15)" guessNum

let rec readInt () =
    System.Console.WriteLine("Enter a positive integer: ")
    let input = System.Console.ReadLine()
    match System.Int32.TryParse input with
    | true, value -> value
    | false, _ ->
        System.Console.WriteLine("Invalid input, please try again")
        readInt()