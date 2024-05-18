using PasswordManagerWPF.Database;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;

namespace PasswordManagerWPF.Repositories;

public class UserRepository : IRepository<User>
{
    private static UserRepository? _instance;
    private readonly ApplicationContext _context;
    private static readonly object Lock = new object();

    public static UserRepository GetInstance(ApplicationContext context)
    {
        if (_instance == null)
        {
            lock (Lock)
            {
                _instance ??= new UserRepository(context);
            }
        }
        
        return _instance;
    }

    private UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void AddItem(User item)
    {
        _context.Users.Add(item);
        _context.SaveChanges();
    }

    public void RemoveItem(User item)
    {
        _context.Users.Remove(item);
        _context.SaveChanges();
    }

    public void UpdateItem(User item)
    {
        _context.Users.Update(item);
        _context.SaveChanges();
    }

    public List<User> GetItems()
    {
        return _context.Users.ToList();
    }

    public User GetItem(int id)
    {
        return _context.Users.Find(id)!;
    }
    
    public User? GetUserByLogin(string login)
    {
        return _context.Users.FirstOrDefault(user => user.Login == login)!;
    }
}