using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PasswordManagerWPF.Utilities;

public static class NavigationHelper
{
    private static NavigationService _navigationService = null!;
    
    public static void SetNavigationService(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    
    public static void NavigateTo(Page page)
    {
        _navigationService.Navigate(page);
    }
    
    public static void GoBack()
    {
        if (_navigationService.CanGoBack)
        {
            _navigationService.GoBack();
        }
    }
}