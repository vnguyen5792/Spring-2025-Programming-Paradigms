//type Customer = string * bool * bool

let fred = "Fred", true, true

let (id, isEligible, isRegistered) = fred
//we have now bound these values to the values from fred
//this decomposes the tuple

//Record types have a name value pair. Much like the Dictionary from C# with the key value pairs

//when creating it inline, there must be semicolons to seperate them
type Point = {X: float; Y: float; Z: float;}

//when structured like so, the semicolon is optional
type Customer = {
    First: string
    Last: string
    SSN: int
    AccountNumber: int
}

//look into discriminated union
