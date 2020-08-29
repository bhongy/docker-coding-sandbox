// from: https://www.youtube.com/watch?v=hsTmLhnzRhE
namespace Examples

module rec Game =
    type Details =
        { Name: string
          Description: string }

    type Item =
        { Details: Details }

    type Exit =
        | PassableExit of Details * destination: Room
        | LockedExit of Details * key: Item * next: Exit
        | NoExit of Option<Details>

    type Exits =
        { North: Exit
          East: Exit
          South: Exit
          West: Exit }

    type Room =
        { Details: Details
          Items: Item list
          Exits: Exits }

    let firstRoom =
        { Details =
              { Name = "First Room"
                Description = "You're standing in a room" }
          Items = []
          Exits =
              { North = NoExit(None)
                East = NoExit(None)
                South = NoExit(None)
                West = NoExit(None) } }
