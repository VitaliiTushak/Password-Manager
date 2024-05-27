using System.Windows.Input;
using PasswordManagerWPF.Commands.PasswordCommands;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.UserControls.PasswordElement;

public class PasswordElementViewModel : ObservableObject
{
    //Observable Properties
    private Password _password = null!;
    private Category _category = null!;
    private string _maskedPassword = null!;
    
    public Password Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public Category Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged(nameof(Category));
        }
    }
    public string MaskedPassword
    {
        get => _maskedPassword;
        set
        {
            _maskedPassword = value;
            OnPropertyChanged(nameof(MaskedPassword));
        }
    }
    
    //Fields
    private readonly INavigationService _navigationService;
    
    //Commands
    public ICommand NavigateEditPasswordCommand { get; set; }
    public ICommand NavigateDeletePasswordCommand { get; set; }
    
    public PasswordElementViewModel(Password password)
    {
        Password = password;
        MaskedPassword = new string('*', password.Value.Length);
        var categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
        Category = categoryRepository.GetItem(password.CategoryId);
        
        _navigationService = new CustomNavigationService();
        
        NavigateEditPasswordCommand = new RelayCommand(EditPassword);
        NavigateDeletePasswordCommand = new RelayCommand(DeletePassword);
    }
    
    //Command Handlers
    private void EditPassword(object? obj)
    {
        if (obj is Password password)
            _navigationService.NavigateTo(typeof(EditPasswordViewModel), password);
    }

    private void DeletePassword(object? obj)
    {
        if (obj is Password password)
        {
            var deleteCategoryCommand = new DeletePasswordCommand(password);
            if (deleteCategoryCommand.CanExecute())
            {
                deleteCategoryCommand.Execute();
                _navigationService.NavigateTo(typeof(PasswordsViewModel), password);
            }
        }
    }
}