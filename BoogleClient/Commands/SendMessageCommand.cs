using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
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
        }

        public override void Execute(object parameter)
        {
            BoggleServiceContractsClient contractsClient =
                new BoggleServiceContractsClient(
                    new InstanceContext(lobbyViewModel));

            try
            {
                contractsClient.SendMessage(lobby, lobbyViewModel.MessageText, sender);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return lobbyViewModel.MessageText.Length > 0;
        }
    }
}
