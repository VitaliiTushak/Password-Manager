namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.Strategies
{
    public class SimplePasswordGenerationStrategy : IGenerationStrategy
    {
        private static readonly Random Random = new();
        private const string AvailableCharacters = "abcdefghijklmnopqrstuvwxyz";

        public string GeneratePassword(int length)
        {
            return GenerateRandomString(length);
        }

        private string GenerateRandomString(int length)
        {
            return new string(Enumerable.Repeat(AvailableCharacters, length)
                .Select(s => s[Random.Next(s.Length)])
                .ToArray());
        }
    }
}