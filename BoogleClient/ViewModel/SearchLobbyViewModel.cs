using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class SearchLobbyViewModel : BaseViewModel
    {
        private ObservableCollection<PublicLobbyPreviewDTO> publicLobbies;

        private PublicLobbyPreviewDTO selectedLobby;
        private string lobbyCode;

        public SearchLobbyViewModel(
            NavigationService cancelNavegationService,
            AccountDTO userAccount,
            PublicLobbyPreviewDTO[] publicLobbies,
            PlayOptionsViewModel playOptionsViewModel)
        {
            PublicLobbies =
                new ObservableCollection<PublicLobbyPreviewDTO>(publicLobbies);
            CancelCommand =
                new NavigateCommand(cancelNavegationService, userAccount);
            JoinLobbyCommand =
                new JoinLobbyCommand(playOptionsViewModel, GetLobbyCodeOfSelected, userAccount);
            RefreshPublicLobbiesCommand =
                new RefreshPublicLobbiesCommand(playOptionsViewModel);
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
            get => selectedLobby;
            set
            {
                selectedLobby = value;
                OnPropertyChanged(nameof(PublicLobbies));
            }
        }

        public string LobbyCode
        {
            get => lobbyCode;
            set
            {
                lobbyCode = value;
                OnPropertyChanged(nameof(PublicLobbies));
            }
        }


        public ICommand CancelCommand { get; }

        public ICommand RefreshPublicLobbiesCommand { get; set; }

        public ICommand JoinLobbyCommand { get; set; }

        public ICommand JoinLobbyByCodeCommand { get; set; }

        private string GetLobbyCodeOfSelected()
        {
            return selectedLobby.LobbyCode;
        }
    }
}
