using BoogleClient.BoggleServices;
using BoogleClient.Services;

namespace BoogleClient.Commands
{
    internal class NavigateCommand : BaseCommand
    {
        private readonly NavigationService navigationService;
        private readonly AccountDTO userAccount;

        public NavigateCommand(NavigationService navigationService,
            AccountDTO userAccount)
        {
            this.navigationService = navigationService;
            this.userAccount = userAccount;
        }

        public override void Execute(object parameter)
        {
            navigationService.Navigate(userAccount);
        }
    }
}
