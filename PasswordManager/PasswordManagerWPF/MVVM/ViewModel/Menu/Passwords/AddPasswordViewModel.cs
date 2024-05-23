using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

public class AddPasswordViewModel : ObservableObject
{
    private string _passwordName = null!;
    private string _passwordValue = null!;
    private Category _selectedCategory = null!;

    public string PasswordName
    {
        get => _passwordName;
        set
        {
            if (_passwordName != value)
            {
                _passwordName = value;
                OnPropertyChanged(nameof(PasswordName));
            }
        }
    }
    public string PasswordValue
    {
        get => _passwordValue;
        set
        {
            if (_passwordValue != value)
            {
                _passwordValue = value;
                OnPropertyChanged(nameof(PasswordValue));
            }
        }
    }
    public Category SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (_selectedCategory != value)
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
    }
    
    public ObservableCollection<Category> Categories { get; set; }
    private readonly CategoryRepository _categoryRepository;
    public ICommand AddPasswordCommand { get; set; }
    
    public AddPasswordViewModel()
    {
        AddPasswordCommand = new RelayCommand(AddPasswordCommandExecute);

        _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
        Categories = new ObservableCollection<Category>(_categoryRepository.GetItems());
    }

    private void AddPasswordCommandExecute(object? obj)
    {
        if (SelectedCategory != null!)
        {
            var password = new Password(
                PasswordName,
                PasswordValue,
                UserRepository.CurrentUser.Id, 
                _categoryRepository.GetCategoryByName(SelectedCategory.Name).Id
                );
        }
    }
}