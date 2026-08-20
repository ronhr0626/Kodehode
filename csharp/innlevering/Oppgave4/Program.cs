using System.Globalization;

// =====================================================================
//  Oppgave 4 – MVC / LINQ-utforsking
//  This program reads games from a Steam dataset (source: Kaggle).
// =====================================================================
//
//  About the dataset:
//  The original Kaggle file is very large (~400 MB), too big for GitHub.
//  We therefore saved the first 200 rows to "games_sample.csv" for the repo.
//  From those 200 we only read 50 rows, because the data further down in the
//  file is not consistently structured — some rows are messy or incomplete.
//  Reading the first 50 gives a clean, reliable slice for demonstrating LINQ.
//
//  What the program does:
//  It reads a slice of rows, maps each row to a Game object, then uses LINQ
//  Where() to split the games into paid and free. Paid games are shown with
//  full info; free games are collected in a control list.
//
//  One column contained commas inside its values, which required a custom
//  split function (SplitCsv) that respects quotes to parse the line correctly.
//
//  Selected columns: Name, Price, Recommendations, Estimated owners, Genres.
//
//  Note: This is a LINQ learning exercise. The point is not the most efficient
//  program, but to clearly show Select() and Where() on their own. That is why
//  the names are printed as a separate, isolated Select() — to demonstrate the
//  command cleanly and visibly for whoever grades it.
// =====================================================================


// --- Read a slice of the file and build Game objects ---
var allGames = File.ReadAllLines("games_sample.csv")
    .Skip(1)                            // skip the header line (column names)
    .Take(50)                           // read the first 50 rows (clean slice)
    .Select(line => ParseLine(line))    // turn each text line into a Game object
    .ToList();


// --- WHERE: split the checked games into paid and free using LINQ ---
var paidGames = allGames.Where(g => g.Price > 0).ToList();    // games that cost money
var freeGames = allGames.Where(g => g.Price == 0).ToList();   // games that are free

Console.WriteLine($"Checked {allGames.Count} games total.");
Console.WriteLine($"  Paid: {paidGames.Count}");
Console.WriteLine($"  Free: {freeGames.Count}\n");


// --- Show ALL info for each PAID game ---
Console.WriteLine("=== Paid games (full info) ===");
foreach (var g in paidGames)
{
    Console.WriteLine($"{g.Name}");
    Console.WriteLine($"  Price:           {g.Price}");
    Console.WriteLine($"  Recommendations: {g.Recommendations}");
    Console.WriteLine($"  Owners:          {g.EstimatedOwners}");
    Console.WriteLine($"  Genres:          {g.Genres}");
    Console.WriteLine();
}


// --- SELECT: the full-info section above is detailed and hard to skim, so here
// we use Select() to pull out just the Name from every paid game. This gives a
// clean title-only overview, and clearly demonstrates the required Select(). ---
Console.WriteLine("=== Paid game names (Select) ===");
var names = paidGames.Select(g => g.Name);
foreach (var name in names)
    Console.WriteLine(name);


// --- Control list: these games were checked and turned out to be free ---
Console.WriteLine("\n=== These games were checked — these were free ===");
foreach (var g in freeGames)
    Console.WriteLine(g.Name);


// 
//  Helper methods
// 

// --- Turn one text line into a Game object ---
Game ParseLine(string line)
{
    var cols = SplitCsv(line);

    // Skip broken rows that don't have enough columns,
    // so a badly formatted line never crashes the program.
    if (cols.Count < 36)
        return new Game { Name = "(invalid row)" };

    return new Game
    {
        Name            = cols[1],
        EstimatedOwners = cols[3],
        // Europe uses ',' as decimal (5,24); the US uses '.' (5.24).
        // This CSV uses '.', so InvariantCulture forces '.' parsing.
        Price           = double.TryParse(cols[6],  NumberStyles.Any, CultureInfo.InvariantCulture, out var p) ? p : 0,
        Recommendations = int.TryParse(cols[26], NumberStyles.Any, CultureInfo.InvariantCulture, out var r) ? r : 0,
        Genres          = cols[35]
    };
}


// --- Split a CSV line, but respect quotes (commas inside "..." are ignored) ---
// got help with this part of the code 
List<string> SplitCsv(string line)
{
    var result = new List<string>();
    var value = "";
    bool inQuotes = false;

    foreach (char c in line)
    {
        if (c == '"')
            inQuotes = !inQuotes;              // toggle: are we inside quotes?
        else if (c == ',' && !inQuotes)
        {
            result.Add(value);                // comma outside quotes = new column
            value = "";
        }
        else
            value += c;                        // normal character, keep building
    }
    result.Add(value);                         // add the last column
    return result;
}



// we give the  gives the property a safe starting value — 
// it starts as an empty string instead of null, so the program won't crash if it's used before it's filled.
//
//Only string needs this. Numbers (int, double) automatically start at 0.
class Game
{
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public int Recommendations { get; set; }
    public string EstimatedOwners { get; set; } = "";
    public string Genres { get; set; } = "";
}