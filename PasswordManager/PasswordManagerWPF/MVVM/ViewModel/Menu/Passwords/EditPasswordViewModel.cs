using PasswordManagerWPF.Core;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

public class EditPasswordViewModel : ObservableObject
{
    private Model.Password _password = null!;
    
    public Model.Password Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    
    public EditPasswordViewModel(Model.Password password)
    {
        Password = password;
    }
}