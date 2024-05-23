using System.Globalization;
using System.IO;
using CsvHelper;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategies;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy.Strategies;

public class CsvPasswordImportExportStrategy : IPasswordImportExportStrategy
{
    public void ExportPasswords(string filePath, IEnumerable<Password> passwords)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(passwords);
        }
    }

    public IEnumerable<Password> ImportPasswords(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<Password>().ToList();
        }
    }
}