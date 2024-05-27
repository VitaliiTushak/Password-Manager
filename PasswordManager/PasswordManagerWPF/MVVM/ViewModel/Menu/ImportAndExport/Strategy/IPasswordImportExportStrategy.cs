using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy;

public interface IPasswordImportExportStrategy
{
    void ExportPasswords(string filePath, IEnumerable<Password> passwords);
    IEnumerable<Password> ImportPasswords(string filePath);
}