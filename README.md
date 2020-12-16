# Swiftly Services Coding Exercise

## Overview

To introduce Swiftly to your coding style and technique, we'd like you to do a small coding exercise. This is not a coding test where we give you a score or run it through a suite of tests for correctness.

Our hope is that we can use this to seed a discussion that provides us with an understanding of your design and coding abilities and you with an idea of what working at Swiftly will be like. We believe this better reflects what engineers do than coding common patterns on a white board does.

A link to the spec for what we'd like you to build is at the end of these instructions.

## What We're Looking For

Think of this as real code you would be checking in and shipping to production. Swiftly leverages all of the [SOLID](https://en.wikipedia.org/wiki/SOLID) principles to produce maintainable, testable designs and code. The team will review your code to discuss how comfortable they would be extending your code to support additional business requirements without introducing any regressions.

## Requirements

* Use one of the following modern, statically typed languages: Java, C#, Kotlin, F#, Scala, Go, Swift, etc.
* Do *not* use any file/string parsing libraries
  * You may use native or third party basic string utility functions like trim, pad, format, etc.
* Complete this project on your own
* Use a GitHub repository for source control
  * Email the link to the GitHub repository when you are finished
  * The readme.md file should include (at a minimum)
    * Instructions for running the project (you can create a simple executable wrapper around your library, for example)
    * Link to the latest Continuous Integration build/release
    * Any other information you would normally include when you author a readme
  * This code is your intellectual property
    * License it however you'd like (MIT, Apache or Public Domain are great choices)
    * Ensure the license you choose allows Swiftly employees to read, build, and execute the code for free
* Set up a continuous integration environment using a free, publicly accessible service
    * We recommend AppVeyor (https://www.appveyor.com/) for a project of this size if you don't already have a favorite
    * Configure the CI environment to build directly from your GitHub project when there's a commit to master
    * Ensure that the GitHub readme file is automatically updated with the result of the CI build (AppVeyor has an easy badge that you can embed in your readme.md)
* Email your Swiftly contact the link to the GitHub repository when you're ready to submit your project

If you have any questions, don't hesitate to reach out to your Swiftly contact.

## Product Specification

And without further ado, the product specification for the feature is [here](ProductInformationIntegrationSpec.md).

## Build information ![Build status](https://ci.appveyor.com/api/projects/status/95td8dsivwr16kg9/branch/master?svg=true)

*Appveyor CI build URL:* https://ci.appveyor.com/project/mjsztainbok/code-exercise-services

*Releases on GitHub:* https://github.com/mjsztainbok/code-exercise-services/releases

## Running the project
### Prerequisites
.NET Runtime 5.0 from https://dotnet.microsoft.com/download (although this application can run on Linux and MacOS the release only contains executables for Windows)

### Installing the test program
Download the latest releases from https://github.com/mjsztainbok/code-exercise-services/releases and unzip

### Running the test program
#### Usage
```
ProductInformationIngestionTest.exe [/r] <path to data file>
```

/r - displays the data in single record view instead of a table

#### Sample output
##### Table view
```
┌────────────┬────────────────────┬───────────────────┬───────────────────┬───────────────────┬───────────────────┬─────────────────┬──────────────┬──────────┐
│ Product ID │ Product            │  Regular Display  │          Regular  │     Sale Display  │  Sale Calculator  │ Unit Of Measure │ Product Size │ Tax Rate │
│            │ Description        │             Price │  Calculator Price │             Price │             Price │                 │              │          │
├────────────┼────────────────────┼───────────────────┼───────────────────┼───────────────────┼───────────────────┼─────────────────┼──────────────┼──────────┤
│   80000001 │ Kimchi-flavored    │             $5.67 │              5.67 │                   │                   │ Each            │ 18oz         │ 0%       │
│            │ white rice         │                   │                   │                   │                   │                 │              │          │
│   14963801 │ Generic Soda       │      2 for $13.00 │               6.5 │             $5.49 │              5.49 │ Each            │ 12x12oz      │ 7.775%   │
│            │ 12-pack            │                   │                   │                   │                   │                 │              │          │
│   40123401 │ Marlboro           │            $10.00 │                10 │             $5.49 │              5.49 │ Each            │              │ 0%       │
│            │ Cigarettes         │                   │                   │                   │                   │                 │              │          │
│   50133333 │ Fuji Apples        │             $3.49 │              3.49 │                   │                   │ Pound           │ lb           │ 0%       │
│            │ (Organic)          │                   │                   │                   │                   │                 │              │          │
└────────────┴────────────────────┴───────────────────┴───────────────────┴───────────────────┴───────────────────┴─────────────────┴──────────────┴──────────┘
```

##### Single record view
```
Product ID:                   80000001
Product Description:          Kimchi-flavored white rice
Regular Display Price:        $5.67
Regular Calculator Price:     5.67
Sale Display Price:
Sale Calculator Price:
Unit Of Measure:              Each
Product Size:                 18oz
Tax Rate:                     0%
───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
Product ID:                   14963801
Product Description:          Generic Soda 12-pack
Regular Display Price:        2 for $13.00
Regular Calculator Price:     6.5
Sale Display Price:           $5.49
Sale Calculator Price:        5.49
Unit Of Measure:              Each
Product Size:                 12x12oz
Tax Rate:                     7.775%
───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
Product ID:                   40123401
Product Description:          Marlboro Cigarettes
Regular Display Price:        $10.00
Regular Calculator Price:     10
Sale Display Price:           $5.49
Sale Calculator Price:        5.49
Unit Of Measure:              Each
Product Size:
Tax Rate:                     0%
───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
Product ID:                   50133333
Product Description:          Fuji Apples (Organic)
Regular Display Price:        $3.49
Regular Calculator Price:     3.49
Sale Display Price:
Sale Calculator Price:
Unit Of Measure:              Pound
Product Size:                 lb
Tax Rate:                     0%
```
