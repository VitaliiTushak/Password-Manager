using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class PasswordsView : Page
{
    public PasswordsView()
    {
        InitializeComponent();
        
        DataContext = new PasswordsViewModel();
    }
}