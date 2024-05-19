using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class AboutPage : Page
{
    public AboutPage()
    {
        InitializeComponent();

        DataContext = new AboutViewModel();
    }
}