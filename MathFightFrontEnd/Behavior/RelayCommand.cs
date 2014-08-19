using System;
using System.Windows.Input;

namespace MathFightFrontEnd.Behavior
{
    public class RelayCommand : ICommand
    {
        private readonly ExecuteDelegate execute;
        private readonly CanExecuteDelegate canExecute;

        public RelayCommand(ExecuteDelegate execute) : this(execute, null)
        {
        }

        public RelayCommand(ExecuteDelegate execute,
            CanExecuteDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}