using CsvHelper.Configuration;
using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy.Strategies;

public sealed class PasswordMap : ClassMap<Password>
{
    public PasswordMap()
    {
        Map(p => p.Name).Name("Name");
        Map(p => p.Value).Name("Value");
        Map(p => p.CategoryId).Name("CategoryId");
        Map(p => p.UserId).Name("UserId");
    }
}