using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Commands.Passwords;

public class DeletePasswordCommand(Password password) : PasswordCommand(password)
{
    public override void Execute()
    {
        PasswordRepository.RemoveItem(Password);
    }
}