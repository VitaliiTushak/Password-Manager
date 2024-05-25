namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator.ValidatorSteps;

public class UpperCaseValidator : PasswordValidatorBase
{
    public override ValidationResult Validate(string password)
    {
        var validationResult = new ValidationResult();
        if (!password.Any(char.IsUpper))
        {
            validationResult.AddMessage("Password must contain at least one uppercase character");
            return validationResult;
        }
        
        validationResult.AddPassedCheck();
        
        var nextResult = base.Validate(password);
        validationResult.Merge(nextResult);

        return validationResult;
    }
}