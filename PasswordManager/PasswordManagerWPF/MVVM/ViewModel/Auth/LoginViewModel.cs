using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.Menu;
using PasswordManagerWPF.MVVM.ViewModel.Menu;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Services.Navigation;
using PasswordManagerWPF.Utilities;
using PasswordManagerWPF.Utilities.User;

namespace PasswordManagerWPF.MVVM.ViewModel.Auth;

public class LoginViewModel : ObservableObject
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

    private readonly UserValidator _userValidator;
    private readonly INavigationService _navigationService = new CustomNavigationService();
    
    public ICommand NavigateToRegistrationCommand { get; }
    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        var userRepository = RepositoryFactory.GetInstance().GetUserRepository();
        IDialogService dialogService = new DialogService();
        _userValidator = new UserValidator(userRepository, dialogService);
        
        NavigateToRegistrationCommand = new RelayCommand(ExecuteNavigateToRegistration);
        LoginCommand = new RelayCommand(ExecuteLogin);
    }

    private void ExecuteNavigateToRegistration(object? obj)
    {
        _navigationService.NavigateTo(new RegisterViewModel());
    }

    private void ExecuteLogin(object? obj)
    {
        if (_userValidator.ValidateLogin(Login, Password))
        {
            _navigationService.NavigateTo(new MenuViewModel());
        }
    }
}
