let printGreeting (name: string) =
    printfn "Hello %s from F#!" name
  
[<EntryPoint>]
let main argv =
    Examples.Say.hello "bhongy"
    printGreeting "bhongy"
    0 // return an integer exit code
