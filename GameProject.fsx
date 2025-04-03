
type Details = {Name: string; Description: string}

type Item = {Details: Details; } //maybe include a # of uses? 

//exit and room recursively reference each other causing an error
//instead of type, we use the and keyword
type Exit = 
    | PassableExit of Details * destination: Room
    | LockedExit of Details * key: Item * next: Exit
    | NoExit of Details option

and Exits = 
    {
    North: Exit
    South: Exit
    West: Exit
    East: Exit
    }

and Room = {Details: Details; Exits: Exits}
