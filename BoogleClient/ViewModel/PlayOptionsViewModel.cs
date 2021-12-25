using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System.Windows;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class PlayOptionsViewModel : BaseViewModel, IGameManagerContractCallback
    {
        private readonly NavigationStore windowNavigationStore;
        private readonly AccountDTO userAccount;
        private readonly LogInViewModel logInViewModel;

        #region Constants

        private const string Public = "Public";
        private const string Private = "Private";
        private const string Classic = "Classic";
        private const string Arcade = "Arcade";
        private const string Race = "Race";

        #endregion

        public PlayOptionsViewModel(
            NavigationStore windowNavigationStore,
            AccountDTO userAccount,
            LogInViewModel logInViewModel)
        {

            CreateLobbyCommand = new NavigateCommand(
                new NavigationService(
                    windowNavigationStore, CreateLobbyCreationViewModel));
            SearchLobbyCommand = new SearchPublicLobbyCommand(this);
            this.windowNavigationStore = windowNavigationStore;
            this.userAccount = userAccount;
            this.logInViewModel = logInViewModel;
        }

        public ICommand CreateLobbyCommand { get; }

        public ICommand SearchLobbyCommand { get; }

        private BaseViewModel CreateLobbyCreationViewModel()
        {
            int[] roomSizes = { 2, 4, 8, 16 };
            string[] gameModes = { Classic, Arcade, Race };
            string[] privacies = { Public, Private };

            return new LobbyCreationViewModel(
                new NavigationService(windowNavigationStore, CreateMainMenuViewModel),
                userAccount, roomSizes, gameModes, privacies, this);
        }

        private BaseViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(windowNavigationStore, userAccount, logInViewModel);
        }

        public void DisplayPublicLobbies(PublicLobbyPreviewDTO[] publicLobbies)
        {
            windowNavigationStore.CurrentViewModel = new SearchLobbyViewModel(
                new NavigationService(windowNavigationStore, CreateMainMenuViewModel),
                userAccount, publicLobbies, this);
        }

        public void GrantAccessToJoinLobby(Lobby lobby)
        {
            if (lobby is null)
            {
                MessageBox.Show("Lobby no encontrado, intente nuevamente.",
                    "Lobby inexistente");
            }
            else
            {
                windowNavigationStore.CurrentViewModel =
                    new LobbyViewModel(lobby, userAccount, windowNavigationStore, logInViewModel);
            }
        }

        public void RefreshPublicLobbies(PublicLobbyPreviewDTO[] publicLobbies)
        {
            DisplayPublicLobbies(publicLobbies);
        }
    }
}
