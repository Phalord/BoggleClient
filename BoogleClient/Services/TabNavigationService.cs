using BoogleClient.Stores;
using BoogleClient.ViewModel;
using System;

namespace BoogleClient.Services
{
    internal class TabNavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<BaseViewModel> createViewModel;

        public TabNavigationService(
            NavigationStore navigationStore,
            Func<BaseViewModel> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate()
        {
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
