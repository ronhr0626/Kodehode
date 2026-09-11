namespace TrollMixCatalog;

// ---------- GENERIC CLASS ----------
public class Repository<T> : IRepository<T> where T : class
{
    private readonly List<T> items = new();

    public void Add(T item) => items.Add(item);
    public T Get(int index) => items[index];
    public List<T> GetAll() => items;
    public int Count => items.Count;
}