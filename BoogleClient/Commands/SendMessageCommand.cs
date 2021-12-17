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
        private readonly Lobby lobby;

        public SendMessageCommand(LobbyViewModel lobbyViewModel,
            string sender, Lobby lobby)
        {
            this.lobbyViewModel = lobbyViewModel;
            this.sender = sender;
            this.lobby = lobby;

            lobbyViewModel.PropertyChanged += OnviewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            LobbyManagerContractClient contractClient =
                new LobbyManagerContractClient(new InstanceContext(lobbyViewModel));

            try
            {
                contractClient.SendMessage(lobby, lobbyViewModel.MessageText, sender);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;//lobbyViewModel.MessageText.Length != 0;
        }

        private void OnviewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LobbyViewModel.MessageText))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
