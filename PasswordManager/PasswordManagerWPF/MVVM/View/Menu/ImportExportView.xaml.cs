using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class ImportExportView : Page
{
    public ImportExportView()
    {
        InitializeComponent();
        
        DataContext = new ImportExportViewModel();
    }
}