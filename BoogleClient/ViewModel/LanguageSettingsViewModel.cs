using BoogleClient.BoggleServices;
using BoogleClient.Stores;

namespace BoogleClient.ViewModel
{
    internal class LanguageSettingsViewModel : BaseViewModel
    {
        private SettingsMenuViewModel settingsMenuViewModel;
        private AccountDTO userAccount;
        private NavigationStore menusNavigationStore;

        public LanguageSettingsViewModel(SettingsMenuViewModel settingsMenuViewModel, AccountDTO userAccount, NavigationStore menusNavigationStore)
        {
            this.settingsMenuViewModel = settingsMenuViewModel;
            this.userAccount = userAccount;
            this.menusNavigationStore = menusNavigationStore;
        }
    }
}