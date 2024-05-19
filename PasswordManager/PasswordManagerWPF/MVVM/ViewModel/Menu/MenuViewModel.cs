using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.Menu;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu;

public class MenuViewModel : ObservableObject
{
    public ICommand NavigateCommand { get; }
    
    private readonly INavigationService _navigationService;
    
    
    public MenuViewModel()
    {
        NavigateCommand = new RelayCommand(NavigationExecute);
        _navigationService = new CustomNavigationService();
        _navigationService.NavigateTo(new DashboardViewModel());
    }

    private void NavigationExecute(object? obj)
    {
        if (obj is string destination)
        {
            switch (destination)
            {
                case "Dashboard":
                    _navigationService.NavigateTo(new DashboardViewModel());
                    break;
                case "Passwords":
                    //_navigationService.NavigateTo(new PasswordsViewModel());
                    break;
                case "ImportExport":
                    //_navigationService.NavigateTo(new ImportExportViewModel());
                    break;
                case "Settings":
                   // _navigationService.NavigateTo(new SettingsViewModel());
                    break;
                case "About":
                    //_navigationService.NavigateTo(new AboutViewModel());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(destination), destination, null);
            }
        }
    }

}