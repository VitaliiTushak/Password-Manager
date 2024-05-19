using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class ImportExportPage : Page
{
    public ImportExportPage()
    {
        InitializeComponent();
        
        DataContext = new ImportExportViewModel();
    }
}