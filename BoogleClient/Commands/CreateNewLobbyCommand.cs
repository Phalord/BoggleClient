using BoogleClient.ViewModel;
using BoogleClient.BoggleServices;
using System;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class CreateNewLobbyCommand : BaseCommand
    {
        private readonly LobbyCreationViewModel lobbyCreationViewModel;
        private readonly PlayOptionsViewModel playOptionsViewModel;

        public CreateNewLobbyCommand(
            LobbyCreationViewModel lobbyCreationViewModel,
            PlayOptionsViewModel playOptionsViewModel)
        {
            this.lobbyCreationViewModel = lobbyCreationViewModel;
            this.playOptionsViewModel = playOptionsViewModel;
        }

        public override void Execute(object parameter)
        {
            GameManagerContractClient contractsClient =
                new GameManagerContractClient(
                    new System.ServiceModel.InstanceContext(playOptionsViewModel));

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
