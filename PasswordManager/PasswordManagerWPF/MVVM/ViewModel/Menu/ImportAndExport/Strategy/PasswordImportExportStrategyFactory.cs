using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy.Strategies;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy;

public static class PasswordImportExportStrategyFactory
{
    private static IPasswordImportExportStrategy CreateStrategy(PasswordImportExportStrategy format)
    {
        return format switch
        {
            PasswordImportExportStrategy.Json => new JsonPasswordImportExportStrategy(),
            PasswordImportExportStrategy.Csv => new CsvPasswordImportExportStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }
    
    public static IPasswordImportExportStrategy CreatePasswordImportExportStrategy(PasswordImportExportStrategy format)
    {
        var strategy = CreateStrategy(format);
        var strategyGenerator = new PasswordImportExportService(strategy);
        return strategyGenerator;
    }
    
}

public enum PasswordImportExportStrategy
{
    Json,
    Csv
}