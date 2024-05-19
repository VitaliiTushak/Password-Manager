using System.Windows.Input;
using PasswordManagerWPF.Core;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu;

public class PasswordsViewModel
{
    public ICommand OpenPasswordCommand { get; set; }
    public ICommand EditPasswordCommand { get; set; }
    public ICommand DeletePasswordCommand { get; set; }
    
    public PasswordsViewModel()
    {
        OpenPasswordCommand = new RelayCommand(OpenPasswordCommandExecute);
        EditPasswordCommand = new RelayCommand(EditPasswordCommandExecute);
        DeletePasswordCommand = new RelayCommand(DeletePasswordCommandExecute);
    }

    private void OpenPasswordCommandExecute(object? obj)
    {
        throw new NotImplementedException();
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