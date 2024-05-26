namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.Strategies;

public class AlphanumericPasswordGenerationStrategy : IGenerationStrategy
{
    private readonly Random _random = new();

    public string GeneratePassword(int length)
    {
        const string alphanumericChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return GeneratePasswordFromChars(alphanumericChars, length);
    }

    private string GeneratePasswordFromChars(string chars, int length)
    {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}