using System.IO;
using System.Xml.Serialization;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategies;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy.Strategies;

public class XmlPasswordImportExportStrategy : IPasswordImportExportStrategy
{
    public void ExportPasswords(string filePath, IEnumerable<Password> passwords)
    {
        var serializer = new XmlSerializer(typeof(List<Password>));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, passwords.ToList());
        }
    }

    public IEnumerable<Password> ImportPasswords(string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<Password>));
        using (var reader = new StreamReader(filePath))
        {
            return ((List<Password>)serializer.Deserialize(reader)!)!;
        }
    }
}