using PasswordManagerWPF.Core;

namespace PasswordManagerWPF.Services.Navigation;

public interface INavigationService
{
    void NavigateTo(ObservableObject viewModel);
}