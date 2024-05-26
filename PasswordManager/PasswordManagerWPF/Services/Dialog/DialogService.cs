using System.Windows;

namespace PasswordManagerWPF.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message, string title, DialogType dialogType)
        {
            MessageBoxImage icon = dialogType switch
            {
                DialogType.Error => MessageBoxImage.Error,
                DialogType.Info => MessageBoxImage.Information,
                DialogType.Warning => MessageBoxImage.Warning,
                _ => MessageBoxImage.Information
            };

            MessageBox.Show(message, title, MessageBoxButton.OK, icon);
        }
    }
}

public enum DialogType
{
    Info,
    Warning,
    Error
}