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

        public App()
        {
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = 
                new LogInViewModel(new Services.NavigationService(navigationStore, CreateMainMenuViewModel));

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private BaseViewModel CreateMainMenuViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
