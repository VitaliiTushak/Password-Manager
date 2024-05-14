

using Microsoft.EntityFrameworkCore;

namespace PasswordManagerWPF.Database;

public class ApplicationContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=DESKTOP-1CUNH18\SQLEXPRESS;Database=PasswordManagerDatabase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
    }
}