# TrollMix Catalog — C# Generics Assignment

A small console app that stores my own music catalog (TrollMix, 26 songs as of 2026-09-05)
using a **generic repository** and an **interface**. Built for the Kodehode
"C# Intermediate: Generic implementation" assignment.

Spotify: https://open.spotify.com/artist/7xSleEuvzeDXQnyAuRZVIw

## What the assignment asked for

**Part 1 — Generic class**
- A generic class using a type parameter `<T>`
- PascalCase for class names, camelCase for fields
- The generic type used with a data structure (`List<T>`)

**Part 2 — Interface and implementation**
- An interface
- A class that implements it

## How this project solves it

| File | Role |
|------|------|
| `Song.cs` | The model — a single song (title, language, genre, year) |
| `IRepository.cs` | The interface (the contract): `Add`, `Get`, `GetAll`, `Count` |
| `Repository.cs` | The generic class `Repository<T>` that implements `IRepository<T>` |
| `SongCatalog.cs` | Domain logic built on top: `FindByLanguage`, `FindByGenre` |
| `Program.cs` | Fills the catalog with all 26 songs and prints them |

`Repository<T>` is fully generic — it works with any reference type. The program
proves this by using the same class for both `Repository<Song>` and `Repository<string>`.

## Optional extras included

- **Constraint:** `where T : class` on both the interface and the class
- **System.Collections.Generic:** uses `List<T>` internally
- **Real-world data:** the actual TrollMix catalog, not made-up examples

## How to run

```
dotnet run
```

The program prints all songs, then filters by language (English only) and by
genre (Disco inspired), then shows the same `Repository<T>` reused with `string`.

## Reflection — how I'd use this in a larger project

Right now `Repository<T>` stores everything in a `List<T>` in memory, so the data
disappears when the program closes. In a real application I would keep the same
`IRepository<T>` interface but swap the implementation:

- A `DatabaseRepository<T>` that reads and writes to SQLite or SQL Server instead
  of a list. Because the rest of the code depends on the **interface**, not on
  `Repository<T>` directly, nothing else would need to change.
- The same generic pattern would work for other types in my own projects — for
  example `Repository<Player>` or `Repository<Item>` in a game, or storing dialog
  lines for a narrative game.

This is the main lesson: programming against the interface (`IRepository<T>`)
instead of the concrete class makes the code flexible and easy to test. I can
give `SongCatalog` a fake repository in a test, or a real database repository in
production, without rewriting the catalog logic itself.

## Note

Music is released under the artist name TrollMix. Lyrics and concepts written by
me (Ronald Helle), produced with AI-assisted tools. The song list is a snapshot
as of 2026-09-05 and may grow.