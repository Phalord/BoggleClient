using BoogleClient.BoggleServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoogleClient.ViewModel
{
    internal class LobbyViewModel : BaseViewModel
    {
        private readonly Lobby lobby;
        private readonly AccountDTO userAccount;

        public LobbyViewModel(Lobby lobby, AccountDTO userAccount)
        {
            this.lobby = lobby;
            this.userAccount = userAccount;
        }

        public ObservableCollection<Player> PlayersInLobby =>
            new ObservableCollection<Player>(lobby.Players);

        //public ObservableCollection<InvitesDTO> InvitesSent { get; set; }

        public string GameMode { get; set; }
    }
}
