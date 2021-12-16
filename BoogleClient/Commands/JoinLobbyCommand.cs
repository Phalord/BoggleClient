using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class JoinLobbyCommand : BaseCommand
    {
        private readonly SearchLobbyViewModel searchLobbyViewModel;
        private readonly Func<string> getLobbyCodeOfSelected;
        private readonly AccountDTO userAccount;

        public JoinLobbyCommand(
            SearchLobbyViewModel searchLobbyViewModel,
            Func<string> getLobbyCodeOfSelected, AccountDTO userAccount)
        {
            this.searchLobbyViewModel = searchLobbyViewModel;
            this.getLobbyCodeOfSelected = getLobbyCodeOfSelected;
            this.userAccount = userAccount;
        }

        public override void Execute(object parameter)
        {
            BoggleServiceContractsClient contractsClient =
                new BoggleServiceContractsClient(
                    new InstanceContext(searchLobbyViewModel));

            try
            {
                contractsClient.JoinLobbyByCode(userAccount.UserName, getLobbyCodeOfSelected());
            }
            catch (EntryPointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }
    }
}
