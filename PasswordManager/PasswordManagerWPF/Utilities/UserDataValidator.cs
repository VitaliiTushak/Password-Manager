namespace PasswordManagerWPF.Utilities;

public class UserDataValidator
{
    public static bool IsPasswordValid(string password)
    {
        return StringValidator.IsStringValid(password) && password.Length >= 8;
    }
}