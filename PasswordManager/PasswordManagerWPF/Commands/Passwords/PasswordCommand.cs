using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;

namespace PasswordManagerWPF.Commands.Passwords;

public abstract class PasswordCommand(Password password)
{
    protected readonly Password Password = password;
    protected readonly PasswordRepository PasswordRepository = RepositoryFactory.GetInstance().GetPasswordRepository();

    public abstract void Execute();
    public virtual bool CanExecute() => true;
}