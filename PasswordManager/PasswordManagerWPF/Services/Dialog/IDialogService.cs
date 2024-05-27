namespace PasswordManagerWPF.Services.Dialog;

public interface IDialogService
{
    void ShowMessage(string message, string title, DialogType dialogType);
}
