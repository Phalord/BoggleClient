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
    internal class RefreshPublicLobbiesCommand : BaseCommand
    {
        private readonly SearchLobbyViewModel searchLobbyViewModel;

        public RefreshPublicLobbiesCommand(SearchLobbyViewModel searchLobbyViewModel)
        {
            this.searchLobbyViewModel = searchLobbyViewModel;
        }

        public override void Execute(object parameter)
        {
            BoggleServiceContractsClient contractsClient =
                new BoggleServiceContractsClient(
                    new InstanceContext(searchLobbyViewModel));

            try
            {
                contractsClient.UpdatePublicLobbies();
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }
    }
}
