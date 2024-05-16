using System.Security.Cryptography.Xml;
using PasswordManagerWPF.Database;
using PasswordManagerWPF.Repositories.RepositoryFactory;

namespace PasswordManagerWPF.Repositories;

public class EncryptionMethodRepository  : IRepository<EncryptionMethod>
{
    private static EncryptionMethodRepository? _instance;
    private readonly ApplicationContext _context;
    private static readonly object Lock = new object();

    public static EncryptionMethodRepository GetInstance(ApplicationContext context)
    {
        if (_instance == null)
        {
            lock (Lock)
            {
                _instance ??= new EncryptionMethodRepository(context);
            }
        }
        
        return _instance;
    }

    private EncryptionMethodRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void AddItem(EncryptionMethod item)
    {
        _context.EncryptionMethods.Add(item);
        _context.SaveChanges();
    }

    public void RemoveItem(EncryptionMethod item)
    {
        _context.EncryptionMethods.Remove(item);
        _context.SaveChanges();
    }

    public void UpdateItem(EncryptionMethod item)
    {
        _context.EncryptionMethods.Update(item);
        _context.SaveChanges();
    }

    public List<EncryptionMethod> GetItems()
    {
        return _context.EncryptionMethods.ToList();
    }

    public EncryptionMethod GetItem(int id)
    {
        return _context.EncryptionMethods.Find(id)!;
    }
}