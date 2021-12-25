using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class JoinLobbyByCodeCommand : BaseCommand
    {
        private readonly PlayOptionsViewModel playOptionsViewModel;
        private readonly SearchLobbyViewModel searchLobbyViewModel;
        private readonly AccountDTO userAccount;

        public JoinLobbyByCodeCommand(
            PlayOptionsViewModel playOptionsViewModel,
            SearchLobbyViewModel searchLobbyViewModel,
            AccountDTO userAccount)
        {
            this.playOptionsViewModel = playOptionsViewModel;
            this.searchLobbyViewModel = searchLobbyViewModel;
            this.userAccount = userAccount;

            searchLobbyViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            GameManagerContractClient contractClient =
                new GameManagerContractClient(
                    new InstanceContext(playOptionsViewModel));

            try
            {
                contractClient.AskToJoinLobby(
                    userAccount.UserName, searchLobbyViewModel.LobbyCode);
            }
            catch (EntryPointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return searchLobbyViewModel.LobbyCode.Length.Equals(5);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchLobbyViewModel.LobbyCode))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
