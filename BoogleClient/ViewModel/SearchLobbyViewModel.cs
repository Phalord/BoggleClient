using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class SearchLobbyViewModel : BaseViewModel
    {
        private readonly AccountDTO userAccount;

        public SearchLobbyViewModel(
            NavigationService cancelNavegationService,
            AccountDTO userAccount, PublicLobbyPreviewDTO[] publicLobbies)
        {
            this.userAccount = userAccount;
            PublicLobbies = new ObservableCollection<PublicLobbyPreviewDTO>(publicLobbies);
            CancelCommand =
                new NavigateCommand(cancelNavegationService, userAccount);
        }

        public ObservableCollection<PublicLobbyPreviewDTO> PublicLobbies { get; set; }

        public ICommand CancelCommand { get; }

        public ICommand RefreshPublicLobbies { get; set; }
    }
}
