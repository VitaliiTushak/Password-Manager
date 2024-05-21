using System.Windows.Controls;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.UserControls.PasswordElement;

namespace PasswordManagerWPF.MVVM.View.UserControls.PasswordElements;

public partial class PasswordElement : UserControl
{
    public PasswordElement(Password password)
    {
        InitializeComponent();
        DataContext = new PasswordElementViewModel(password);
    }
}