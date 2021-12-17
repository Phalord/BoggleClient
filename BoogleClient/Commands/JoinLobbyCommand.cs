using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class JoinLobbyCommand : BaseCommand
    {
        private readonly PlayOptionsViewModel playOptionsViewModel;
        private readonly Func<string> getLobbyCodeOfSelected;
        private readonly AccountDTO userAccount;

        public JoinLobbyCommand(
            PlayOptionsViewModel playOptionsViewModel,
            Func<string> getLobbyCodeOfSelected, AccountDTO userAccount)
        {
            this.playOptionsViewModel = playOptionsViewModel;
            this.getLobbyCodeOfSelected = getLobbyCodeOfSelected;
            this.userAccount = userAccount;
        }

        public override void Execute(object parameter)
        {
            GameManagerContractClient contractClient =
                new GameManagerContractClient(
                    new InstanceContext(playOptionsViewModel));

            try
            {
                contractClient.AskToJoinLobby(userAccount.UserName, getLobbyCodeOfSelected());
            }
            catch (EntryPointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }
    }
}
