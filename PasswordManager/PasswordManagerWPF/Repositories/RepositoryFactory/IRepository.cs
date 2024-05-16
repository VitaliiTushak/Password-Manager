namespace PasswordManagerWPF.Repositories.RepositoryFactory;

public interface IRepository<T> where T : class
{
    void AddItem(T item);
    void RemoveItem(T item);
    void UpdateItem(T item);
    List<T> GetItems();
    T GetItem(int id);
}