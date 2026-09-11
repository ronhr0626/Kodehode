namespace TrollMixCatalog;

// ---------- INTERFACE (the contract) ----------
public interface IRepository<T> where T : class
{
    void Add(T item);
    T Get(int index);
    List<T> GetAll();
    int Count { get; }

    // --- Added for Oppgave 6 ---
    bool Remove(T item);
    void Clear();
}