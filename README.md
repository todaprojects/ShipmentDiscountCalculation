## Shipment Discount Calculation

## `This project is under refactoring...`

## Table of contents

> * [Table of contents](#table-of-contents)
> * [General info](#general-info)
> * [Used technologies & tools](#used-technologies--tools)
> * [Usage](#Usage)
>   * [Requirements](#Requirements)
>   * [Running application](#running-application)

## General Info

#### Requirements
* Write clean and simple code, covered with unit tests, and easy to maintain.
* Using additional libraries is prohibited. That constraint is not applied for unit tests and build.
* Make sure the input data is loaded from a file (default name 'input.txt' is assumed).
* Make sure that solutions outputs data to the screen (STDOUT) in a format described below.
* Application design should be flexible enough to allow adding new rules and modifying existing ones easily.

#### Problem
On the Online Shop, when something is purchased, it has to be shipped and Shop provides various shipping options to its members across the globe. However, let's focus on France. In France, it is allowed to ship via ether 'Mondial Relay' (MR in short) or 'La Poste' (LP). While 'La Poste' provides usual courier delivery services, 'Mondial Relay' allows to drop and pick up a shipment at so-called drop-off point, thus being less convenient, but cheaper for larger packages.
Each item, depending on its size gets an appropriate package size assigned to it:

    S - Small, a popular option to ship jewelry
    M - Medium - clothes and similar items
    L - Large - mostly shoes

Shipping price depends on package size and a provider:

| Provider     | Package Size | Price  |
|--------------|--------------|--------|
| LP           | S            | 1.50 € |
| LP           | M            | 4.90 € |
| LP           | L            | 6.90 € |
| MR           | S            | 2 €    |
| MR           | M            | 3 €    |
| MR           | L            | 4 €    |

Usually, the shipping price is covered by the buyer, but sometimes, in order to promote one or another provider, Vinted covers part of the shipping price.

**The task is to create a shipment discount calculation module.**

First, the following rules have to be implemented:
* All S shipments should always match the lowest S package price among the providers.
* Third L shipment via LP should be free, but only once a calendar month.
* Accumulated discounts cannot exceed 10 € in a calendar month. If there are not enough funds to fully
  cover a discount this calendar month, it should be covered partially.

**Application design should be flexible enough to allow adding new rules and modifying existing ones easily.**

Members transactions are listed in a file 'input.txt', each line containing: date (without hours, in ISO format), package size code and carrier code, separated with whitespace:
```
2015-02-01 S MR
2015-02-02 S MR
2015-02-03 L LP
2015-02-05 S LP
2015-02-06 S MR
2015-02-06 L LP
2015-02-07 L MR
2015-02-08 M MR
2015-02-09 L LP
2015-02-10 L LP
2015-02-10 S MR
2015-02-10 S MR
2015-02-11 L LP
2015-02-12 M MR
2015-02-13 M LP
2015-02-15 S MR
2015-02-17 L LP
2015-02-17 S MR
2015-02-24 L LP
2015-02-29 CUSPS
2015-03-01 S MR
```
A program should output transactions and append reduced shipment price and a shipment discount (or '-' if there is none). The program should append 'Ignored' word if the line format is wrong or carrier/sizes are unrecognized.
```
2015-02-01 S MR 1.50 0.50
2015-02-02 S MR 1.50 0.50
2015-02-03 L LP 6.90 -
2015-02-05 S LP 1.50 -
2015-02-06 S MR 1.50 0.50
2015-02-06 L LP 6.90 -
2015-02-07 L MR 4.00 -
2015-02-08 M MR 3.00 -
2015-02-09 L LP 0.00 6.90
2015-02-10 L LP 6.90 -
2015-02-10 S MR 1.50 0.50
2015-02-10 S MR 1.50 0.50
2015-02-11 L LP 6.90 -
2015-02-12 M MR 3.00 -
2015-02-13 M LP 4.90 -
2015-02-15 S MR 1.50 0.50
2015-02-17 L LP 6.90 -
2015-02-17 S MR 1.90 0.10
2015-02-24 L LP 6.90 -
2015-02-29 CUSPS Ignored
2015-03-01 S MR 1.50 0.50
```

## Used Technologies & Tools
* ASP.NET Core 5.0 - _a cross-platform software framework._
* C# _programming language_

## Usage

### Requirements
* Installed .NET 5.0 SDK on your machine

### Running Application
* Open **ShipmentDiscountCalculation** folder directory on Command Line - "cd" to directory:

  `cd path/to/directory/of/ShipmentDiscountCalculation`


* Start application:

  `dotnet run --project ./ShipmentDiscountCalculation.Application/ShipmentDiscountCalculation.Application.csproj`
