using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Services.Dialog;

namespace PasswordManagerWPF.Utilities.User;

public class UserValidator(UserRepository userRepository, IDialogService dialogService) : IUserValidator
    {
        public bool ValidateLogin(string login, string password)
        {
            if (!StringValidator.IsStringValid(login) || !StringValidator.IsStringValid(password))
            {
                dialogService.ShowMessage("Введіть логін та пароль", "Помилка", DialogType.Error);
                return false;
            }

            var user = userRepository.GetUserByLogin(login);
            if (user == null!)
            {
                dialogService.ShowMessage("Такого користувача не існує", "Помилка", DialogType.Error);
                return false;
            }

            if (user.Password != password)
            {
                dialogService.ShowMessage("Неправильний пароль", "Помилка", DialogType.Error);
                return false;
            }

            return true;
        }

        public bool ValidateRegistration(string login, string password, string repeatedPassword)
        {
            if (!StringValidator.IsStringValid(login) || !StringValidator.IsStringValid(password) || !StringValidator.IsStringValid(repeatedPassword))
            {
                dialogService.ShowMessage("Введіть логін та пароль", "Помилка", DialogType.Error);
                return false;
            }

            if (password != repeatedPassword)
            {
                dialogService.ShowMessage("Паролі не співпадають", "Помилка", DialogType.Error);
                return false;
            }
            
            var user = userRepository.GetUserByLogin(login);
            if (user != null!)
            {
                dialogService.ShowMessage("Користувач з таким логіном вже існує ", "Помилка", DialogType.Error);
                return false;
            }

            if (!IsPasswordValid(password))
            {
                dialogService.ShowMessage("Пароль не відповідає вимогам безпеки", "Помилка", DialogType.Error);
                return false;
            }

            return true;
        }

        private bool IsPasswordValid(string password)
        {
            return password.Length >= 8;
        }
    }

