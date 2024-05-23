using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategies;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy.Strategies;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy;

public static class PasswordImportExportStrategyFactory
{
    public static IPasswordImportExportStrategy CreateStrategy(PasswordImportExportStrategy format)
    {
        return format switch
        {
            PasswordImportExportStrategy.Json => new JsonPasswordImportExportStrategy(),
            PasswordImportExportStrategy.Csv => new CsvPasswordImportExportStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }
}

public enum PasswordImportExportStrategy
{
    Json,
    Csv
}