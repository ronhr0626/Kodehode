namespace TrollMixCatalog;

// ---------- GENERIC CLASS ----------
public class Repository<T> : IRepository<T> where T : class
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public T Get(int index)
    {
        return items[index];
    }

    public List<T> GetAll()
    {
        return items;
    }

    public int Count
    {
        get { return items.Count; }
    }

    // --- Added for Oppgave 6 ---

    // Removes one specific item (for example the Italian song).
    public bool Remove(T item)
    {
        return items.Remove(item);
    }

    // Removes ALL items at once, leaving the list empty (Count becomes 0).
    public void Clear()
    {
        items.Clear();
    }
}