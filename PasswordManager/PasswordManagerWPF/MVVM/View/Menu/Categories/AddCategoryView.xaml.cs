using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Categories;

namespace PasswordManagerWPF.MVVM.View.Menu.Categories;

public partial class AddCategoryView : Page
{
    public AddCategoryView()
    {
        InitializeComponent();
        DataContext = new AddCategoryViewModel();
    }
}