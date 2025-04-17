//Currying
let add x y = x + y
let add2 = add 2    //partial application

//discriminated union

type LogLevel = 
| Error
| Warning
| Infor

let log (level: LogLevel) (message: string) = 
    printfn "[%A] : %s" level message

let errorLog = log Error

let list = [1..5]

let findValue aValue alist =
    let found =
        alist |> List.tryFind(fun x -> x = aValue)
    
    match found with
    |Some value -> printfn "Found : %i" value
    |None -> printfn "Not found"

findValue 3 list