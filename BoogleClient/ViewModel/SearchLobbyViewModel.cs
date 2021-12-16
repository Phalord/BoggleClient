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
        private ObservableCollection<PublicLobbyPreviewDTO> publicLobbies;

        private PublicLobbyPreviewDTO selectedLobby;
        private string lobbyCode;

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
            RefreshPublicLobbiesCommand =
                new RefreshPublicLobbiesCommand(this);
        }

        public ObservableCollection<PublicLobbyPreviewDTO> PublicLobbies
        {
            get => publicLobbies;
            private set
            {
                publicLobbies = value;
                OnPropertyChanged(nameof(PublicLobbies));
            }
        }

        public PublicLobbyPreviewDTO SelectedLobby
        {
            get { return selectedLobby; }
            set { selectedLobby = value; }
        }

        public string LobbyCode
        {
            get { return lobbyCode; }
            set { lobbyCode = value; }
        }


        public ICommand CancelCommand { get; }

        public ICommand RefreshPublicLobbiesCommand { get; set; }

        public ICommand JoinLobbyCommand { get; set; }

        public ICommand JoinLobbyByCodeCommand { get; set; }

        private string GetLobbyCodeOfSelected()
        {
            return selectedLobby.LobbyCode;
        }

        public override void JoinLobby(Lobby lobby)
        {
            windowNavigationStore.CurrentViewModel = CreateLobbyViewModel(lobby);
        }

        public override void UpdateLobby(Lobby lobby)
        {
            windowNavigationStore.CurrentViewModel = CreateLobbyViewModel(lobby);
        }

        public override void RefreshPublicLobbies(
            PublicLobbyPreviewDTO[] publicLobbies)
        {
            PublicLobbies =
                new ObservableCollection<PublicLobbyPreviewDTO>(publicLobbies);
        }

        private BaseViewModel CreateLobbyViewModel(Lobby lobby)
        {
            return new LobbyViewModel(lobby, userAccount);
        }
    }
}
