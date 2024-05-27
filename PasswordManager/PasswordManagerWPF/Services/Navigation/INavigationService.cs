using PasswordManagerWPF.Core;

namespace PasswordManagerWPF.Services.Navigation;

public interface INavigationService
{
    void NavigateTo(Type viewModelType, object parameter = null!);
}