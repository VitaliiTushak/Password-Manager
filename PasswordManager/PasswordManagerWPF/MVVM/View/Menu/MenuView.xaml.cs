using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;
using PasswordManagerWPF.Utilities;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class MenuView : Page
{
    public MenuView()
    {
        InitializeComponent();
        DataContext = new MenuViewModel();
    }
}