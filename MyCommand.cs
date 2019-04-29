using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Metrology
{
    class MyCommand : System.Windows.Input.ICommand
    {
        public delegate bool ICommandOnCanExecute();

        private Action execute;
        private ICommandOnCanExecute canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool Can_Execute
        {
            get { return canExecute(); }
        }

        public MyCommand(Action execute, ICommandOnCanExecute canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;

        }

        public bool CanExecute(object parameter)
        {
            return (this.canExecute == null || Can_Execute);
        }

        public void Execute(object parameter = null)
        {
            this.execute();
        }
    }
}
