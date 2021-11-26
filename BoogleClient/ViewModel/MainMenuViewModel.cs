using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal partial class MainMenuViewModel : BaseViewModel
    {
        private readonly NavigationService createLobbyNavigationService;
        private readonly NavigationService searchLobbyNavigationService;
        private readonly AccountDTO userAccount;
        private NavigationStore menusNavigationStore;

        public MainMenuViewModel(
            NavigationService createLobbyNavigationService,
            NavigationService searchLobbyNavigationService,
            AccountDTO userAccount)
        {
            this.userAccount = userAccount;
            this.createLobbyNavigationService = createLobbyNavigationService;
            this.searchLobbyNavigationService = searchLobbyNavigationService;
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
            return new SettingsMenuViewModel();
        }

        private SocialsMenuViewModel CreateSocialsMenuViewModel()
        {
            return new SocialsMenuViewModel();
        }

        private PlayOptionsViewModel CreatePlayOptionsViewModel()
        {
            return new PlayOptionsViewModel(
                createLobbyNavigationService,
                searchLobbyNavigationService,
                userAccount);
        }

        private LeaderboardViewModel CreateLeaderboardViewModel()
        {
            return new LeaderboardViewModel();
        }

        private ProfileViewModel CreateProfileViewModel()
        {
            return new ProfileViewModel();
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

    internal partial class SocialsMenuViewModel : BaseViewModel
    {

    }

    internal partial class LeaderboardViewModel : BaseViewModel
    {

    }

    internal partial class ProfileViewModel : BaseViewModel
    {

    }

    internal partial class SettingsMenuViewModel : BaseViewModel
    {

    }
}
