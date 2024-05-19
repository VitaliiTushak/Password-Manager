using System.Windows.Controls;
using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.MVVM.View.UserControls;

public partial class CategoryElement : UserControl
{
    public CategoryElement(Category category)
    {
        InitializeComponent();
        DataContext = new CategoryElementViewModel(category);
    }
}