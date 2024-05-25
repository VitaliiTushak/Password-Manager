namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator;

public interface IPasswordValidator
{
    IPasswordValidator SetNext(IPasswordValidator next);
    ValidationResult Validate(string password);
}