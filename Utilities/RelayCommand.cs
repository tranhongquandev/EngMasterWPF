using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EngMasterWPF.Utilities
{
   public class RelayCommand(Func<object?, bool> canExecute,Action<object?> execute) : ICommand
   {
        private Action<object?> _execute = execute;
        private Func<object?, bool> _canExecute = canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        
    }

    public class RelayCommand<T>(Func<T?, bool> canExecute, Action<T?> execute) : ICommand
    {
        private Action<T?> _execute = execute;
        private Func<T?, bool> _canExecute = canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute((T)parameter!);
        }

        public void Execute(object? parameter)
        {
            _execute((T)parameter!);
        }


    }
}
