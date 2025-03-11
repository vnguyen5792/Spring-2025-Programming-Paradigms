open System
Console.WriteLine("Name: {0}; Score: {1}", "Veronica", 100)

//2
let anotherNum = 30

//3
let mutable num : int = 10
printfn "num: %d" num
num <- 20;
printfn "num: %d; anotherNum: %d" num anotherNum

//4
let mutable thirdNum : int = anotherNum
thirdNum <-thirdNum * 2
printfn "num: %d; anotherNum: %d; thirdNum: %d, thirdNum = 60: %b" num anotherNum thirdNum (thirdNum = 60)

//6
let first = "32"
let numberVersion = int first
printfn "Number %i" numberVersion

//7
let timeNow = System.DateTime.Now.ToString() //use dotnet library function
printfn "time now: %s" timeNow

//8
let addOne x = x + 1    //this is a function that adds one
printfn "10 + 1 = %d" (addOne 10)

//9
open System
printfn "Please enter an odd number..."
let oddNumber: string = System.Console.ReadLine()
printfn "a Boolean value: %b" (int oddNumber%2 <> 0)

//if else statements
let age = 70
if age > 65
then printfn "Senior Citizen"
else printfn "Citizen"

let age2 = 60
let message = if age > 64 then "Senior Citizen" else "Citizen"  //this is an inline if statement
//kind of reminds me of the ternary operator
printfn "%s" message

let someCondition = false
let value = if someCondition then "Hello" else "1"
printfn "%s" value

//FIZZ BUZZ code
printfn "Please enter a positive number: "
let input = System.Console.ReadLine()
let number = int input
let result = 
    if number % 3 = 0 && number % 5 = 0 then "Fizzbuzz"
    elif number % 3 = 0 then "Fizz"
    elif number % 5 = 0 then "Buzz"
    else $"{number} is not divisible by 3 or 5"

printfn "%s" result

//match expressions
let value1 = 2
match value1 with 
| 1 -> "The value is 1"
| 2 -> "The value is 2"
| 0 -> "Zero"

//you can use a when clause to specify an additional condition that the variables must satisfy
//this clause is referred to as a guard
let determineSign number =
    match number with
    | n when n > 0 -> "Positive"
    | n when n < 0 -> "Negative"
    | 0 -> "Zero"

let result1 = determineSign 1

//this is a class type
//discriminated union
type Shape =
    | Circle of float
    | Rectangle of float * float

let shape = Rectangle(10.0, 20.0)

match shape with
    | Circle radius -> printfn "Circle with radisu %f" radius
    | Rectangle (width, height) -> printfn "Rectangle with width %f and height %f" width height
