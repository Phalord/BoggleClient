using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class SearchPublicLobbyCommand : BaseCommand
    {
        private readonly PlayOptionsViewModel playOptionsViewModel;

        public SearchPublicLobbyCommand(
            PlayOptionsViewModel playOptionsViewModel)
        {
            this.playOptionsViewModel = playOptionsViewModel;
        }

        public override void Execute(object parameter)
        {
            GameManagerContractClient contractsClient =
                new GameManagerContractClient(
                    new InstanceContext(playOptionsViewModel));

            try
            {
                contractsClient.SearchPublicLobbies();
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }
    }
}
