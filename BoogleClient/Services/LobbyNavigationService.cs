using BoogleClient.BoggleServices;
using BoogleClient.Stores;
using BoogleClient.ViewModel;
using System;

namespace BoogleClient.Services
{
    internal class LobbyNavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<AccountDTO, Lobby, BaseViewModel> createViewModel;

        public LobbyNavigationService(
            NavigationStore navigationStore,
            Func<AccountDTO, Lobby, BaseViewModel> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate(AccountDTO userAccount, Lobby lobby)
        {
            navigationStore.CurrentViewModel =
                createViewModel(userAccount, lobby);
        }
    }
}
