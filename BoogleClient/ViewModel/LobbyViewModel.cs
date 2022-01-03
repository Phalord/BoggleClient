using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class LobbyViewModel : BaseViewModel, ILobbyManagerContractCallback
    {
        private string messageText;
        private string gameMode;
        private Lobby lobby;
        private readonly AccountDTO userAccount;
        private readonly NavigationStore windowNavigationStore;
        private readonly LogInViewModel logInViewModel;
        private readonly ObservableCollection<Message> messageHistory;
        private readonly ObservableCollection<Player> players;

        public LobbyViewModel(Lobby lobby, AccountDTO userAccount,
            NavigationStore windowNavigationStore, LogInViewModel logInViewModel)
        {
            this.lobby = lobby;
            this.userAccount = userAccount;
            this.windowNavigationStore = windowNavigationStore;
            this.logInViewModel = logInViewModel;
            messageText = string.Empty;
            messageHistory = new ObservableCollection<Message>();
            players = new ObservableCollection<Player>();
            gameMode = lobby.GameMatch.GameMode;

            JoinLobby();

            SendMessageCommand =
                new SendMessageCommand(this, userAccount.UserName);
            ExitLobbyCommand =
                new ExitLobbyCommand(lobby.Code, userAccount, this,
                    new NavigationService(
                        windowNavigationStore, CreateMainMenuView));
        }

        private void JoinLobby()
        {
            LobbyManagerContractClient contractsClient =
                new LobbyManagerContractClient(
                    new InstanceContext(this));

            try
            {
                contractsClient.JoinLobby(userAccount.UserName, lobby.Code);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
                ExitLobbyCommand.Execute(null);
            }
        }

        private BaseViewModel CreateMainMenuView()
        {
            return new MainMenuViewModel(
                windowNavigationStore, userAccount, logInViewModel);
        }

        public string MessageText
        {
            get => messageText;
            set
            {
                messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }
        public string GameMode
        {
            get => gameMode;
            set
            {
                gameMode = value;
                OnPropertyChanged(nameof(GameMode));
            }
        }
        public string LobbyCode
        {
            get => lobby.Code;
            set
            {
                lobby.Code = value;
                OnPropertyChanged(nameof(LobbyCode));
            }
        }

        public ObservableCollection<Player> PlayersInLobby
        {
            get => players;
            set
            {
                players.Clear();

                foreach (Player player in value)
                {
                    players.Add(player);
                }
                OnPropertyChanged(nameof(PlayersInLobby));
            }
        }

        public ObservableCollection<Message> MessageHistory
        {
            get => messageHistory;
            set
            {
                messageHistory.Clear();
                foreach (Message message in value)
                {
                    messageHistory.Add(message);
                }

                OnPropertyChanged(nameof(MessageHistory));
            }
        }

        public void UpdateLobby(Lobby lobby)
        {
            this.lobby = lobby;
            MessageHistory = new ObservableCollection<Message>(lobby.MessageHistory);
            PlayersInLobby = new ObservableCollection<Player>(lobby.Players);
        }

        //public ObservableCollection<InvitesDTO> InvitesSent { get; set; }

        public ICommand SendMessageCommand { get; private set; }
        public ICommand ExitLobbyCommand { get; private set; }
        public ICommand InvitePlayerCommand { get; private set; }
        public ICommand ChangeMatchSettingsCommand { get; private set; }
    }
}
