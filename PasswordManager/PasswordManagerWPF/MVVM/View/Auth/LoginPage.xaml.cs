using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel;

namespace PasswordManagerWPF.MVVM.View.Auth;

public partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();
        DataContext = new LoginRegistrationViewModel();
    }
}