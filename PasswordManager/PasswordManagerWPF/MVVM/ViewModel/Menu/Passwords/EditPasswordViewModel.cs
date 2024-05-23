using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManagerWPF.Commands.Passwords;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords
{
    public class EditPasswordViewModel : ObservableObject
    {
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
        public ICommand EditPasswordCommand { get; set; }

        private readonly INavigationService _navigationService;
        private static Password _staticPassword = null!;

        public EditPasswordViewModel(Password password = null!)
        {
            if (_staticPassword == null!)
            {
                _staticPassword = password;
            }

            Password = _staticPassword;

            EditPasswordCommand = new RelayCommand(EditPasswordCommandExecute);

            var categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
            Categories = new ObservableCollection<Category>(categoryRepository.GetItems());
            SelectedCategory = categoryRepository.GetItem(Password.CategoryId);

            _navigationService = new CustomNavigationService();
        }

        private void EditPasswordCommandExecute(object? obj)
        {
            if (obj is Password password)
            {
                if (SelectedCategory != null!)
                {
                    password.CategoryId = SelectedCategory.Id;
                    var addPasswordCommand = new EditPasswordCommand(password);
                    addPasswordCommand.Execute();

                    _navigationService.NavigateTo(new PasswordsViewModel());
                }
            }
        }
    }
}
