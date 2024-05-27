using PasswordManagerWPF.MVVM.Model;
using System.Collections.Generic;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy
{
    public class PasswordImportExportService(IPasswordImportExportStrategy strategy) : IPasswordImportExportStrategy
    {
        public void SetStrategy(IPasswordImportExportStrategy strategy1)
        {
            strategy = strategy1;
        }

        public void ExportPasswords(string filePath, IEnumerable<Password> passwords)
        {
            strategy.ExportPasswords(filePath, passwords);
        }

        public IEnumerable<Password> ImportPasswords(string filePath)
        {
            return strategy.ImportPasswords(filePath);
        }
    }
}