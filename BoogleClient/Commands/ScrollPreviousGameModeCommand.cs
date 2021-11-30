using BoogleClient.ViewModel;
using System.Linq;

namespace BoogleClient.Commands
{
    class ScrollPreviousGameModeCommand : BaseCommand
    {
        private readonly LobbyCreationViewModel lobbyCreationViewModel;
        private readonly string[] gameModes;

        public ScrollPreviousGameModeCommand(
            LobbyCreationViewModel lobbyCreationViewModel,
            string[] gameModes)
        {
            this.lobbyCreationViewModel = lobbyCreationViewModel;
            this.gameModes = gameModes;
        }

        public override void Execute(object parameter)
        {
            if (lobbyCreationViewModel
                .LobbySettings.GameMode.Equals(gameModes.Last()))
            {
                lobbyCreationViewModel
                    .LobbySettings.GameMode = gameModes[1];
            }
            else if (lobbyCreationViewModel
                .LobbySettings.GameMode.Equals(gameModes.First()))
            {
                lobbyCreationViewModel
                    .LobbySettings.GameMode = gameModes.Last();
            }
            else
            {
                lobbyCreationViewModel
                    .LobbySettings.GameMode = gameModes.First();
            }
        }
    }
}
