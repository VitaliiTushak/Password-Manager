using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Categories;

namespace PasswordManagerWPF.MVVM.View.Menu.Categories;

public partial class CategoriesView : Page
{
    public CategoriesView()
    {
        InitializeComponent();
        DataContext = new CategoriesViewModel();
    }
}