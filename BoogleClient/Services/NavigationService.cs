using BoogleClient.BoggleServices;
using BoogleClient.Stores;
using BoogleClient.ViewModel;
using System;

namespace BoogleClient.Services
{
    internal class NavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<AccountDTO, BaseViewModel> createViewModel;

        public NavigationService(NavigationStore navigationStore,
            Func<AccountDTO, BaseViewModel> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate(AccountDTO userAccount)
        {
            navigationStore.CurrentViewModel = createViewModel(userAccount);
        }
    }
}
