using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class SendMessageCommand : BaseCommand
    {
        private readonly LobbyViewModel lobbyViewModel;
        private readonly string sender;

        public SendMessageCommand(
            LobbyViewModel lobbyViewModel,
            string sender)
        {
            this.lobbyViewModel = lobbyViewModel;
            this.sender = sender;

            lobbyViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            LobbyManagerContractClient contractClient =
                new LobbyManagerContractClient(new InstanceContext(lobbyViewModel));

            try
            {
                contractClient.SendMessage(
                    lobbyViewModel.LobbyCode,
                    lobbyViewModel.MessageText,
                    sender);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !lobbyViewModel
                .MessageText.Length.Equals(string.Empty);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LobbyViewModel.MessageText))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
