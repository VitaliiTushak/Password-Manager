using System.Windows.Input;
using PasswordManagerWPF.Core;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

public class PasswordsViewModel : ObservableObject
{
    public ICommand EditPasswordCommand { get; set; }
    public ICommand DeletePasswordCommand { get; set; }
    
    public PasswordsViewModel()
    {
        EditPasswordCommand = new RelayCommand(EditPasswordCommandExecute);
        DeletePasswordCommand = new RelayCommand(DeletePasswordCommandExecute);
    }

    private void EditPasswordCommandExecute(object? obj)
    {
        throw new NotImplementedException();
    }

    private void DeletePasswordCommandExecute(object? obj)
    {
        throw new NotImplementedException();
    }
}