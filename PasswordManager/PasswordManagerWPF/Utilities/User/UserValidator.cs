using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Services.Dialog;

namespace PasswordManagerWPF.Utilities.User;

public class UserValidator(UserRepository userRepository, IDialogService dialogService) : IUserValidator
{
    private void ShowErrorMessage(string message, string title)
    {
        dialogService.ShowMessage(message, title, DialogType.Error);
    }

    public bool ValidateLogin(string login, string password)
    {
        if (!StringValidator.IsStringValid(login) || !StringValidator.IsStringValid(password))
        {
            ShowErrorMessage("Введіть логін та пароль", "Помилка");
            return false;
        }

        var user = userRepository.GetUserByLogin(login);
        if (user == null!)
        {
            ShowErrorMessage("Такого користувача не існує", "Помилка");
            return false;
        }

        if (user.Password != password)
        {
            ShowErrorMessage("Неправильний пароль", "Помилка");
            return false;
        }

        return true;
    }

    public bool ValidateRegistration(string login, string password, string repeatedPassword)
    {
        if (!StringValidator.IsStringValid(login) || !StringValidator.IsStringValid(password) || !StringValidator.IsStringValid(repeatedPassword))
        {
            ShowErrorMessage("Введіть логін та пароль", "Помилка");
            return false;
        }

        if (password != repeatedPassword)
        {
            ShowErrorMessage("Паролі не співпадають", "Помилка");
            return false;
        }
        
        var user = userRepository.GetUserByLogin(login);
        if (user != null!)
        {
            ShowErrorMessage("Користувач з таким логіном вже існує", "Помилка");
            return false;
        }

        if (!IsPasswordValid(password))
        {
            ShowErrorMessage("Пароль не відповідає вимогам безпеки", "Помилка");
            return false;
        }

        return true;
    }

    private bool IsPasswordValid(string password)
    {
        return password.Length >= 8;
    }
}
