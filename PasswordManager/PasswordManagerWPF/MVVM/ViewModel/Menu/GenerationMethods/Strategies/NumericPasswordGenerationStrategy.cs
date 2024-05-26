namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.Strategies;

public class NumericPasswordGenerationStrategy : IGenerationStrategy
{
    private readonly Random _random = new();

    public string GeneratePassword(int length)
    {
        const string numericChars = "0123456789";
        return GeneratePasswordFromChars(numericChars, length);
    }

    private string GeneratePasswordFromChars(string chars, int length)
    {
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}