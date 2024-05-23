using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategies;

public interface IPasswordImportExportStrategy
{
    void ExportPasswords(string filePath, IEnumerable<Password> passwords);
    IEnumerable<Password> ImportPasswords(string filePath);
}