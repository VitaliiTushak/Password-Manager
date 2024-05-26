using System.Windows.Input;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Validator.ValidatorSteps;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator;

public class ValidatorViewModel : ObservableObject
{
    //Observable Properties
    private string _password = null!;
    private string _validationMessages = null!;
    private double _progressValue;
    
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public string ValidationMessages
    {
        get => _validationMessages;
        set
        {
            _validationMessages = value;
            OnPropertyChanged(nameof(ValidationMessages));
        }
    }
    public double ProgressValue
    {
        get => _progressValue;
        set
        {
            _progressValue = value;
            OnPropertyChanged(nameof(ProgressValue));
        }
    }
    
    //Commands
    public ICommand ValidatePasswordCommand { get; set; }
    
    public ValidatorViewModel()
    {
        ValidatePasswordCommand = new RelayCommand(ValidatePasswordCommandExecute);
    }

    //Command Handlers
    private void ValidatePasswordCommandExecute(object? obj)
    {
        if (obj is string password)
        {
            var data = ValidatePassword(password);
            
            var messages = string.Join("\n", data.GetMessages());
            ValidationMessages = messages;
            ProgressValue = data.SuccessPercentage;
        }
    }

    //Methods
    private ValidationResult ValidatePassword(string password)
    {
        var lengthValidator = new LengthValidator();
        var digitValidator = new DigitValidator();
        var lowerCaseValidator = new LowerCaseValidator();
        var upperCaseValidator = new UpperCaseValidator();
        var specialCharacterValidator = new SpecialCharacterValidator();

        lengthValidator
            .SetNext(digitValidator)
            .SetNext(lowerCaseValidator)
            .SetNext(upperCaseValidator)
            .SetNext(specialCharacterValidator);
        
        return lengthValidator.Validate(password);
    }
}