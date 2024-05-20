namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.Strategies
{
    public class ComplexPasswordGenerationStrategy : IGenerationStrategy
    {
        private static readonly Random Random = new();
        private const string AvailableCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";

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