using BoogleClient.BoggleServices;

namespace BoogleClient.ViewModel
{
    internal class ProfileOverviewViewModel : BaseViewModel
    {
        private readonly PlayerOverviewDTO playerOverviewDTO;

        public ProfileOverviewViewModel(PlayerOverviewDTO playerOverviewDTO)
        {
            this.playerOverviewDTO = playerOverviewDTO;
        }

        public string Nickname
        {
            get => playerOverviewDTO.Nickname;
            set
            {
                playerOverviewDTO.Nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }
        public string UserName
        {
            get => playerOverviewDTO.UserName;
            set
            {
                playerOverviewDTO.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public int Victories
        {
            get => playerOverviewDTO.Victories;
            set
            {
                playerOverviewDTO.Victories = value;
                OnPropertyChanged(nameof(Victories));
            }
        }
        public int GamesPlayed
        {
            get => playerOverviewDTO.GamesPlayed;
            set
            {
                playerOverviewDTO.GamesPlayed = value;
                OnPropertyChanged(nameof(GamesPlayed));
            }
        }
        public int HighestScore
        {
            get => playerOverviewDTO.HighestScore;
            set
            {
                playerOverviewDTO.HighestScore = value;
                OnPropertyChanged(nameof(HighestScore));
            }
        }
        public int TotalScore
        {
            get => playerOverviewDTO.TotalScore;
            set
            {
                playerOverviewDTO.TotalScore = value;
                OnPropertyChanged(nameof(TotalScore));
            }
        }
    }
}