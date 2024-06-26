using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManagerWPF.Commands.PasswordCommands;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords
{
    public class EditPasswordViewModel : ObservableObject
    {
        //Observable Properties
        private Category _selectedCategory = null!;
        private Password _password = null!;

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
        public Password Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public ObservableCollection<Category> Categories { get; set; }

        //Fields
        private readonly INavigationService _navigationService;
        
        //Commands
        public ICommand EditPasswordCommand { get; set; }

        public EditPasswordViewModel(Password password)
        {
            Password = password;

            EditPasswordCommand = new RelayCommand(EditPasswordCommandExecute);

            var categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
            Categories = new ObservableCollection<Category>(categoryRepository.GetItems());
            SelectedCategory = categoryRepository.GetItem(Password.CategoryId);

            _navigationService = new CustomNavigationService();
        }

        //Command Handlers
        private void EditPasswordCommandExecute(object? obj)
        {
            EditPassword(Password);
        }
        
        //Methods
        private void EditPassword(Password password)
        {
            if (SelectedCategory != null!)
            {
                password.CategoryId = SelectedCategory.Id;
                var editPasswordCommand = new EditPasswordCommand(password);
                editPasswordCommand.Execute();

                _navigationService.NavigateTo(typeof(PasswordsViewModel));
            }
        }
    }
}
