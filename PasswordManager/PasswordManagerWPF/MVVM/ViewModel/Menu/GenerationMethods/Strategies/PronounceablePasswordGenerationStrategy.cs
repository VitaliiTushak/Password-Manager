namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.Strategies;

public class PronounceablePasswordGenerationStrategy : IGenerationStrategy
{
    private readonly Random _random = new();
    private const string Vowels = "aeiou";
    private const string Consonants = "bcdfghjklmnpqrstvwxyz";

    public string GeneratePassword(int length)
    {
        string password = string.Empty;
        for (int i = 0; i < length; i++)
        {
            password += (i % 2 == 0) ? GetRandomChar(Vowels) : GetRandomChar(Consonants);
        }
        return password;
    }

    private char GetRandomChar(string charSet)
    {
        return charSet[_random.Next(charSet.Length)];
    }
}