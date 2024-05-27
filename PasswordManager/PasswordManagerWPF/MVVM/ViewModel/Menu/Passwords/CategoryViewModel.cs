using System.Collections.ObjectModel;
using PasswordManagerWPF.MVVM.View.UserControls.PasswordElements;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

public class CategoryViewModel
{
    public string CategoryName { get; set; } = null!;
    public ObservableCollection<PasswordElement> CategoryPasswords { get; set; } = null!;

    public CategoryViewModel()
    {
    }
}