using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.Menu;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu;

public class MenuViewModel : ObservableObject
{
    private object _currentViewModel = null!;
    public object CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

    public ICommand NavigateCommand { get; }
    
    
    public MenuViewModel()
    {
        NavigateCommand = new RelayCommand(NavigationExecute);
        
        CurrentViewModel = new DashboardViewModel();
    }

    private void NavigationExecute(object? obj)
    {
        if (obj is string destination)
        {
            CurrentViewModel = destination switch
            {
                "Dashboard" => new DashboardViewModel(),
                "Passwords" => new PasswordsViewModel(),
                "ImportExport" => new ImportExportViewModel(),
                "Settings" => new SettingsViewModel(),
                "About" => new AboutViewModel(),
                _ => throw new ArgumentOutOfRangeException(nameof(destination), destination, null)
            };
        }
    }
}