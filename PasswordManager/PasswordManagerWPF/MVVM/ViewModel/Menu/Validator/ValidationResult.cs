namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Validator;

public class ValidationResult
{
    private List<string> Messages { get; set; } = new();
    private int PassedChecks { get; set; } = 0;

    private const int TotalChecks = 5;

    public double SuccessPercentage => (PassedChecks / (double)TotalChecks) * 100;
    
    public void Merge(ValidationResult other)
    {
        Messages.AddRange(other.Messages);
        PassedChecks += other.PassedChecks;
    }
    
    public void AddMessage(string message)
    {
        Messages.Add(message);
    }
    
    public List<string> GetMessages()
    {
        return Messages;
    }
    
    
    public void AddPassedCheck()
    {
        PassedChecks++;
    }
}