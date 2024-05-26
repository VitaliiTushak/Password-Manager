using System.IO;
using Newtonsoft.Json;
using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy.Strategies;
public class JsonPasswordImportExportStrategy : IPasswordImportExportStrategy
{
    public void ExportPasswords(string filePath, IEnumerable<Password> passwords)
    {
        var passwordsWithoutId = passwords.Select(p => new Password
        {
            Name = p.Name,
            Value = p.Value,
            UserId = p.UserId,
            CategoryId = p.CategoryId
        });

        var json = JsonConvert.SerializeObject(passwordsWithoutId, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<Password> ImportPasswords(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Password>>(json)!;
    }
}
