using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Services.Dialog;

namespace PasswordManagerWPF.Utilities.User;

public class UserValidator : IUserValidator
    {
        private readonly UserRepository _userRepository;
        private readonly IDialogService _dialogService;

        public UserValidator(UserRepository userRepository, IDialogService dialogService)
        {
            _userRepository = userRepository;
            _dialogService = dialogService;
        }

        public bool ValidateLogin(string login, string password)
        {
            if (!StringValidator.IsStringValid(login) || !StringValidator.IsStringValid(password))
            {
                _dialogService.ShowMessage("Введіть логін та пароль", "Помилка", DialogType.Error);
                return false;
            }

            var user = _userRepository.GetUserByLogin(login);
            if (user == null)
            {
                _dialogService.ShowMessage("Такого користувача не існує", "Помилка", DialogType.Error);
                return false;
            }

            if (user.Password != password)
            {
                _dialogService.ShowMessage("Неправильний пароль", "Помилка", DialogType.Error);
                return false;
            }

            return true;
        }

        public bool ValidateRegistration(string login, string password, string repeatedPassword)
        {
            if (!StringValidator.IsStringValid(login) || !StringValidator.IsStringValid(password) || !StringValidator.IsStringValid(repeatedPassword))
            {
                _dialogService.ShowMessage("Введіть логін та пароль", "Помилка", DialogType.Error);
                return false;
            }

            if (password != repeatedPassword)
            {
                _dialogService.ShowMessage("Паролі не співпадають", "Помилка", DialogType.Error);
                return false;
            }

            if (!UserDataValidator.IsPasswordValid(password))
            {
                _dialogService.ShowMessage("Пароль не відповідає вимогам безпеки", "Помилка", DialogType.Error);
                return false;
            }

            return true;
        }
    }

