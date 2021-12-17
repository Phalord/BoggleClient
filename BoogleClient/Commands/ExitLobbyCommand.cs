using BoogleClient.BoggleServices;
using BoogleClient.Services;
using BoogleClient.ViewModel;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class ExitLobbyCommand : BaseCommand
    {
        private readonly string lobbyCode;
        private readonly AccountDTO userAccount;
        private readonly LobbyViewModel lobbyViewModel;
        private readonly NavigationService cancelNavigationService;

        public ExitLobbyCommand(
            string lobbyCode,
            AccountDTO userAccount,
            LobbyViewModel lobbyViewModel,
            NavigationService cancelNavigationService)
        {
            this.lobbyCode = lobbyCode;
            this.userAccount = userAccount;
            this.lobbyViewModel = lobbyViewModel;
            this.cancelNavigationService = cancelNavigationService;
        }

        public override void Execute(object parameter)
        {
            LobbyManagerContractClient contractsClient =
                new LobbyManagerContractClient(
                    new InstanceContext(lobbyViewModel));

            try
            {
                contractsClient.ExitLobby(userAccount.UserName, lobbyCode);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
            finally
            {
                cancelNavigationService.Navigate(userAccount);
            }
        }
    }
}
