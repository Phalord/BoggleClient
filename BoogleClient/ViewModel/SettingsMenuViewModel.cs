using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class SettingsMenuViewModel : BaseViewModel
    {
        private readonly AccountDTO userAccount;
        private readonly NavigationStore menusNavigationStore;

        public SettingsMenuViewModel(
            AccountDTO userAccount,
            LogInViewModel logInViewModel,
            NavigationStore menusNavigationStore)
        {
            LogOutCommand = new LogOutCommand(logInViewModel, userAccount);
            ShowLanguageSettingsCommand = new NavigateCommand(new NavigationService(
                menusNavigationStore, CreateLanguageSettingsViewModel));
            ShowInfoCommand = new NavigateCommand(new NavigationService(
                menusNavigationStore, CreateInfoViewModel));
            this.userAccount = userAccount;
            this.menusNavigationStore = menusNavigationStore;
        }

        private BaseViewModel CreateInfoViewModel()
        {
            return new InfoViewModel(
                this, userAccount, menusNavigationStore);
        }

        private BaseViewModel CreateLanguageSettingsViewModel()
        {
            return new LanguageSettingsViewModel(
                this, userAccount, menusNavigationStore);
        }

        public ICommand ShowLanguageSettingsCommand { get; set; }
        public ICommand ShowInfoCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
    }
}
