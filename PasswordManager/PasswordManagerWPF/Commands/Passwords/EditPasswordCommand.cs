using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Commands.Passwords;

public class EditPasswordCommand(Password password) : PasswordCommand(password)
{
    public override void Execute()
    {
        PasswordRepository.UpdateItem(Password);
    }
}