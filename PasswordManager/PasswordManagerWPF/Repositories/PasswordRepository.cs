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
        _context.Passwords.Update(item);
        _context.SaveChanges();
    }

    public List<Password> GetItems()
    {
        var userId = UserRepository.CurrentUser.Id;
        return _context.Passwords.Where(password => password.UserId == userId).ToList();
    }


    public Password GetItem(int id)
    {
        return GetItems().Find(item => item.Id == id)!;
    }
}