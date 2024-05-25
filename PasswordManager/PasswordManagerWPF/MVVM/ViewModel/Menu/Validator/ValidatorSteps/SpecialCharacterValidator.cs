namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator.ValidatorSteps;

public class SpecialCharacterValidator : PasswordValidatorBase
{
    private readonly char[] _specialCharacters = "!@#$%^&*".ToCharArray();
    public override ValidationResult Validate(string password)
    {
        var validationResult = new ValidationResult();
        if (!password.Any(c => _specialCharacters.Contains(c)))
        {
            validationResult.AddMessage("Password must contain at least one special character");
            return validationResult;
        }
        
        validationResult.AddPassedCheck();
        
        var nextResult = base.Validate(password);
        validationResult.Merge(nextResult);

        return validationResult;
    }
}