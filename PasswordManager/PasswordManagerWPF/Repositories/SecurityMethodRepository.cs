using PasswordManagerWPF.Database;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;

namespace PasswordManagerWPF.Repositories;

public class SecurityMethodRepository : IRepository<SecurityMethod>
{
    private static SecurityMethodRepository? _instance;
    private readonly ApplicationContext _context;
    private static readonly object Lock = new object();

    public static SecurityMethodRepository GetInstance(ApplicationContext context)
    {
        if (_instance == null)
        {
            lock (Lock)
            {
                _instance ??= new SecurityMethodRepository(context);
            }
        }
        
        return _instance;
    }

    private SecurityMethodRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public void AddItem(SecurityMethod item)
    {
        _context.SecurityMethods.Add(item);
        _context.SaveChanges();
    }

    public void RemoveItem(SecurityMethod item)
    {
        _context.SecurityMethods.Remove(item);
        _context.SaveChanges();
    }

    public void UpdateItem(SecurityMethod item)
    {
        _context.SecurityMethods.Update(item);
        _context.SaveChanges();
    }

    public List<SecurityMethod> GetItems()
    {
        return _context.SecurityMethods.ToList();
    }

    public SecurityMethod GetItem(int id)
    {
        return _context.SecurityMethods.Find(id)!;
    }
}