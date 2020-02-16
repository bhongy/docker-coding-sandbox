namespace Examples

module rec RecursiveModule =
    type Orientation =
        | Up
        | Down

    type PeelState =
        | Peeled
        | Unpeeled

    // This exception depends on the type below.
    exception DontSqueezeTheBananaException of Banana

    type BananaPeal() =
        class
        end

    type Banana(orientation: Orientation) =
        // member val IsPeeled = false with get, set
        member val Orientation = orientation with get, set
        member val Sides: PeelState list = [ Unpeeled; Unpeeled; Unpeeled; Unpeeled ] with get, set

        member self.Peel() = BananaHelpers.peel self
        member self.SqueezeJuiceOut() = raise (DontSqueezeTheBananaException self)

    module BananaHelpers =
        let peel (b: Banana) =
            let flip (banana: Banana) =
                match banana.Orientation with
                | Up ->
                    banana.Orientation <- Down
                    banana
                | Down -> banana

            let peelSides (banana: Banana) =
                banana.Sides
                |> List.map (function
                    | Unpeeled -> Peeled
                    | Peeled -> Peeled)

            match b.Orientation with
            | Up ->
                b
                |> flip
                |> peelSides
            | Down -> b |> peelSides
