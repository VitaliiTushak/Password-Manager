using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Auth;

public class RegisterViewModel: ObservableObject
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
    
    public ICommand RegisterCommand { get; }
    
    private readonly UserRepository _userRepository;
    private readonly INavigationService _navigationService;
    public RegisterViewModel()
    {
        RegisterCommand = new RelayCommand(ExecuteRegister);

        _navigationService = new CustomNavigationService();
        _userRepository = RepositoryFactory.GetInstance().GetUserRepository();
    }
    
    private void ExecuteRegister(object? obj)
    {
        if (Password.Equals(RepeatedPassword))
        {
            var user = new User(Login, Password);
            _userRepository.AddItem(user);
            _navigationService.NavigateTo(new LoginViewModel());
        }
    }
}