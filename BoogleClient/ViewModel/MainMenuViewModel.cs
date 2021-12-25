using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class MainMenuViewModel : BaseViewModel
    {
        private readonly NavigationStore windowNavigationStore;
        private readonly AccountDTO userAccount;
        private readonly LogInViewModel logInViewModel;
        private readonly NavigationStore menusNavigationStore;


        public MainMenuViewModel(
            NavigationStore windowNavigationStore,
            AccountDTO userAccount,
            LogInViewModel logInViewModel)
        {
            this.userAccount = userAccount;
            this.logInViewModel = logInViewModel;
            this.windowNavigationStore = windowNavigationStore;
            menusNavigationStore = new NavigationStore()
            {
                CurrentViewModel = CreatePlayOptionsViewModel()
            };
            menusNavigationStore
                .CurrentViewModelChanged += OnCurrentViewModelChanged;

            NavigateProfileCommand =
                new NavigateTabCommand(CreateTabNavigationService(
                    CreateProfileViewModel));
            NavigateLeaderboardCommand =
                new NavigateTabCommand(CreateTabNavigationService(
                    CreateLeaderboardViewModel));
            NavigatePlayCommand =
                new NavigateTabCommand(CreateTabNavigationService(
                    CreatePlayOptionsViewModel));
            NavigateSocialsCommand =
                new NavigateTabCommand(CreateTabNavigationService(
                    CreateSocialsMenuViewModel));
            NavigateSettingsCommand =
                new NavigateTabCommand(CreateTabNavigationService(
                    CreateSettingsMenuViewModel));
        }

        public BaseViewModel CurrentMenuSelected =>
            menusNavigationStore.CurrentViewModel;

        public ICommand NavigateProfileCommand { get; }
        public ICommand NavigateLeaderboardCommand { get; }
        public ICommand NavigatePlayCommand { get; }
        public ICommand NavigateSocialsCommand { get; }
        public ICommand NavigateSettingsCommand { get; }

        private SettingsMenuViewModel CreateSettingsMenuViewModel()
        {
            return new SettingsMenuViewModel(
                userAccount, logInViewModel, menusNavigationStore);
        }

        private SocialsMenuViewModel CreateSocialsMenuViewModel()
        {
            return new SocialsMenuViewModel();
        }

        private PlayOptionsViewModel CreatePlayOptionsViewModel()
        {
            return new PlayOptionsViewModel(windowNavigationStore, userAccount, logInViewModel);
        }

        private LeaderboardViewModel CreateLeaderboardViewModel()
        {
            return new LeaderboardViewModel();
        }

        private ProfileViewModel CreateProfileViewModel()
        {
            return new ProfileViewModel(windowNavigationStore, userAccount);
        }

        private TabNavigationService CreateTabNavigationService(Func<BaseViewModel> createViewModel)
        {
            return new TabNavigationService(menusNavigationStore, createViewModel);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentMenuSelected));
        }

    }
}
