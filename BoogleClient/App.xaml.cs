using BoogleClient.BoggleServices;
using BoogleClient.Services;
using BoogleClient.Stores;
using BoogleClient.ViewModel;
using System;
using System.Windows;

namespace BoogleClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore;

        #region Constants

        private const string Public = "Public";
        private const string Private = "Private";
        private const string Classic = "Classic";
        private const string Arcade = "Arcade";
        private const string Race = "Race";

        #endregion

        public App()
        {
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel =
                new LogInViewModel(new NavigationService(navigationStore, CreateMainMenuViewModel));

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private BaseViewModel CreateMainMenuViewModel(AccountDTO userAccount)
        {
            return new MainMenuViewModel(
                new NavigationService(navigationStore, CreateLobbyCreationViewModel),
                new NavigationService(navigationStore, SearchLobbyViewModel),
                userAccount);
        }

        private BaseViewModel SearchLobbyViewModel(AccountDTO userAccount)
        {
            return new SearchLobbyViewModel(
                new NavigationService(navigationStore, CreateMainMenuViewModel),
                userAccount);
        }

        private BaseViewModel CreateLobbyCreationViewModel(AccountDTO userAccount)
        {
            int[] roomSizes = { 2, 4, 8, 16 };
            string[] gameModes = { Classic, Arcade, Race };
            string[] privacies = { Public, Private };

            return
                new LobbyCreationViewModel(
                    new NavigationService(navigationStore, CreateMainMenuViewModel),
                    userAccount, roomSizes, gameModes, privacies);
        }
    }
}
