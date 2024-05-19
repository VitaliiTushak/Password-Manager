namespace PasswordManagerWPF.Commands.Category;

public interface ICategoryCommand
{
    public bool CanExecute();
    public void Execute();
}