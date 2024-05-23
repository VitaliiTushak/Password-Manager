using System.Windows.Controls;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.UserControls.CategoryElement;

namespace PasswordManagerWPF.MVVM.View.UserControls.CategoryElements;

public partial class CategoryElement : UserControl
{
    public CategoryElement(Category category)
    {
        InitializeComponent();
        DataContext = new CategoryElementViewModel(category);
    }
}