# Assignment 3 – Calculator

A console calculator in C# that demonstrates **method overloading**.
`Sum` and `Multiplication` each have two versions: one for two numbers,
and one for several numbers using `params double[]`.

## Run

```bash
dotnet run
```

> Note: uses European number format – decimal separator is a comma (e.g. `3,5`).

## Menu

| Option | Action |
|--------|--------|
| 1 | Add two numbers |
| 2 | Add several numbers |
| 3 | Multiply two numbers |
| 4 | Multiply several numbers |
| 5 | All calculations (+ − × ÷) |
| 6 | Quit |

## Method overloading

Only addition and multiplication are overloaded for several numbers, because the
order of the numbers does not change the result. Subtraction and division depend
on order, so they stay as two-number methods.

```csharp
public double Sum(double a, double b)              // two numbers
public double Sum(params double[] nums)            // several numbers

public double Multiplication(double a, double b)         // two numbers
public double Multiplication(params double[] nums)       // several numbers
```

## Pseudocode

```
START

DO
    Show the menu (1–6)
    Read the choice

    IF choice is not a number
        Print error
    ELSE
        1: Read two numbers, print Sum(a, b)
        2: Read several numbers, print Sum(numbers[])
        3: Read two numbers, print Multiplication(a, b)
        4: Read several numbers, print Multiplication(numbers[])
        5: Read a number, then loop:
               ask for operator (+ - * /) or '=' to finish
               read next number and apply it to the result
           print final result
        6: Set running = false
        else: Print error

WHILE running is true

END
```