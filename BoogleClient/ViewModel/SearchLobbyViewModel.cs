using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class SearchLobbyViewModel : BaseViewModel
    {
        private readonly NavigationService navigationService;
        private readonly AccountDTO userAccount;

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
