using TrollMixCatalog;

namespace Tests;

// Tests for the generic Repository<T> class.
// We use small, controlled data in each test so we know exactly
// what should happen (Arrange - Act - Assert pattern).
public class RepositoryTests
{
    // --- A: Basic functionality ---

    [Fact]
    public void Add_IncreasesCount_And_ItemIsRetrievable()
    {
        // Arrange
        var repo = new Repository<Song>();
        var song = new Song("Quaranta gradi", "Italian", "Pop", 2026);

        // Act
        repo.Add(song);

        // Assert
        Assert.Equal(1, repo.Count);
        Assert.Equal(song, repo.Get(0));
    }

    [Fact]
    public void Remove_RemovesTheItalianSong_And_DecreasesCount()
    {
        // Arrange
        var repo = new Repository<Song>();
        var italian = new Song("Quaranta gradi", "Italian", "Pop", 2026);
        var english = new Song("Bought The Dip", "English", "Indie-pop", 2026);
        repo.Add(italian);
        repo.Add(english);

        // Act
        var removed = repo.Remove(italian);

        // Assert
        Assert.True(removed);
        Assert.Equal(1, repo.Count);
        Assert.Equal(english, repo.Get(0));
    }

    [Fact]
    public void Clear_EmptiesTheRepository()
    {
        // Arrange
        var repo = new Repository<Song>();
        repo.Add(new Song("A", "English", "Pop", 2026));
        repo.Add(new Song("B", "Norwegian", "Pop", 2026));
        repo.Add(new Song("C", "German", "Pop", 2026));

        // Act
        repo.Clear();

        // Assert
        Assert.Equal(0, repo.Count);
    }

    // --- B: Works for multiple types (generic contract) ---

    [Fact]
    public void Repository_WorksWithStrings_NotJustSongs()
    {
        // Arrange
        var repo = new Repository<string>();

        // Act
        repo.Add("2025");
        repo.Add("2026");

        // Assert
        Assert.Equal(2, repo.Count);
        Assert.Equal("2025", repo.Get(0));
    }

    // --- C: Edge case / error handling ---

    [Fact]
    public void Get_WithInvalidIndex_ThrowsException()
    {
        // Arrange
        var repo = new Repository<Song>();
        repo.Add(new Song("Only one", "English", "Pop", 2026));

        // Act + Assert: index 5 does not exist, so it should throw
        Assert.Throws<ArgumentOutOfRangeException>(() => repo.Get(5));
    }
}