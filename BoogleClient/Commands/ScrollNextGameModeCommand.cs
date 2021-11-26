using BoogleClient.ViewModel;
using System.Linq;

namespace BoogleClient.Commands
{
    internal class ScrollNextGameModeCommand : BaseCommand
    {
        private readonly LobbyCreationViewModel lobbyCreationViewModel;
        private readonly string[] gameModes;

        public ScrollNextGameModeCommand(
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
                    .LobbySettings.GameMode = gameModes.First();
            }
            else if (lobbyCreationViewModel
                .LobbySettings.GameMode.Equals(gameModes.First()))
            {
                lobbyCreationViewModel
                    .LobbySettings.GameMode = gameModes[1];
            }
            else
            {
                lobbyCreationViewModel
                    .LobbySettings.GameMode = gameModes.Last();
            }
        }
    }
}
