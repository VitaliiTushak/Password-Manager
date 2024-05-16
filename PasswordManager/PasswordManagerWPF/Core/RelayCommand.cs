using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace PasswordManagerWPF.Core;

public class RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null) : ICommand
{
    private readonly Action<object?>? _execute = execute;
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => canExecute == null || canExecute.Invoke(parameter);

    public void Execute(object? parameter) => _execute?.Invoke(parameter);
}
