let printGreeting (name: string) =
  printfn "Hello %s from F#!" name

[<EntryPoint>]
let main argv =
  for name in argv do
    let newName = App.PigLatin.toPigLatin name
    printfn "%s in Pig Latin is: %s" name newName

  printGreeting "bhongy"
  0 // return an integer exit code
