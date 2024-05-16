using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.View;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Utilities;
using StringValidator = PasswordManagerWPF.Utilities.StringValidator;

namespace PasswordManagerWPF.MVVM.ViewModel;

public class LoginRegistrationViewModel : ObservableObject
{
    private string _login;
    private string _password;
    private string _repeatedPassword;
    
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
    
    private UserRepository _userRepository;
    
    public ICommand RegisterCommand { get; }
    public ICommand LoginCommand { get; }
    
    public LoginRegistrationViewModel()
    {
        RegisterCommand = new RelayCommand(DoRegister);
        LoginCommand = new RelayCommand(DoLogin);
        
        _userRepository = RepositoryFactory.GetInstance().GetUserRepository();
    }

    private bool CanLogin(object? obj)
    {
        if (StringValidator.IsStringValid(Login) && StringValidator.IsStringValid(Password))
        {
            var user = _userRepository.GetUserByLogin(Login);
            if (user != null)
            {
                return user.Password == Password;
            }
            
            return false;
        }
        
        return false;
    }
    
    private bool CanRegister(object? obj)
    {
        if (StringValidator.IsStringValid(Login) && StringValidator.IsStringValid(Password) && StringValidator.IsStringValid(RepeatedPassword))
        {
            return RepeatedPassword == Password;
        }
        
        return false;
    }

    private void DoLogin(object? obj)
    {
        if (!CanLogin(obj)) return;
        NavigationHelper.NavigateTo(new MainPage());
    }

    private void DoRegister(object? obj)
    {
        if (!CanRegister(obj)) return;
        
        var user = new User(Login, Password);
        _userRepository.AddItem(user);
        
        NavigationHelper.NavigateTo(new MainPage());
    }
}