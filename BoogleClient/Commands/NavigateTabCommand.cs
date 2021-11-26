using BoogleClient.Services;

namespace BoogleClient.Commands
{
    internal class NavigateTabCommand : BaseCommand
    {
        private readonly TabNavigationService navigationService;

        public NavigateTabCommand(
            TabNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            navigationService.Navigate();
        }
    }
}
