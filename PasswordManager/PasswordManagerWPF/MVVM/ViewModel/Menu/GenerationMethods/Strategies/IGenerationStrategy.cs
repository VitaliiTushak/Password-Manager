namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.Strategies;

public interface IGenerationStrategy
{
    string GeneratePassword(int length);
}