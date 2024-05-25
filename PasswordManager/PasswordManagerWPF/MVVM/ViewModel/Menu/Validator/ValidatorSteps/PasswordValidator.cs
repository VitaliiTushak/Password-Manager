namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator.ValidatorSteps;

public abstract class PasswordValidatorBase : IPasswordValidator
{
    private IPasswordValidator? _nextValidator;

    public IPasswordValidator SetNext(IPasswordValidator next)
    {
        _nextValidator = next;
        return _nextValidator;
    }

    public virtual ValidationResult Validate(string password)
    {
        var result = new ValidationResult();

        if (_nextValidator != null)
        {
            var nextResult = _nextValidator.Validate(password);
            result.Merge(nextResult);
        }

        return result;
    }
}