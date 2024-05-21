using System.Windows.Input;
using PasswordManagerWPF.Commands.Category;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Categories;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.UserControls.CategoryElement;

public class CategoryElementViewModel : ObservableObject
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
    
    public ICommand NavigateEditCategoryCommand { get; set; }
    public ICommand NavigateDeleteCategoryCommand { get; set; }
    
    private readonly INavigationService _navigationService;
    public CategoryElementViewModel(Category category)
    {
        Category = category;
        _navigationService = new CustomNavigationService();
        
        NavigateEditCategoryCommand = new RelayCommand(EditCategory);
        NavigateDeleteCategoryCommand = new RelayCommand(DeleteCategory);
    }
    
    private void EditCategory(object? obj)
    {
        if (obj is Category category)
            _navigationService.NavigateTo(new EditCategoryViewModel(category));
        
    }

    private void DeleteCategory(object? obj)
    {
        if (obj is Category category)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand(category);
            if (deleteCategoryCommand.CanExecute())
            {
                deleteCategoryCommand.Execute();
                _navigationService.NavigateTo(new CategoriesViewModel());
            }
        }
    }
}