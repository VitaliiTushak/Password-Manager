using PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.Strategies;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.StrategyFactory;

public class PasswordGenerationStrategyFactory
{
    public IGenerationStrategy CreateStrategy(StrategyName strategyName)
    {
        return strategyName switch
        {
            StrategyName.Simple => new SimplePasswordGenerationStrategy(),
            StrategyName.Complex => new ComplexPasswordGenerationStrategy(),
            StrategyName.Numeric => new NumericPasswordGenerationStrategy(),
            StrategyName.Alphanumeric => new AlphanumericPasswordGenerationStrategy(),
            StrategyName.Pronounceable => new PronounceablePasswordGenerationStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(strategyName), strategyName, null)
        };
    }
}

public enum StrategyName
{
    Simple,
    Complex,
    Numeric,
    Alphanumeric,
    Pronounceable
}