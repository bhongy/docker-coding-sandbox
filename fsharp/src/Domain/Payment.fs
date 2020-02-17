module Domain.Payment

module Check =
    type Number = Number of string

module CreditCard =
    // type Type = Type of string
    type Type =
        | Visa
        | Mastercard
        | AmericanExpress

    type Number = Number of string

    type Info =
        { Type: Type
          Number: Number }

// closed set of options
// all choices in one place
// extra data is obvious
type Method =
    | Cash
    | Check of Check.Number
    // | CreditCard of CreditCard.Info
    | CreditCard of CreditCard.Type * CreditCard.Number

type Amount = Amount of decimal

type Currency =
    | EUR
    | USD

// This is the default type and the name should be `Domain.Payment`
// is there a way to do that as `Domain.Payment` is the namespace?
// what's the better name?
type Info =
    { Amount: Amount
      Currency: Currency
      Method: Method }

type Failure =
    | CardTypeNotRecognized
    | PaymentRejected
    | PaymentProviderOffline

// * methods *

type ConvertCurrency = Info -> Currency -> Info

type Print = Info -> string

// TEMPORARY
let printMethod (method: Method): string =
    match method with
    | Cash -> sprintf "Paid in cash."
    | Check number -> sprintf "Paid by check: %A" number
    | CreditCard(type', number) -> sprintf "Paid with %A %A" type' number
