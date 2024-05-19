using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.UserControls;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Categories;

public class CategoriesViewModel : ObservableObject
{
    public ObservableCollection<CategoryElement> Categories { get; set; }
    public ICommand NavigateAddCategoryCommand { get; set; }

    private readonly INavigationService _navigationService;

    public CategoriesViewModel()
    {
        NavigateAddCategoryCommand = new RelayCommand(AddCategory);
        
        _navigationService = new CustomNavigationService();
        
        var categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
        
        var categories = categoryRepository.GetItems();
        var categoryElements = new ObservableCollection<CategoryElement>();
        foreach (var category in categories)
        {
            categoryElements.Add(new CategoryElement(category));
        }
        
        Categories = categoryElements;
    }

    private void AddCategory(object? obj)
    {
        _navigationService.NavigateTo(new AddCategoryViewModel());
    }
}