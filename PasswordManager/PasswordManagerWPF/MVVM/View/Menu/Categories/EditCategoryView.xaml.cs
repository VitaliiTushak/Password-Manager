using System.Windows.Controls;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Categories;

namespace PasswordManagerWPF.MVVM.View.Menu.Categories;

public partial class EditCategoryView : Page
{
    public EditCategoryView()
    {
        InitializeComponent();
        DataContext = new EditCategoryViewModel();
    }
}