using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class DashboardView : Page
{
    public DashboardView()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }
}