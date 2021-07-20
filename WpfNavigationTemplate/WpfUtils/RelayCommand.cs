using System;
using System.Diagnostics;
using System.Windows.Input;

namespace WpfApp1.WpfUtils
{

public class RelayCommand : ICommand
{
    private readonly Predicate<object?>? _canExecute;
    private readonly Action<object?> _execute;

    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    [DebuggerStepThrough]
    public bool CanExecute(object? parameters)
    {
        return _canExecute?.Invoke(parameters) ?? true;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object? parameters)
    {
        _execute(parameters);
    }
}

}