namespace PasswordManagerWPF.Utilities;

public static class StringValidator
{
    public static bool IsStringValid(string str)
    {
        return !string.IsNullOrEmpty(str);
    }
}