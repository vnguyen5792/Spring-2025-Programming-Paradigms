//.fsx files let us run the code in the interactive mode

let mutable number = 10 //the keyword 'mutable' allows us to change the value later on
//number = 20 //this is a comparison check, not reassigning the value to number
number <- 20
printfn "%i" number //you need to specify what type you are printing

let name : string = "Addison"
printfn "%s" name

// printf "Hello world"
// printfn "Hello world"
// System.Console.WriteLine "Hello world"

// printfn $"Name: {name}"
// printfn $"{number + 20}"

let list = [1; 2; 3; 4]
printfn "%A" list   //specifier for printing out a list

System.Console.WriteLine " Type a value: "
let str = System.Console.ReadLine()   //everything read from the console is read as a string
printfn "%s" str

//converts a string to an int
let first = "32"
//let num = System.Int32.Parse //converts a string to an integer
let num = int first
printfn "%i" num

//converts an int to a string
let sec = 32
let toStr = sec.ToString()
printfn "%s" toStr