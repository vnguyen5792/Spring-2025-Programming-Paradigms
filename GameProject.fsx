//
//DEFINE TYPES
//
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

//
//INTIALIZE WORLD
//

let key : Item = 
    { Details = {Name = "A shiny key"
                 Description = "This key look like it could open a nearby door..."} }

let allRooms = 
    [ { Id = RoomId "Entryway"
        Details = { Name = "The Entryway"; Description = "You stand in a dimly lit entryway. The air is damp, and the flickering candle casts eerie shadows against the stone walls." }
        Items = []
        Exits = { North = PassableExit ({ Name = "A creaky wooden door"; Description = "A weathered wooden door, slightly ajar, beckons you forward." }, RoomId "Hallway")
                  South = NoExit (Some { Name = "A solid stone wall"; Description = "There’s no way through here." })
                  West = NoExit None
                  East = NoExit None } }

      { Id = RoomId "Hallway"
        Details = { Name = "A Narrow Hallway"; Description = "The hallway stretches into darkness. Dust lingers in the air, disturbed only by your breath." }
        Items = [{ Details = { Name = "A rusted dagger"; Description = "Its edge is dulled by time, but it still feels balanced in your hand." }}]
        Exits = { North = PassableExit ({ Name = "A worn archway"; Description = "Beyond the archway, the scent of old parchment fills the air." }, RoomId "Library")
                  South = PassableExit ({ Name = "A creaky wooden door"; Description = "The same door you passed through earlier." }, RoomId "Entryway")
                  West = NoExit None
                  East = NoExit None } }

      { Id = RoomId "Library"
        Details = { Name = "The Library"; Description = "Rows of ancient books line the towering shelves. A single candle burns atop a reading desk, illuminating a dusty tome left open to an unreadable script." }
        Items = [{ Details = { Name = "An old book"; Description = "Bound in cracked leather, its pages whisper secrets long forgotten." }}]
        Exits = { North = PassableExit ({ Name = "A spiral staircase"; Description = "A narrow stairway winds upward, vanishing into the gloom above." }, RoomId "Tower")
                  South = PassableExit ({ Name = "A worn archway"; Description = "Back to the dim hallway." }, RoomId "Hallway")
                  West = NoExit None
                  East = NoExit None } }

      { Id = RoomId "Tower"
        Details = { Name = "The Tower Chamber"; Description = "A cold wind howls through the shattered windows. The moonlight casts jagged patterns across the stone floor." }
        Items = []
        Exits = { North = NoExit (Some { Name = "A crumbling balcony"; Description = "The ledge is unstable. One wrong step could be your last." })
                  South = PassableExit ({ Name = "A spiral staircase"; Description = "The narrow stairs descend into the shadows below." }, RoomId "Library")
                  West = NoExit None
                  East = PassableExit ({ Name = "A heavy iron door"; Description = "Its surface is engraved with strange symbols, pulsing faintly." }, RoomId "Vault") } }

      { Id = RoomId "Vault"
        Details = { Name = "The Vault"; Description = "The chamber is lined with chests, each sealed with an unbroken wax sigil. A faint whisper echoes from the shadows." }
        Items = [{ Details = { Name = "A mysterious amulet"; Description = "An eerie glow pulses from within the gemstone at its center." }}]
        Exits = { North = NoExit None
                  South = NoExit None
                  West = PassableExit ({ Name = "A heavy iron door"; Description = "The symbols upon it still hum with unseen power." }, RoomId "Tower")
                  East = NoExit None } } ]

let player : Player =
    {
        Details = {Name = "Leon"
                   Description = "An average looking guy with a slightly leaner build."}
        Location = RoomId "Entryway"
        Inventory = []
    }

let gameWorld =
    { Rooms =
        allRooms
        |> Seq.map (fun room -> (room.Id, room))
        |> Map.ofSeq
      Player = player}

//game functions
let getRoom world roomId =
    world.Rooms.TryFind roomId

let describeDetails details =
    printf "\n\n%s\n\n%s\n\n" details.Name details.Description

let extractDetailsFromRoom (room : Room option) =
    match room with
    | Some(r) -> r.Details
    | None -> { Name = "No room!"; Description = "No room that id found."}

let describeCurrentRoom world =
    world.Player.Location
    |> getRoom world
    |> (extractDetailsFromRoom >> describeDetails)

//start game?
gameWorld
|> describeCurrentRoom