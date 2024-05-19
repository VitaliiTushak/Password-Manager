using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu;

namespace PasswordManagerWPF.MVVM.View.Menu;

public partial class CategoriesView : Page
{
    public CategoriesView()
    {
        InitializeComponent();
        DataContext = new CategoriesViewModel();
    }
}