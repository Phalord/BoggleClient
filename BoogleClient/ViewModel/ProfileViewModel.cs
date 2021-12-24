using BoogleClient.BoggleServices;
using BoogleClient.Stores;
using System;

namespace BoogleClient.ViewModel
{
    internal class ProfileViewModel : BaseViewModel
    {
        private readonly NavigationStore profileNavigationStore;
        private readonly NavigationStore windowNavigationStore;
        private readonly AccountDTO userAccount;

        public ProfileViewModel(
            NavigationStore windowNavigationStore,
            AccountDTO userAccount)
        {
            this.windowNavigationStore = windowNavigationStore;
            this.userAccount = userAccount;

            profileNavigationStore = new NavigationStore()
            {
                CurrentViewModel = CreateProfileOverviewViewModel()
            };
        }

        private BaseViewModel CreateProfileOverviewViewModel()
        {
            return new ProfileOverviewViewModel();
        }
    }
}
