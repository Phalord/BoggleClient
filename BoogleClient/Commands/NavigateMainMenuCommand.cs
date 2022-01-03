using BoogleClient.Services;
using BoogleClient.ViewModel;
using System.ComponentModel;

namespace BoogleClient.Commands
{
    internal class NavigateMainMenuCommand : BaseCommand
    {
        private readonly MainMenuViewModel mainMenuViewModel;
        private readonly NavigationService menuNavigationService;
        private readonly BaseViewModel newViewModel;

        public NavigateMainMenuCommand(
            MainMenuViewModel mainMenuViewModel,
            NavigationService menuNavigationService,
            BaseViewModel newViewModel)
        {
            this.mainMenuViewModel = mainMenuViewModel;
            this.menuNavigationService = menuNavigationService;
            this.newViewModel = newViewModel;

            mainMenuViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            bool canExecute = false;

            if (!mainMenuViewModel.CurrentMenuSelected.GetType().Equals(newViewModel.GetType()))
            {
                canExecute = true;
            }

            return canExecute;
        }

        public override void Execute(object parameter)
        {
            menuNavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainMenuViewModel.CurrentMenuSelected))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
