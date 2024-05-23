using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class ValidatorView : Page
{
    public ValidatorView()
    {
        InitializeComponent();
        DataContext = new ValidatorViewModel();
    }
}