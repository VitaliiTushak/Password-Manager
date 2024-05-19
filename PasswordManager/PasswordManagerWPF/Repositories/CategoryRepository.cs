using PasswordManagerWPF.Database;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;

namespace PasswordManagerWPF.Repositories;

public class CategoryRepository : IRepository<Category>
{
    private static CategoryRepository? _instance;
    private readonly ApplicationContext _context;
    private static readonly object Lock = new object();

    public static CategoryRepository GetInstance(ApplicationContext context)
    {
        if (_instance == null)
        {
            lock (Lock)
            {
                _instance ??= new CategoryRepository(context);
            }
        }
        
        return _instance;
    }

    private CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }
    public void AddItem(Category item)
    {
        _context.Categories.Add(item);
        _context.SaveChanges();
    }

    public void RemoveItem(Category item)
    {
        _context.Categories.Remove(item);
        _context.SaveChanges();
    }

    public void UpdateItem(Category item)
    {
        _context.Categories.Update(item);
        _context.SaveChanges();
    }

    public List<Category> GetItems()
    {
        return _context.Categories.Where(category => category.UserId == UserRepository.CurrentUser.Id).ToList();
    }

    public Category GetItem(int id)
    {
        return _context.Categories.Find(id)!;
    }

    public object GetCategoryByName(string name)
    {
        return _context.Categories.FirstOrDefault(x => x.Name == name)!;
    }
}