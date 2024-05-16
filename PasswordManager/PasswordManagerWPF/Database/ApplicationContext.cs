

using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace PasswordManagerWPF.Database;

public class ApplicationContext : DbContext
{
    private string DbPath { get; }
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