using System.Collections.ObjectModel;
using System.Linq;
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
        public ObservableCollection<PasswordElement> Passwords { get; set; }
        public ObservableCollection<CategoryViewModel> CategoryPasswords { get; set; }
        private CategoryRepository _categoryRepository;
        public ICommand NavigateAddCategoryCommand { get; set; }

        private readonly INavigationService _navigationService;

        public PasswordsViewModel()
        {
            NavigateAddCategoryCommand = new RelayCommand(NavigateAddCategoryExecute);

            _navigationService = new CustomNavigationService();

            _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();

            var passwordRepository =
                new PasswordRepositoryDecorator(RepositoryFactory.GetInstance().GetPasswordRepository());
            var allPasswords = passwordRepository.GetItems();
            
            Passwords = new ObservableCollection<PasswordElement>(allPasswords.Select(p => new PasswordElement(p)));
            CategoryPasswords = new ObservableCollection<CategoryViewModel>();
            
            var categories = _categoryRepository.GetItems();
            foreach (var category in categories)
            {
                var categoryViewModel = new CategoryViewModel
                {
                    CategoryName = $"Category {category.Name}",
                    CategoryPasswords = new ObservableCollection<PasswordElement>(
                        allPasswords.Where(p => p.CategoryId == category.Id)
                                    .Select(p => new PasswordElement(p)))
                };
                CategoryPasswords.Add(categoryViewModel);
            }
        }

        private void NavigateAddCategoryExecute(object? obj)
        {
            _navigationService.NavigateTo(new AddPasswordViewModel());
        }
    }

    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public ObservableCollection<PasswordElement> CategoryPasswords { get; set; }
    }
}
