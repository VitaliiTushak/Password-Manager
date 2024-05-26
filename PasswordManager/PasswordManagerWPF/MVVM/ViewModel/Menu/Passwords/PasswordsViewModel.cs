using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.UserControls.PasswordElements;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords
{
    public class PasswordsViewModel : ObservableObject
    {
        //Observable Properties
        public ObservableCollection<PasswordElement> Passwords { get; set; } = null!;
        public ObservableCollection<CategoryViewModel> CategoryPasswords { get; set; } = null!;
        private readonly CategoryRepository _categoryRepository;

        //Fields
        private readonly INavigationService _navigationService;
        
        //Commands
        public ICommand NavigateAddCategoryCommand { get; set; }

        public PasswordsViewModel()
        {
            NavigateAddCategoryCommand = new RelayCommand(NavigateAddCategoryExecute);
            _navigationService = new CustomNavigationService();
            _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
        
            LoadPasswords();
        }

        private void LoadPasswords()
        {
            var passwordRepository = new PasswordRepositoryDecorator(RepositoryFactory.GetInstance().GetPasswordRepository());
            var allPasswords = passwordRepository.GetItems();
        
            Passwords = new ObservableCollection<PasswordElement>(allPasswords.Select(p => new PasswordElement(p)));
            CategoryPasswords = new ObservableCollection<CategoryViewModel>();

            var categories = _categoryRepository.GetItems();
            foreach (var category in categories)
            {
                var categoryViewModel = new CategoryViewModel
                {
                    CategoryName = $"CategoryCommands {category.Name}",
                    CategoryPasswords = new ObservableCollection<PasswordElement>(
                        allPasswords.Where(p => p.CategoryId == category.Id)
                            .Select(p => new PasswordElement(p)))
                };
                CategoryPasswords.Add(categoryViewModel);
            }
        }
        
        //Command Handlers
        private void NavigateAddCategoryExecute(object? obj)
        {
            _navigationService.NavigateTo(new AddPasswordViewModel());
        }
    }
}
