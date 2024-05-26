using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Auth;

namespace PasswordManagerWPF.MVVM.View.Auth;

public partial class RegisterView : Page
{
    public RegisterView()
    {
        InitializeComponent();
        DataContext = new RegisterViewModel();
    }
}