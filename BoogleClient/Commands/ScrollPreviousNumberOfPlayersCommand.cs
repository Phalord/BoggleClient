using BoogleClient.ViewModel;

namespace BoogleClient.Commands
{
    internal class ScrollPreviousNumberOfPlayersCommand : BaseCommand
    {
        private readonly LobbyCreationViewModel lobbyCreationViewModel;
        private int[] roomSizes;

        public ScrollPreviousNumberOfPlayersCommand(
            LobbyCreationViewModel lobbyCreationViewModel,
            int[] roomSizes)
        {
            this.lobbyCreationViewModel = lobbyCreationViewModel;
            this.roomSizes = roomSizes;
        }

        public override void Execute(object parameter)
        {
            int indexOfSelected = 0;
            foreach (int roomSize in roomSizes)
            {
                if (roomSize.Equals(lobbyCreationViewModel
                    .LobbySettings.NumberOfPlayers))
                {
                    break;
                }
                indexOfSelected++;
            }

            if (indexOfSelected.Equals(0))
            {
                lobbyCreationViewModel
                    .LobbySettings.NumberOfPlayers = roomSizes[roomSizes.Length - 1];
            }
            else
            {
                lobbyCreationViewModel.LobbySettings
                    .NumberOfPlayers = roomSizes[indexOfSelected - 1];
            }
        }
    }
}
