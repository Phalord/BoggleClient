using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class SearchLobbyViewModel : BaseViewModel
    {
        private NavigationService navigationService;
        private AccountDTO userAccount;

        public SearchLobbyViewModel(
            NavigationService navigationService,
            AccountDTO userAccount)
        {
            this.navigationService = navigationService;
            this.userAccount = userAccount;

            CancelCommand =
                new NavigateCommand(navigationService, userAccount);
        }

        public ICommand CancelCommand { get; }
    }
}
