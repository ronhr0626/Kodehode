# C# Basic – Oppgave 4: MVC og LINQ

A small C# program that reads a Steam games dataset from a CSV file,
maps each row to a C# object, and runs LINQ queries against the data.

## Dataset

Steam Games Dataset (source: Kaggle) – 125,855 games, 39 columns.

The original file is very large (~400 MB), too big for GitHub. We therefore
saved the first 200 rows to `games_sample.csv`, which is included in this repo.
Of those 200, the program only reads the first 50 rows, because the data
further down in the file is not consistently structured — some rows are messy
or incomplete. The first 50 give a clean, reliable slice for the LINQ queries.

Only a few columns are read:
**Name, Price, Recommendations, Estimated owners, Genres**.

## What the program does

1. Reads the first 50 rows from `games_sample.csv`.
2. Parses each row into a `Game` object (using a quote-aware split,
   because one column contains commas inside its values).
3. Skips broken rows that don't have enough columns.
4. Uses LINQ `Where()` to split the games into **paid** and **free**.
5. Prints full info for the paid games.
6. Uses LINQ `Select()` to list the names of the paid games.
7. Prints a control list of the games that were free.

## Pseudocode

```
read all lines from games_sample.csv
skip the header line
take the first 50 rows
for each line:
    split the line (respecting quotes)
    if the row has too few columns: mark as invalid
    otherwise build a Game object with the 5 chosen columns

allGames  = the parsed list of games
paidGames = allGames where Price > 0
freeGames = allGames where Price == 0

print count of total / paid / free
for each paid game: print full info (name, price, recommendations, owners, genres)
print names of all paid games        (Select)
print names of all free games        (control list)
```

## Program flow

```
games_sample.csv
   |
   v
Read lines  ->  Skip header  ->  Take 50 rows
   |
   v
ParseLine + SplitCsv   (text  ->  Game objects)
   |
   v
allGames (List<Game>)
   |
   +--> Where(Price > 0)   -> paidGames  -> full info + Select(names)
   |
   +--> Where(Price == 0)  -> freeGames  -> control list
```

## LINQ requirements

- **Select()** – pulls one property (Name) from all paid games.
- **Where()** – filters the list by price (paid vs. free).

## How to run

```
dotnet run
```

`games_sample.csv` is included in the repo and read directly from the project
folder, so no extra setup is needed. To use the full dataset, download it from
Kaggle and adjust the filename in the code.