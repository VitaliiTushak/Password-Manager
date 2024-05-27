namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator.ValidatorSteps;

public class DigitValidator : PasswordValidatorBase
{
    public override ValidationResult Validate(string password)
    {
        var validationResult = new ValidationResult();
        if (!password.Any(char.IsDigit))
        {
            validationResult.AddMessage("Password must contain at least one digit");
            return validationResult;
        }
        
        validationResult.AddPassedCheck();
        
        var nextResult = base.Validate(password);
        validationResult.Merge(nextResult);

        return validationResult;
    }
}