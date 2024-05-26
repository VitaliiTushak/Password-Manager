using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Auth;

namespace PasswordManagerWPF.MVVM.View.Auth;

public partial class LoginView : Page
{
    public LoginView()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
    }
}