using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu;

public class CategoriesViewModel : ObservableObject
{
    public ICommand AddCategoryCommand { get; set; }
    public ICommand EditCategoryCommand { get; set; }
    public ICommand DeleteCategoryCommand { get; set; }

    private readonly INavigationService _navigationService;
    
    public CategoriesViewModel()
    {
        AddCategoryCommand = new RelayCommand(AddCategory);
        EditCategoryCommand = new RelayCommand(EditCategory);
        DeleteCategoryCommand = new RelayCommand(DeleteCategory);
        
        _navigationService = new CustomNavigationService();
    }

    private void AddCategory(object? obj)
    {
    }

    private void EditCategory(object? obj)
    {
        
    }

    private void DeleteCategory(object? obj)
    {
        
    }
}