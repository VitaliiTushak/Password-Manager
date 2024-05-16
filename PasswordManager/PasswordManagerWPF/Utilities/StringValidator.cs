namespace PasswordManagerWPF.Utilities;

public class StringValidator
{
    public static bool IsStringValid(string str)
    {
        return !string.IsNullOrEmpty(str);
    }
}