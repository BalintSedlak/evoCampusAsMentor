using BusinessLogic;
using System;
using System.ComponentModel;

namespace ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CommandHandler commandHandler;

        public SendMessageCommand sendMessageCommand { get; set; }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; NotifyPropertyChanged("Message"); }
        }

        public ViewModel()
        {
            commandHandler = new CommandHandler();

            this.commandHandler.CommandEvent += UpdateMessage;

            sendMessageCommand = new SendMessageCommand(this);
            commandHandler.Handle("Initialize");
        }

        private void UpdateMessage(string message)
        {
            Message += Environment.NewLine + message;
        }

        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
