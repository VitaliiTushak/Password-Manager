using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

namespace PasswordManagerWPF.MVVM.View.Menu.Passwords;

public partial class EditPasswordView : Page
{
    public EditPasswordView()
    {
        InitializeComponent();
        DataContext = new EditPasswordViewModel();
    }
}