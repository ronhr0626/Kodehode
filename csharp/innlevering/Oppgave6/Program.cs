namespace TrollMixCatalog;

// ---------- PROGRAM ----------
public class Program
{
    public static void Main()
    {
        var catalog = new SongCatalog(new Repository<Song>());

        catalog.Add(new Song("Too Hot To Sleep", "English/Dutch", "Nu-disco", 2026));
        catalog.Add(new Song("Saw her on the Central line", "English", "Indie-pop", 2026));
        catalog.Add(new Song("Fløybanene", "Norwegian", "Visepop", 2026));
        catalog.Add(new Song("Tre Minuttar", "Norwegian", "Visepop", 2026));
        catalog.Add(new Song("And I learn to say ich liebe dich", "English/German", "Pop", 2026));
        catalog.Add(new Song("Bailando contigo", "Spanish", "Latin", 2026));
        catalog.Add(new Song("Two Homes", "English/Indian", "Indie-pop", 2026));
        catalog.Add(new Song("Fjords and Footsteps", "English/Norwegian", "Folk-pop", 2026));
        catalog.Add(new Song("Japanese love or just a style", "English/Japanese", "Pop", 2026));
        catalog.Add(new Song("Månens Hvide Bånd", "Danish", "Visepop", 2026));
        catalog.Add(new Song("Så la det regne", "Norwegian", "Pop", 2026));
        catalog.Add(new Song("Talk with my ai", "English", "Synth-pop", 2026));
        catalog.Add(new Song("Um Dia Vamos Vencer a Noruega", "Portuguese", "Football anthem", 2026));
        catalog.Add(new Song("Ma Chérie", "English/French", "Synth-pop", 2026));
        catalog.Add(new Song("Danse avec moi", "French", "Disco inspired", 2026));
        catalog.Add(new Song("Sommarnattens ljus", "Swedish", "Visepop", 2026));
        catalog.Add(new Song("Bailamos All Night", "English/Spanish", "Latin", 2026));
        catalog.Add(new Song("Disco Night Cleaned", "English", "Disco inspired", 2026));
        catalog.Add(new Song("Når Nøkken Kaller", "Norwegian", "Folk", 2026));
        catalog.Add(new Song("Quaranta gradi", "Italian", "Pop", 2026));
        catalog.Add(new Song("Little Green Men in My Machine", "English", "Disco inspired", 2026));
        catalog.Add(new Song("Someone Else's Coat", "English", "Indie-pop", 2026));
        catalog.Add(new Song("Dansa mig hem", "Swedish", "Pop", 2026));
        catalog.Add(new Song("Bought The Dip", "English", "Indie-pop", 2026));
        catalog.Add(new Song("Herz aus Code", "German", "Disco inspired", 2026));
        catalog.Add(new Song("KRÓL PARKIETU", "English/Polish", "Nu-disco", 2026));

        Console.WriteLine("========================================");
        Console.WriteLine("        ALL MY SONGS - TROLLMIX");
        Console.WriteLine("========================================");
        Console.WriteLine($"Snapshot date: {DateTime.Now:yyyy-MM-dd}");
        Console.WriteLine($"Spotify: {catalog.SpotifyUrl}");
        Console.WriteLine($"Number of songs: {catalog.Count}");
        Console.WriteLine();

        Console.WriteLine("===== ALL SONGS =====");
        foreach (var song in catalog.GetAll())
            Console.WriteLine(song);

        Console.WriteLine();
        Console.WriteLine("===== ENGLISH ONLY =====");
        foreach (var song in catalog.FindByLanguage("English"))
            Console.WriteLine(song);

        Console.WriteLine();
        Console.WriteLine("===== DISCO INSPIRED =====");
        foreach (var song in catalog.FindByGenre("Disco inspired"))
            Console.WriteLine(song);

        // Same generic class with a completely different type - proves reusability
        var numbers = new Repository<string>();
        numbers.Add("2025");
        numbers.Add("2026");
        Console.WriteLine();
        Console.WriteLine($"Same Repository<T> with string: {numbers.Count} items");

        // Uncomment to open the Spotify page in your browser:
        // catalog.OpenSpotify();

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}