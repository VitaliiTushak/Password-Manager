using PasswordManagerWPF.Database;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;

namespace PasswordManagerWPF.Repositories;

public class PasswordRepository : IRepository<Password>
{
    private static PasswordRepository? _instance;
    private readonly ApplicationContext _context;
    private static readonly object Lock = new object();

    public static PasswordRepository GetInstance(ApplicationContext context)
    {
        if (_instance == null)
        {
            lock (Lock)
            {
                _instance ??= new PasswordRepository(context);
            }
        }
        
        return _instance;
    }

    private PasswordRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public void AddItem(Password item)
    {
        _context.Passwords.Add(item);
        _context.SaveChanges();
    }

    public void RemoveItem(Password item)
    {
        _context.Passwords.Remove(item);
        _context.SaveChanges();
    }

    public void UpdateItem(Password item)
    {
        throw new NotImplementedException();
    }

    public List<Password> GetItems()
    {
        return _context.Passwords.ToList();
    }

    public Password GetItem(int id)
    {
        return _context.Passwords.Find(id)!;
    }
}