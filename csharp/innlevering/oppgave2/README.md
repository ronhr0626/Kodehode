# Time-Based Greeting

A small C# console program that asks the user for the time of day and responds
with a fitting greeting.

## What it does

1. Asks the user to enter an hour between 0 and 23.
2. Validates the input and keeps asking until a valid number is entered.
3. Prints a greeting based on the time of day.
4. Prints a closing message before the program ends.

## Greetings

| Time (hour) | Greeting        |
|-------------|-----------------|
| 0–5         | Good night      |
| 6–11        | Good morning    |
| 12–17       | Good afternoon  |
| 18–23       | Good evening    |

## Input validation

The program uses `int.TryParse` to check that the input is a real number.
A special detail is the value `0`: it can be both a valid clock time (midnight)
and the fallback value from a failed parse. The program handles this by checking
the `TryParse` return value separately from the number itself, so a real 0 is
accepted while a failed parse is rejected. Input outside the range 0–23 is also
rejected, and the user is asked to try again.

## How to run

​```
dotnet run
​```

## Built with

- C# (.NET)
- Console application