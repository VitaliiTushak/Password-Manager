namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator.ValidatorSteps;

public class LengthValidator : PasswordValidatorBase
{
    private const int MinLength = 8;

    public override ValidationResult Validate(string password)
    {
        var validationResult = new ValidationResult();

        if (password.Length < MinLength)
        {
            validationResult.AddMessage($"Password must be at least {MinLength} characters long");
            return validationResult;
        }

        validationResult.AddPassedCheck();

        var nextResult = base.Validate(password);
        validationResult.Merge(nextResult);

        return validationResult;
    }
}