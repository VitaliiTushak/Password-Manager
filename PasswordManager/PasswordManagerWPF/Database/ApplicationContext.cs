using System.IO;
using Microsoft.EntityFrameworkCore;
using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Database;

public class ApplicationContext : DbContext
{
    private string DbPath { get; }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Password> Passwords { get; set; } = null!;
    public DbSet<SecurityMethod> EncryptionMethods { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public ApplicationContext()
    {
        var baseFolder = Environment.CurrentDirectory;
        var basedir = baseFolder.Replace("bin\\Debug\\net8.0-windows", "");
        var path = Path.Combine(basedir, "Database\\PasswordManagerDatabase.db");
        DbPath = path;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

}