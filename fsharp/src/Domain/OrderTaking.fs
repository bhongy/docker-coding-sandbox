// from: Domain Modeling Made Functional book (Chapter 5)
// https://www.amazon.com/Domain-Modeling-Made-Functional-Domain-Driven/dp/1680502549
module Domain.OrderTaking

type Undefined = exn

type CustomerInfo = Undefined

type ShippingAddress = Undefined

type BillingAddress = Undefined

type OrderLine =
    { Product: Undefined
      Quantity: Undefined
      Price: Undefined }

type BillingAmount = Undefined

type Order =
    { CustomerInfo: CustomerInfo
      ShippingAddress: ShippingAddress
      BillingAddress: BillingAddress
      OrderLines: List<OrderLine>
      AmountToBill: BillingAmount }

// string starting with "W" then 4 digits
type WidgetCode = Undefined

// string starting with "G" then 3 digits
type GizmoCode = Undefined

type ProductCode =
    | Widget of WidgetCode
    | Gizmo of GizmoCode

// integer between 1 and 1000
type UnitQuantity = Undefined

// decimal between 0.05 and 100.0
type KilogramQuantity = Undefined

type OrderQuantity =
    | Unit of UnitQuantity
    | Kilogram of KilogramQuantity

// Workflow

(*
data UnvalidatedOrder =
    UnvalidatedCustomerInfo
    AND UnvalidatedShippingAddress
    AND UnvalidatedBillingAddress
    AND list of UnvalidatedOrderLine

data UnvalidatedOrderLine =
    UnvalidatedProductCode
    AND UnvalidatedOrderQuantity
*)
type UnvalidatedOrder = Undefined

(*
data ValidatedOrder =
    ValidatedCustomerInfo
    AND ValidatedShippingAddress
    AND ValidatedBillingAddress
    AND list of ValidatedOrderLine

data ValidatedOrderLine =
    ValidatedProductCode
    AND ValidatedOrderQuantity

data PricedOrder =
    ValidatedCustomerInfo
    AND ValidatedShippingAddress
    AND ValidatedBillingAddress
    AND list of PricedOrderLine // different from ValidatedOrderLine
    AND AmountToBill

data PricedOrderLine =
    ValidatedOrderLine
    AND LinePrice
*)

type ValidatedOrder = Undefined

type ValidationError =
    { FieldName: string
      ErrorDescription: string }

// encapsulate all effects (async, error) so the primary output is clear
type ValidationResponse<'a> = Async<Result<'a, List<ValidationError>>>

type ValidateOrder = UnvalidatedOrder -> ValidationResponse<ValidatedOrder>

type AcknoledgementSent = Undefined

type OrderPlaced = Undefined

type BillableOrderPlaced = Undefined

type PlaceOrderEvents =
    { AcknoledgementSent: AcknoledgementSent
      OrderPlaced: OrderPlaced
      BillableOrderPlaced: BillableOrderPlaced }

type PlaceOrder = UnvalidatedOrder -> PlaceOrderEvents
(*
workflow: PlaceOrder =
    input: OrderForm
    output:
        OrderPlaced event (put on a pile to send to other teams)
        OR InvalidOrder (put on appropriate pile)

    // step 1
    do ValidateOrder
    If order is invalid then:
        add InvalidOrder to pile
        stop

    // step 2
    do PriceOrder

    // step 3
    do SendAcknowledgementToCustomer

    // step 4
    return OrderPlaced event (if no errors)

substep ValidateOrder =
    input: UnvalidatedOrder
    output: ValidatedOrder OR ValidationError
    dependencies: CheckProductCodeExists, CheckAddressExists

    validate the customer name
    check that the shipping and billing address exist
    for each line:
        check product code syntax
        check that product code exists in ProductCatalog

    if evertyhing is OK, then:
        return ValidatedOrder
    else:
        return ValidationError

substep PriceOrder =
    input: ValidatedOrder
    output: PricedOrder
    dependencies: GetProducePrice

    for each line:
        get the price for the product
        set the price for the line

    set the amount to bill (= sum of the line prices)

substep SendAcknowledgementToCustomer =
    input: PricedOrder
    output: None

    create acknowledgement letter
    send the acknowledgement letter and the priced order to the customer
*)
