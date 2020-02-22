// from: https://www.youtube.com/watch?v=Up7LcbGZFuo by Scott Wlaschin
module Domain.Main

open System.Text.RegularExpressions

type Contact' =
    { FirstName: string
      MiddleInitial: string
      LastName: string

      EmailAddress: string
      // true if ownership of email address is confirmed
      IsEmailVerified: bool }

// single choice type
type EmailAddress = EmailAddress of string // like Haskell type with one value constructor

type PhoneNumber = PhoneNumber of string
// they're distinct type so you can't mix up CustomerId and OrderId
type CustomerId = CustomerId of int

type OrderId = OrderId of int

// createEmailAddress : string -> Option<EmailAddress>
let createEmailAddress (s: string): Option<EmailAddress> =
    if Regex.IsMatch(s, @"^\S+@\S+\.\S+$") then Some(EmailAddress s) else None

type String1 = String1 of string

let createString1 (s: string): Option<String1> =
    if s.Length = 1 then Some(String1 s) else None

type String50 = String50 of string

let createString50 (s: string): Option<String50> =
    if s.Length <= 50 then Some(String50 s) else None

type OrderLineQty = OrderLineQty of int

let createOrderLineQty (qty: int): Option<OrderLineQty> =
    if qty > 0 && qty <= 99 then Some(OrderLineQty qty) else None

// because these must be changed together as a group
type PersonalName =
    { FirstName: String50
      MiddleInitial: String1 option // or `Option<String1>
      LastName: String50 }

// because these must be changed together as a group
// then caller can just pass `EmailContactInfo` as a unit
// type EmailContactInfo = {
//   EmailAddress: EmailAddress
//   IsEmailVerified: bool
// }

// Verified Email
// ---
// Rule 1: if the email is changed, the verified flag must be reset to false
// Rule 2: The verified flag can only be set by a special verification service

// make `VerifiedEmail` private to verificationservice
// so the service is the only one who can create it (model the domain)
type VerifiedEmail = VerifiedEmail of EmailAddress

type VerificationHash = VerificationHash of string

type VerificationService = EmailAddress * VerificationHash -> Option<VerifiedEmail>

type EmailContactInfo =
    | Unverified of EmailAddress
    | Verified of VerifiedEmail

// extra requirement: a contact must have an email or a postal address
//   -> revised: a contact must have at least one way of being contacted

type PostalContactInfo =
    { Address1: String50
      Address2: String50 option
      Town: String50
      PostCode: String50 }

type ContactInfo =
    | Email of EmailContactInfo
    | Addr of PostalContactInfo

type Contact =
    { Name: PersonalName
      PrimaryContactInfo: ContactInfo
      SecondaryContactInfo: ContactInfo option }

// type PayInvoice = UnpaidInvoice -> Domain.Payment.Info -> Result<PaidInvoice, Domain.Payment.Failure>
