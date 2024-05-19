using System.Windows.Documents;
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

public class EditCategoryViewModel : ObservableObject
{
    private Category _category = null!;
    public Category Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged(nameof(Category));
        }
    }
    
    private static Category _staticCategory = null!;
    
    public ICommand EditCategoryCommand { get; }

    private readonly CategoryRepository _categoryRepository;
    private readonly ICategoryValidator _categoryValidator;
    private readonly INavigationService _navigationService;

    public EditCategoryViewModel(Category category = null!)
    {
        if (_staticCategory == null!)
            _staticCategory = category;
        
        EditCategoryCommand = new RelayCommand(EditCategoryCommandExecute);

        _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
        IDialogService dialogService = new DialogService();
        _categoryValidator = new CategoryValidator(_categoryRepository, dialogService);
        _navigationService = new CustomNavigationService();
        
        Category = _staticCategory;
    }

    private void EditCategoryCommandExecute(object? obj)
    {
        if (obj is Category category)
        {
            var result = _categoryValidator.IsCategoryNameValid(category.Name);
            if (result)
            {
                _categoryRepository.UpdateItem(category);
                _navigationService.NavigateTo(new CategoriesViewModel());
            }
        }
    }
}