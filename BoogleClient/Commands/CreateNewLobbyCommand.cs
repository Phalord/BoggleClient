using BoogleClient.ViewModel;
using BoogleClient.BoggleServices;
using System;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class CreateNewLobbyCommand : BaseCommand
    {
        private readonly LobbyCreationViewModel lobbyCreationViewModel;

        public CreateNewLobbyCommand(
            LobbyCreationViewModel lobbyCreationViewModel)
        {
            this.lobbyCreationViewModel = lobbyCreationViewModel;
        }

        public override void Execute(object parameter)
        {
            BoggleServiceContractsClient contractsClient =
                new BoggleServiceContractsClient(
                    new System.ServiceModel.InstanceContext(lobbyCreationViewModel));

            try
            {
                contractsClient.CreateLobby(lobbyCreationViewModel.LobbySettings);
            } catch (EntryPointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }
    }
}
