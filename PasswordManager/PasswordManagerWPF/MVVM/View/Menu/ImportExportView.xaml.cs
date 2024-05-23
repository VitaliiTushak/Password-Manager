using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class ImportExportView : Page
{
    public ImportExportView()
    {
        InitializeComponent();
        
        DataContext = new ImportExportViewModel();
    }
}