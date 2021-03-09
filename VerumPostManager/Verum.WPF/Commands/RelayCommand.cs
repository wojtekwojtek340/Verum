using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private Action<object> execute;
    private Func<object, bool> canExecute;

    public RelayCommand(Action<object> _execute, Func<object, bool> _canExecute = null)
    {
        if(_execute == null)
        {
            throw new ArgumentNullException(nameof(_execute));           
        }
        else
        {
            execute = _execute;
        }
        canExecute = _canExecute;
    }

    public event EventHandler CanExecuteChanged
    {
        add
        {
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }

    public bool CanExecute(object parameter)
    {
        if(canExecute == null)
        {
            return true;
        }
        else
        {
            return canExecute(parameter);
        }
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }
}

