using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class DashboardPage : Page
{
    public DashboardPage()
    {
        InitializeComponent();
        
        DataContext = new DashboardViewModel();
    }
}