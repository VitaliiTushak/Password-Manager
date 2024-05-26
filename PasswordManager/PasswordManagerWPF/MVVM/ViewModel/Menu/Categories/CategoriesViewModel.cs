using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.UserControls.CategoryElements;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Categories
{
    public class CategoriesViewModel : ObservableObject
    {
        //Observable Properties
        public ObservableCollection<CategoryElement> Categories { get; set; } = null!;

        //Fields
        private readonly INavigationService _navigationService;
        
        //Commands
        public ICommand NavigateAddCategoryCommand { get; set; }

        public CategoriesViewModel()
        {
            NavigateAddCategoryCommand = new RelayCommand(NavigateAddCategoryExecution);
            _navigationService = new CustomNavigationService();
            
            InitializeCategories();
        }
        
        private void InitializeCategories()
        {
            var categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
            
            var categories = categoryRepository.GetItems();
            Categories = new ObservableCollection<CategoryElement>();
            foreach (var category in categories)
            {
                Categories.Add(new CategoryElement(category));
            }
        }

        //Command Handlers
        private void NavigateAddCategoryExecution(object? obj)
        {
            _navigationService.NavigateTo(new AddCategoryViewModel());
        }
    }
}