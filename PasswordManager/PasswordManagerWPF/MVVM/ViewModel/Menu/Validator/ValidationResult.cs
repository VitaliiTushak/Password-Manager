namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator;

public class ValidationResult
{
    private List<string> Messages { get; set; } = [];
    private int PassedChecks { get; set; }

    private const int TotalChecks = 5;

    public double SuccessPercentage => PassedChecks / (double)TotalChecks * 100;
    
    public void Merge(ValidationResult other)
    {
        Messages.AddRange(other.Messages);
        PassedChecks += other.PassedChecks;
    }
    
    public void AddMessage(string message) => Messages.Add(message);
    public List<string> GetMessages() => Messages;
    public void AddPassedCheck() => PassedChecks++;
}