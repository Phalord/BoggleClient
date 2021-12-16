using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class LobbyViewModel : BaseViewModel
    {
        private string messageText;
        private readonly Lobby lobby;
        private readonly AccountDTO userAccount;

        public LobbyViewModel(Lobby lobby, AccountDTO userAccount)
        {
            this.lobby = lobby;
            this.userAccount = userAccount;
            SendMessageCommand =
                new SendMessageCommand(this, userAccount.UserName, lobby);
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

        public ObservableCollection<Player> PlayersInLobby =>
            CreateObservablePlayers();

        public ObservableCollection<Message> MessageHistory =>
            CreateObservableMessages();

        private ObservableCollection<Message> CreateObservableMessages()
        {
            ObservableCollection<Message> messageHistory =
                new ObservableCollection<Message>(lobby.MessageHistory);

            return messageHistory;
        }

        private ObservableCollection<Player> CreateObservablePlayers()
        {
            ObservableCollection<Player> players = 
                new ObservableCollection<Player>(lobby.Players);
            players.Remove(players.FirstOrDefault(
                player => player.UserName.Equals(userAccount.UserName)));
            return players;
        }

        //public ObservableCollection<InvitesDTO> InvitesSent { get; set; }

        public ICommand SendMessageCommand { get; private set; }
        public ICommand ExitLobbyCommand { get; private set; }
        public ICommand InvitePlayerCommand { get; private set; }
        public ICommand ChangeMatchSettingsCommand { get; private set; }

        public string GameMode { get; set; }
    }
}
