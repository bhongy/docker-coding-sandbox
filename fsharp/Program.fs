open System

module PigLatin =
  let toPigLatin (word: string) =
    let isVowel (c: char) =
      match c with
      | 'a' | 'e' | 'i' | 'o' | 'u'
      | 'A' | 'E' | 'I' | 'O' | 'U' -> true
      |_ -> false
    
    if isVowel word.[0] then
        word + "yay"
    else
        word.[1..] + string(word.[0]) + "ay"

// let printGreeting (name: string) =
//   printfn "Hello %s from F#!" name

// [<EntryPoint>]
// let main argv =
//     printGreeting "bhongy"
//     0 // return an integer exit code

[<EntryPoint>]
let main argv =
  for name in argv do
    let newName = PigLatin.toPigLatin name
    printfn "%s in Pig Latin is: %s" name newName
  0
