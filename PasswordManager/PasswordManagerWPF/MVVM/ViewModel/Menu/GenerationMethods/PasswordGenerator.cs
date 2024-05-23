namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods;

public class PasswordGenerator(IGenerationStrategy strategy)
{
    public void SetStrategy(IGenerationStrategy generationStrategy)
    {
        strategy = generationStrategy;
    }

    public string GeneratePassword(int length)
    {
        return strategy.GeneratePassword(length);
    }
}