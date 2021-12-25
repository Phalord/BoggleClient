using BoogleClient.BoggleServices;
using BoogleClient.Stores;

namespace BoogleClient.ViewModel
{
    internal class InfoViewModel : BaseViewModel
    {
        private SettingsMenuViewModel settingsMenuViewModel;
        private AccountDTO userAccount;
        private NavigationStore menusNavigationStore;

        public InfoViewModel(SettingsMenuViewModel settingsMenuViewModel, AccountDTO userAccount, NavigationStore menusNavigationStore)
        {
            this.settingsMenuViewModel = settingsMenuViewModel;
            this.userAccount = userAccount;
            this.menusNavigationStore = menusNavigationStore;
        }
    }
}