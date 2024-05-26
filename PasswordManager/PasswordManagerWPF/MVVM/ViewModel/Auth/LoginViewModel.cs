using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.ViewModel.Menu;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Services.Navigation;
using PasswordManagerWPF.Utilities.User;

namespace PasswordManagerWPF.MVVM.ViewModel.Auth
{
    public class LoginViewModel : ObservableObject
    {
        //Observable Properties
        private string _login = null!;
        private string _password = null!;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        
        //Fields
        private readonly UserRepository _userRepository;
        private readonly UserValidator _userValidator;
        private readonly INavigationService _navigationService = new CustomNavigationService();
        
        //Commands
        public ICommand NavigateToRegistrationCommand { get; }
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _userRepository = RepositoryFactory.GetInstance().GetUserRepository();
            IDialogService dialogService = new DialogService();
            _userValidator = new UserValidator(_userRepository, dialogService);
            
            NavigateToRegistrationCommand = new RelayCommand(ExecuteNavigateToRegistration);
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        //Command Handlers
        private void ExecuteNavigateToRegistration(object? obj)
        {
            _navigationService.NavigateTo(new RegisterViewModel());
        }
        private void ExecuteLogin(object? obj)
        {
            if (ValidateAndLogin())
            {
                _navigationService.NavigateTo(new MenuViewModel());
            }
        }

        //Methods
        private bool ValidateAndLogin()
        {
            if (_userValidator.ValidateLogin(Login, Password))
            {
                var user = _userRepository.GetUserByLogin(Login);
                UserRepository.CurrentUser = user;
                return true;
            }
            return false;
        }
    }
}
