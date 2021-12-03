using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class SearchLobbyViewModel : BoggleServiceCallback
    {
        private readonly AccountDTO userAccount;
        private readonly NavigationStore windowNavigationStore;

        public SearchLobbyViewModel(
            NavigationService cancelNavegationService,
            AccountDTO userAccount,
            PublicLobbyPreviewDTO[] publicLobbies,
            NavigationStore windowNavigationStore)
        {
            this.userAccount = userAccount;
            this.windowNavigationStore = windowNavigationStore;
            PublicLobbies = 
                new ObservableCollection<PublicLobbyPreviewDTO>(publicLobbies);
            CancelCommand =
                new NavigateCommand(cancelNavegationService, userAccount);
            JoinLobbyCommand =
                new JoinLobbyCommand(this, GetLobbyCodeOfSelected, userAccount);
        }

        public ObservableCollection<PublicLobbyPreviewDTO> PublicLobbies { get; set; }

        private PublicLobbyPreviewDTO selectedLobby;

        public PublicLobbyPreviewDTO SelectedLobby
        {
            get { return selectedLobby; }
            set { selectedLobby = value; }
        }


        public ICommand CancelCommand { get; }

        public ICommand RefreshPublicLobbiesCommand { get; set; }

        public ICommand JoinLobbyCommand { get; set; }

        private string GetLobbyCodeOfSelected()
        {
            return selectedLobby.LobbyCode;
        }

        public override void JoinLobby(Lobby lobby)
        {
            windowNavigationStore.CurrentViewModel = CreateLobbyViewModel(lobby);
        }

        private BaseViewModel CreateLobbyViewModel(Lobby lobby)
        {
            return new LobbyViewModel(lobby, userAccount);
        }
    }
}
