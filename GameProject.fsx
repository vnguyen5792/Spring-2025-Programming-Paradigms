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

let rustedKey : Item = 
    { Details = {Name = "A rusted key"
                 Description = "Just a key. That's rusted."} }

let allRooms = 
    [ { Id = RoomId "Field"
        Details = { Name = "Empty Field"; Description = "You wake up in the middle of a barren field. The blades of bland grass sway from the slight breeze." }
        Items = []
        Exits = { North = PassableExit ({ Name = "A worn dirt path facing north"; Description = "The dirt path points north towards some houses in the distance..." }, RoomId "DirtRoadNorth")
                  South = PassableExit ({Name = "A worn dirt path facing south"; Description = "The dirt path points south into the seemingly never ending blades of grass..."}, RoomId "DirtRoadSouth")
                  West = PassableExit ({ Name = "A worn dirt path facing west"; Description = "The dirt path points west where you can see a... vending machine?" }, RoomId "DirtRoadWest")
                  East = PassableExit ({Name = "A worn dirt path facing east"; Description = "The dirt path points east. That's it."}, RoomId "DirtRoadEast")
                } }

      { Id = RoomId "DirtRoadNorth"
        Details = { Name = "Dusty Road - North"; Description = "The houses ahead seem abandoned, their windows staring back like hollow eyes. A broken fence lines the road, creaking faintly in the wind." }
        Items = [{ Details = { Name = "A tattered scarf"; Description = "Faded and frayed, it looks like it’s been here a while." }}]
        Exits = { 
            South = PassableExit ({ Name = "A worn dirt path leading back to the field"; Description = "You can just make out the place you woke up." }, RoomId "Field")
            North = LockedExit (
                  { Name = "A locked wooden door"; Description = "The door to the house is locked, but there’s a rusty keyhole." },
                  rustedKey,
                  PassableExit ({ Name = "An open door"; Description = "The door creaks open into the house..." }, RoomId "AbandonedHouse"))
            East = NoExit None
            West = NoExit None } }

      { Id = RoomId "DirtRoadSouth"
        Details = { Name = "Endless Grass"; Description = "The grass stretches endlessly in every direction. You feel like you’re walking in circles." }
        Items = []
        Exits = { 
            North = PassableExit ({ Name = "A worn dirt path heading back"; Description = "Back to the field where you started." }, RoomId "Field")
            South = NoExit (Some { Name = "An invisible wall"; Description = "You try to push forward, but something stops you." })
            East = NoExit None
            West = NoExit None
            } }

      { Id = RoomId "DirtRoadWest"
        Details = { Name = "Vending Machine Outpost"; Description = "Sure enough, a lonely vending machine stands buzzing. There’s no power line in sight." }
        Items = [{ Details = { Name = "A can of soda"; Description = "It’s cold. You don’t know how or why." }}]
        Exits = { 
            East = PassableExit ({ Name = "A dirt path back to the field"; Description = "Back the way you came." }, RoomId "Field")
            North = NoExit None
            South = NoExit None
            West = NoExit (Some { Name = "A chain-link fence"; Description = "It rattles ominously when touched, but there’s no gate." })
            } }

      { Id = RoomId "DirtRoadEast"
        Details = { Name = "Empty Road East"; Description = "The road seems to go on forever, yet each step feels like you haven’t moved at all." }
        Items = []
        Exits = { 
            West = PassableExit ({ Name = "Path back to the field"; Description = "The central field lies in that direction." }, RoomId "Field")
            North = NoExit None
            South = NoExit None
            East = NoExit (Some { Name = "A shimmering wall of air"; Description = "Looking through it makes your head hurt." })
            } } ]

let player : Player =
    {
        Details = {Name = "Leon"
                   Description = "An average looking guy with a slightly leaner build."}
        Location = RoomId "Field"
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
    world

//Functions and DU for moving
type Direction = North | South | West | East

let rec getDestinationFromExit (exit: Exit) : RoomId option =
    match exit with
    | PassableExit (_, dest) -> Some dest
    | LockedExit (_, _, nextExit) -> getDestinationFromExit nextExit
    | NoExit _ -> None

let move (direction: Direction) (world: World) : World =
    match getRoom world world.Player.Location with
    | None ->
        printfn "You seem to be lost in a void."
        world

    | Some currentRoom ->
        let exit =
            match direction with
            | North -> currentRoom.Exits.North
            | South -> currentRoom.Exits.South
            | East  -> currentRoom.Exits.East
            | West  -> currentRoom.Exits.West

        match exit with
        | PassableExit (details, destination) ->
            printfn "\n%s\n%s\n" details.Name details.Description
            { world with Player = { world.Player with Location = destination } }

        | LockedExit (details, key, next) ->
            let hasKey =
                world.Player.Inventory
                |> List.exists (fun item -> item.Details.Name = key.Details.Name)

            if hasKey then
                match getDestinationFromExit next with
                | Some destination ->
                    printfn "You use the %s to unlock the door and pass through..." key.Details.Name
                    // You can print exit description too if you want here
                    { world with Player = { world.Player with Location = destination } }
                | None ->
                    printfn "You unlocked the door, but it leads nowhere..."
                    world
            else
                printfn "It's locked. You need the %s." key.Details.Name
                world

        | NoExit detailsOpt ->
            match detailsOpt with
            | Some d -> printfn "%s\n%s" d.Name d.Description
            | None -> printfn "You can’t go that way."
            world

//start game?
gameWorld
|> describeCurrentRoom
|> move South
|> describeCurrentRoom