
type Details = {Name: string; Description: string}

type Item = {Details: Details; } //maybe include a # of uses? 

type RoomId =
    | RoomId of string

//exit and room recursively reference each other causing an error
//instead of type, we use the and keyword
//but storing the same room information multiple times is inefficient. so we can make a room id type
type Exit = 
    | PassableExit of Details * destination: RoomId
    | LockedExit of Details * key: Item * next: Exit
    | NoExit of Details option

type Exits = 
    {
    North: Exit
    South: Exit
    West: Exit
    East: Exit
    }

type Room = 
    {Id: RoomId
     Details: Details
     Items: Item list
     Exits: Exits}

type Player = 
    {
        Details: Details
        Location: RoomId
        Inventory: Item list
    }

type World = 
    {
        Rooms: Map<RoomId, Room>
        Player: Player
    }

