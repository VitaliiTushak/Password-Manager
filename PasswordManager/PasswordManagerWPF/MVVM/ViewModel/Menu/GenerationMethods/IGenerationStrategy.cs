namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods;

public interface IGenerationStrategy
{
    string GeneratePassword(int length);
}