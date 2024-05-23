using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.UserControls.PasswordElements;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

public class PasswordsViewModel : ObservableObject
{
    public ObservableCollection<PasswordElement> Passwords { get; set; }
    public ICommand NavigateAddCategoryCommand { get; set; }

    private readonly INavigationService _navigationService;
    
    public PasswordsViewModel()
    {
        NavigateAddCategoryCommand = new RelayCommand(NavigateAddCategoryExecute);
        
        _navigationService = new CustomNavigationService();
        
        var passwordRepository = RepositoryFactory.GetInstance().GetPasswordRepository();
        var passwords = passwordRepository.GetItems();
        Passwords = new ObservableCollection<PasswordElement>();
        foreach (var password in passwords)
        {
            Passwords.Add(new PasswordElement(password));
        }
    }

    private void NavigateAddCategoryExecute(object? obj)
    {
        _navigationService.NavigateTo(new AddPasswordViewModel());
    }
}