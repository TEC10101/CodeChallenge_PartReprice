# PartReprice

This is a brief demonstration for an interview code challenge.  It showcases making a piece of software to handle a specific scenario (See: Code challenge scenario).

## Note
After writing the code for about 60-90 mins, I was advised by the recruiter that the company changed the code challenge and to stop immediately.

At that time I polished up what I had, made sure it built and handled the scenario, published here to GitHub, setup the CI Build and Test action yaml, and finalized the code.

### If I were to continue
I'd want some more test cases that handled **Bad Data** situations.
I'd add XML documentation to every method and property.
I'd consider how to make the data methods more generic so that I could handle any record type, not just a PartData record.

## Build using:
- VS2022
- .NET 6
- Windows Forms
- MSTestV2

## Code challenge scenario:
Using Visual Studio 2019 (or higher) and .NET 5.0 (or higher), create a program that takes two text files as
input and outputs a third file like the following sample data:

Part Data File
```
PartID*!*PartDesc*!*Price
1*!*Super Cool Part*!*1.2
2*!*Another Awesome Part*!*1.3
3*!*Expensive Part*!*999.99
```


Part Reprice File
```
PartID*!*Price
1*!*1.3
2*!*1.2
3*!*1000
```

Output File
```
PartID*!*PartDesc*!*Price
1*!*Super Cool Part*!*1.3
2*!*Another Awesome Part*!*1.2
3*!*Expensive Part*!*1000
```

The data from the first file is merged with the second by updating the price. You may create a UI or use
input from the command line to determine file names. Please ensure that both the output is accurate
and the code can be maintained. In order to respect your time and other commitments, this problem is
not intended to be complex. Please submit a clean, maintainable solution, but do not spend more than 3
hours on it.
