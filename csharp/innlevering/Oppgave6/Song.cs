namespace TrollMixCatalog;

// ---------- MODEL ----------
public class Song
{
    public string Title { get; set; }
    public string Language { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public Song(string title, string language, string genre, int year)
    {
        Title = title;
        Language = language;
        Genre = genre;
        Year = year;
    }

    public override string ToString() => $"{Title} [{Language}] - {Genre} ({Year})";
}