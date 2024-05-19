using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.View;
using PasswordManagerWPF.MVVM.View.Auth;
using PasswordManagerWPF.MVVM.View.Menu;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Utilities;
using PasswordManagerWPF.Utilities.User;
using StringValidator = PasswordManagerWPF.Utilities.StringValidator;

namespace PasswordManagerWPF.MVVM.ViewModel;

public class LoginRegistrationViewModel : ObservableObject
{
    private string _login = null!;
    private string _password = null!;
    private string _repeatedPassword = null!;

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
    public string RepeatedPassword
    {
        get => _repeatedPassword;
        set
        {
            _repeatedPassword = value;
            OnPropertyChanged(nameof(RepeatedPassword));
        }
    }

    private readonly UserRepository _userRepository;
    private readonly UserValidator _userValidator;
    
    public ICommand NavigateToRegistrationCommand { get; }
    public ICommand RegisterCommand { get; }
    public ICommand LoginCommand { get; }

    public LoginRegistrationViewModel()
    {
        _userRepository = RepositoryFactory.GetInstance().GetUserRepository();
        IDialogService dialogService = new DialogService();
        _userValidator = new UserValidator(_userRepository, dialogService);
        
        NavigateToRegistrationCommand = new RelayCommand(ExecuteNavigateToRegistration);
        RegisterCommand = new RelayCommand(ExecuteRegister);
        LoginCommand = new RelayCommand(ExecuteLogin);
    }

    private void ExecuteNavigateToRegistration(object? obj)
    {
        NavigationHelper.NavigateTo(new RegisterPage());
    }

    private void ExecuteLogin(object? obj)
    {
        if (_userValidator.ValidateLogin(Login, Password))
        {
            NavigationHelper.NavigateTo(new MainPage());
        }
    }

    private void ExecuteRegister(object? obj)
    {
        if (_userValidator.ValidateRegistration(Login, Password, RepeatedPassword))
        {
            var user = new User(Login, Password);
            _userRepository.AddItem(user);
            NavigationHelper.NavigateTo(new MainPage());
        }
    }
}
