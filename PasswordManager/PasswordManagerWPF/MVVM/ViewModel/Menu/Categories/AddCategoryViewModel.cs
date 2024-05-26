using System.Windows.Input;
using PasswordManagerWPF.Commands.CategoryCommands;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Categories
{
    public class AddCategoryViewModel : ObservableObject
    {
        //Observable Properties
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
        
        //Fields
        private readonly INavigationService _navigationService;
        
        //Commands
        public ICommand AddCategoryCommand { get; set; }

        public AddCategoryViewModel()
        {
            AddCategoryCommand = new RelayCommand(AddCategoryCommandExecute);
            _navigationService = new CustomNavigationService();
        }
        
        //Command Handlers
        private void AddCategoryCommandExecute(object? obj)
        {
            ExecuteAddCategoryCommand(new Category(CategoryName, UserRepository.CurrentUser.Id));
        }
        
        //Methods
        private void ExecuteAddCategoryCommand(Category category)
        {
            var addCategoryCommand = new AddCategoryCommand(category);
            if (addCategoryCommand.CanExecute())
            {
                addCategoryCommand.Execute();
                _navigationService.NavigateTo(new CategoriesViewModel());
            }
        }
    }
}