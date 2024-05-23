using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategies;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy;

public class PasswordImportExportService(IPasswordImportExportStrategy strategy)
{
    public void ExportPasswords(string filePath, IEnumerable<Password> passwords)
    {
        strategy.ExportPasswords(filePath, passwords);
    }

    public IEnumerable<Password> ImportPasswords(string filePath)
    {
        return strategy.ImportPasswords(filePath);
    }
}
