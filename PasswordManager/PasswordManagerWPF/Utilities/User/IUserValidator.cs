namespace PasswordManagerWPF.Utilities.User;

public interface IUserValidator
{
    bool ValidateLogin(string login, string password);
    bool ValidateRegistration(string login, string password, string repeatedPassword);
}