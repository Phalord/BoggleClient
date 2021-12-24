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
        private LogInViewModel logInViewModel;

        public App()
        {
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            logInViewModel =
                new LogInViewModel(
                    navigationStore,
                    new NavigationService(navigationStore, CreateMainMenuViewModel));

            navigationStore.CurrentViewModel = logInViewModel;

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private BaseViewModel CreateMainMenuViewModel(AccountDTO userAccount)
        {
            return new MainMenuViewModel(navigationStore, userAccount, logInViewModel);
        }
    }
}
