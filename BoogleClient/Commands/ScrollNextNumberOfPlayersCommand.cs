using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoogleClient.Commands
{
    internal class ScrollNextNumberOfPlayersCommand : BaseCommand
    {
        private readonly LobbyCreationViewModel lobbyCreationViewModel;
        private int[] roomSizes;

        public ScrollNextNumberOfPlayersCommand(
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

            if (indexOfSelected.Equals(roomSizes.Length - 1))
            {
                lobbyCreationViewModel
                    .LobbySettings.NumberOfPlayers = roomSizes[0];
            }
            else
            {
                lobbyCreationViewModel.LobbySettings
                    .NumberOfPlayers = roomSizes[indexOfSelected + 1];
            }
        }
    }
}
