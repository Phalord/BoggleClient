using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System.Globalization;
using System.Threading;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class LobbyCreationViewModel : BaseViewModel
    {
        private LobbySettingsDTO lobbySettings;

        public LobbyCreationViewModel(
            NavigationService cancelNavigationService,
            AccountDTO userAccount, int[] roomSizes,
            string[] gameModes, string[] privacies,
            PlayOptionsViewModel playOptionsViewModel)
        {
            LobbySettings = new LobbySettingsDTO
            {
                GameMode = gameModes[0],
                NumberOfPlayers = roomSizes[0],
                LobbyPrivacy = privacies[1],
                Language = GetCurrentLanguage(),
                CreatorUserName = userAccount.UserName
            };

            ScrollPreviousGameMode =
                new ScrollPreviousGameModeCommand(this, gameModes);
            ScrollNextGameMode =
                new ScrollNextGameModeCommand(this, gameModes);
            ScrollPreviousNumberOfPlayers =
                new ScrollPreviousNumberOfPlayersCommand(this, roomSizes);
            ScrollNextNumberOfPlayers =
                new ScrollNextNumberOfPlayersCommand(this, roomSizes);
            ChangeLobbyPrivacy =
                new ChangeLobbyPrivacyCommand(this, privacies);
            CancelCommand =
                new NavigateCommand(cancelNavigationService);
            CreateLobbyCommand =
                new CreateNewLobbyCommand(this, playOptionsViewModel);
        }

        private string GetCurrentLanguage()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            string currentLanguage = currentCulture.ToString();
            return currentLanguage;
        }

        public LobbySettingsDTO LobbySettings
        {
            get => lobbySettings;
            set
            {
                lobbySettings = value;
                OnPropertyChanged(nameof(LobbySettings));
            }
        }

        public ICommand CancelCommand { get; }

        public ICommand CreateLobbyCommand { get; }

        public ICommand ChangeLobbyPrivacy { get; }

        public ICommand ScrollPreviousGameMode { get; }

        public ICommand ScrollNextGameMode { get; }

        public ICommand ScrollPreviousNumberOfPlayers { get; }

        public ICommand ScrollNextNumberOfPlayers { get; }
    }
}
