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
        private readonly Lobby lobby;
        private readonly AccountDTO userAccount;
        private readonly NavigationStore windowNavigationStore;
        private readonly ObservableCollection<Message> messageHistory;
        private readonly ObservableCollection<Player> players;

        public LobbyViewModel(Lobby lobby, AccountDTO userAccount,
            NavigationStore windowNavigationStore)
        {
            this.lobby = lobby;
            this.userAccount = userAccount;
            this.windowNavigationStore = windowNavigationStore;
            messageText = string.Empty;
            messageHistory = new ObservableCollection<Message>();
            players = new ObservableCollection<Player>();
            gameMode = lobby.GameMatch.GameMode;

            JoinLobby();

            SendMessageCommand =
                new SendMessageCommand(this, userAccount.UserName, lobby);
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

        private BaseViewModel CreateMainMenuView(AccountDTO arg)
        {
            return new MainMenuViewModel(windowNavigationStore, userAccount);
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

        public ObservableCollection<Player> PlayersInLobby => players;

        public ObservableCollection<Message> MessageHistory => messageHistory;

        public void UpdateLobby(Lobby lobby)
        {
            this.lobby.Code = lobby.Code;
            this.lobby.GameMatch = lobby.GameMatch;
            this.lobby.MessageHistory = lobby.MessageHistory;
            this.lobby.Players = lobby.Players;
            this.lobby.Privacy = lobby.Privacy;
            this.lobby.Size = lobby.Size;
            this.lobby.GameMatch.GameMode = lobby.GameMatch.GameMode;
            UpdateObservableMessages();
            UpdateObservablePlayers();
        }

        //public ObservableCollection<InvitesDTO> InvitesSent { get; set; }

        public ICommand SendMessageCommand { get; private set; }
        public ICommand ExitLobbyCommand { get; private set; }
        public ICommand InvitePlayerCommand { get; private set; }
        public ICommand ChangeMatchSettingsCommand { get; private set; }

        private void UpdateObservableMessages()
        {
            messageHistory.Clear();

            foreach (Message message in lobby.MessageHistory)
            {
                messageHistory.Add(message);
            }
        }

        private void UpdateObservablePlayers()
        {
            players.Clear();

            foreach (Player player in lobby.Players)
            {
                players.Add(player);
            }

            _ = players.Remove(players.FirstOrDefault(
                player => player.UserName.Equals(userAccount.UserName)));
        }
    }
}
