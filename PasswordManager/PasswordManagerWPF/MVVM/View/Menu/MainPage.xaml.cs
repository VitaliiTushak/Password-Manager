using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;
using PasswordManagerWPF.Utilities;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        DataContext = new MenuViewModel();
    }
}