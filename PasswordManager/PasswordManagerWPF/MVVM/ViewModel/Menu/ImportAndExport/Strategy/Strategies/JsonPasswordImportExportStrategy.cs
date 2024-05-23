using System.IO;
using Newtonsoft.Json;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategies;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy.Strategies;

public class JsonPasswordImportExportStrategy : IPasswordImportExportStrategy
{
    public void ExportPasswords(string filePath, IEnumerable<Password> passwords)
    {
        var json = JsonConvert.SerializeObject(passwords, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<Password> ImportPasswords(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Password>>(json);
    }
}