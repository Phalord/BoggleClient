using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class PlayOptionsViewModel : BoggleServiceCallback
    {
        private readonly NavigationStore windowNavigationStore;
        private readonly AccountDTO userAccount;

        #region Constants

        private const string Public = "Public";
        private const string Private = "Private";
        private const string Classic = "Classic";
        private const string Arcade = "Arcade";
        private const string Race = "Race";

        #endregion

        public PlayOptionsViewModel(
            NavigationStore windowNavigationStore,
            AccountDTO userAccount)
        {

            CreateLobbyCommand = new NavigateCommand(
                new NavigationService(
                    windowNavigationStore, CreateLobbyCreationViewModel), userAccount);
            SearchLobbyCommand = new SearchPublicLobbyCommand(this);
            this.windowNavigationStore = windowNavigationStore;
            this.userAccount = userAccount;
        }

        public ICommand CreateLobbyCommand { get; }

        public ICommand SearchLobbyCommand { get; }

        private BaseViewModel CreateLobbyCreationViewModel(AccountDTO userAccount)
        {
            int[] roomSizes = { 2, 4, 8, 16 };
            string[] gameModes = { Classic, Arcade, Race };
            string[] privacies = { Public, Private };

            return new LobbyCreationViewModel(
                new NavigationService(windowNavigationStore, CreateMainMenuViewModel),
                userAccount, roomSizes, gameModes, privacies);
        }

        private BaseViewModel CreateMainMenuViewModel(AccountDTO userAccount)
        {
            return new MainMenuViewModel(windowNavigationStore, userAccount);
        }

        public override void DisplayPublicLobbies(PublicLobbyPreviewDTO[] publicLobbies)
        {
            windowNavigationStore.CurrentViewModel = new SearchLobbyViewModel(
                new NavigationService(windowNavigationStore, CreateMainMenuViewModel),
                userAccount, publicLobbies);
        }
    }
}
