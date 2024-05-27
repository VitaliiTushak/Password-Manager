using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Commands.PasswordCommands;

public class AddPasswordCommand(Password password) : PasswordCommand(password)
{
    public override void Execute()
    {
        PasswordRepository.AddItem(Password);
    }
}