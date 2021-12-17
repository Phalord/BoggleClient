using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class RefreshPublicLobbiesCommand : BaseCommand
    {
        private readonly PlayOptionsViewModel playOptionsViewModel;

        public RefreshPublicLobbiesCommand(PlayOptionsViewModel playOptionsViewModel)
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
                contractsClient.UpdatePublicLobbies();
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }
    }
}
