using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Commands.PasswordCommands;

public class DeletePasswordCommand(Password password) : PasswordCommand(password)
{
    public override bool CanExecute()
    {
        return PasswordRepository.GetItem(Password.Id) != null!;
    }
    public override void Execute()
    {
        PasswordRepository.RemoveItem(Password);
    }
}