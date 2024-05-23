using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

namespace PasswordManagerWPF.MVVM.View.Menu.Passwords;

public partial class PasswordsView : Page
{
    public PasswordsView()
    {
        InitializeComponent();
        DataContext = new PasswordsViewModel();
    }
}