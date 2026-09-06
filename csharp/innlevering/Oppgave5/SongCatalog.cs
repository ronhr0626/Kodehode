using System.Diagnostics;

namespace TrollMixCatalog;

// ---------- DOMAIN LOGIC ----------
public class SongCatalog
{
    private readonly IRepository<Song> repository;

    public string ArtistName => "TrollMix";
    public string SpotifyUrl => "https://open.spotify.com/artist/7xSleEuvzeDXQnyAuRZVIw";

    public SongCatalog(IRepository<Song> repository)
    {
        this.repository = repository;
    }

    public void Add(Song song) => repository.Add(song);
    public int Count => repository.Count;
    public List<Song> GetAll() => repository.GetAll();

    public List<Song> FindByLanguage(string language) =>
        repository.GetAll()
            .Where(s => s.Language.Equals(language, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public List<Song> FindByGenre(string genre) =>
        repository.GetAll()
            .Where(s => s.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public void OpenSpotify()
    {
        Process.Start(new ProcessStartInfo(SpotifyUrl) { UseShellExecute = true });
    }
}