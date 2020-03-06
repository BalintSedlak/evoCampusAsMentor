using System;
using System.Windows.Input;

namespace ViewModels
{
    public class SendMessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        ViewModel viewModel;

        public SendMessageCommand(ViewModel viewModel) {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {           
                return true;
        }

        public void Execute(object parameter)
        {
            string command = (string)parameter;

            if (!string.IsNullOrEmpty(command))
            {
                viewModel.commandHandler.Handle(command);
            }
        }
    }
}
