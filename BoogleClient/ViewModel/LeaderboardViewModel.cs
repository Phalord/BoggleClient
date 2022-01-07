using BoogleClient.BoggleServices;

namespace BoogleClient.ViewModel
{
    internal class LeaderboardViewModel : BaseViewModel, ILeaderboardManagerContractCallback
    {
        private readonly AccountDTO userAccount;

        public LeaderboardViewModel(AccountDTO userAccount)
        {
            this.userAccount = userAccount;
        }

        public void DisplayTopPlayers(TopPlayerDTO[] topPlayersDTOs)
        {
            throw new System.NotImplementedException();
        }
    }
}
