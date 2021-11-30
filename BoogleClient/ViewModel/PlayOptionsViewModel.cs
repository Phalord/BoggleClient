using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class PlayOptionsViewModel : BaseViewModel
    {

        public PlayOptionsViewModel(
            NavigationService createLobbyNavigationService,
            NavigationService searchLobbyNavigationService,
            AccountDTO userAccount)
        {

            CreateLobbyCommand = new NavigateCommand(
                createLobbyNavigationService, userAccount);
            SearchLobbyCommand = new NavigateCommand(
                searchLobbyNavigationService, userAccount);
        }


        public ICommand CreateLobbyCommand { get; }

        public ICommand SearchLobbyCommand { get; }
    }
}
