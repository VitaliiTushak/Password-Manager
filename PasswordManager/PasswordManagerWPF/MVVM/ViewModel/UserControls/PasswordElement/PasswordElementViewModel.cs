using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.UserControls.PasswordElement;

public class PasswordElementViewModel : ObservableObject
{
    private Password _password = null!;
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
    
    public string MaskedPassword
    {
        get => _maskedPassword;
        set
        {
            _maskedPassword = value;
            OnPropertyChanged(nameof(MaskedPassword));
        }
    }
    
    public ICommand NavigateEditCategoryCommand { get; set; }
    public ICommand NavigateDeleteCategoryCommand { get; set; }
    
    private readonly INavigationService _navigationService;
    
    public PasswordElementViewModel(Password password)
    {
        Password = password;
        MaskedPassword = new string('*', password.Value.Length);
        
        _navigationService = new CustomNavigationService();
        
        NavigateEditCategoryCommand = new RelayCommand(EditCategory);
        NavigateDeleteCategoryCommand = new RelayCommand(DeleteCategory);
    }
    
    private void EditCategory(object? obj)
    {
        if (obj is Password password)
            _navigationService.NavigateTo(new EditPasswordViewModel(password));
        
    }

    private void DeleteCategory(object? obj)
    {
        if (obj is Password password)
        {
           /* var deleteCategoryCommand = new DeletePasswordCommand(category);
            if (deleteCategoryCommand.CanExecute())
            {
                deleteCategoryCommand.Execute();
                _navigationService.NavigateTo(new PasswordsViewModel());
            }*/
        }
    }
}