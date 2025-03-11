
//define and call function
let add a b =
    a + b

printfn "%d" (add 10 20)


//return values
//no 'return' keyword to state what is being returned
// in F#, the info in the last line is what gets returned
let addMultiply a b c =
    let sum = a + b
    sum * c

printfn "%i" (addMultiply 2 3 3)

//inferred types
//the type is inferred by context and first we use
let add a b = a + b
let sum = add 2 2
let concat = add "hello " "world"   //this will get an error
//although we never explicitly stated the type for add, it is inferred based off the FIRST call

//explicit types
let convert (a: string):int = int a

printfn "%i" (convert "10")

//the compiler will attempt to make the function as generic as possible
let f x = (x, x)
printfn "$A" (f 10)
//tuple type with x being generic

//define function for equality check
let areEqual expected actual = 
    actual = expected

areEqual 10 10
areEqual "Addi" "Addi"
areEqual (2,3) (2, 30)

//function for calculating the volume of the cylinder
let cylinderVolume radius length =
    //define local value pi
    let pi = 3.14159
    length * pi * radius * radius

let vol = cylinderVolume 2 3
printfn "%f" vol

//function values
//apply1 takes a function that takes an integer and returns an integer
let apply1 (transform: int -> int) y = transform y
let increment x = x + 1
let result = apply1 increment 100

//this takes two integers and returns an integer
let apply2 (f: int -> int -> int) x y = f x y
let mul x y = x * y
let result2 = apply2 mul 10 20

//using lambda expressions
let apply1 (transform: int -> int) y = transform y
let result3 = apply1 (fun x -> x + 1) 100
let apply2 = (f: int -> int -> int) x y = f x y
let result4 = apply2 (fun x y -> x * y) 10 20

//imperative
let add2 a = a + 2
let multiply3 a = a * 3
let addAndMultiply a =
    let sum = add2 a
    let product = multiply3 sum
    product

printfn "%i" (addAndMultiply 2)

//functional
let add2 a = a + 2
let multiply3 a = a * 3
let addAndMultiply = add2 >> multiply3 //this creates a function

printfn "%i" (addAndMultiply 2)

//we can use pipelineing within functions as well
let func1 x = x + 1
let func2 x = x * 2

//this runs func1 first then func2 from func1
let result =
    100
    |> func1
    |> func2
//this results in an output


