using System.Windows.Input;
using PasswordManagerWPF.Commands.Category;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Services.Navigation;
using PasswordManagerWPF.Utilities.Category;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Categories;

public class AddCategoryViewModel : ObservableObject
{
    private string _name = null!;
    public string CategoryName
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(CategoryName));
        }
    }
    
    public ICommand AddCategoryCommand { get; }

    private readonly CategoryRepository _categoryRepository;
    private readonly ICategoryValidator _categoryValidator;
    private readonly INavigationService _navigationService;

    public AddCategoryViewModel()
    {
        AddCategoryCommand = new RelayCommand(AddCategoryCommandExecute);

        _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
        IDialogService dialogService = new DialogService();
        _categoryValidator = new CategoryValidator(_categoryRepository, dialogService);
        _navigationService = new CustomNavigationService();
    }
    
    private void AddCategoryCommandExecute(object? obj)
    {
        var addCategoryCommand = new AddCategoryCommand(_categoryRepository, _categoryValidator, new Category(CategoryName, UserRepository.CurrentUser.Id));
        if (addCategoryCommand.CanExecute())
        {
            addCategoryCommand.Execute();
            _navigationService.NavigateTo(new CategoriesViewModel());
        }
    }
}