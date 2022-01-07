using BoogleClient.BoggleServices;

namespace BoogleClient.ViewModel
{
    internal class ProfileAnalyticsViewModel : BaseViewModel
    {
        private readonly PlayerAnalyticsDTO playerAnalyticsDTO;

        public ProfileAnalyticsViewModel(PlayerAnalyticsDTO playerAnalyticsDTO)
        {
            this.playerAnalyticsDTO = playerAnalyticsDTO;
        }

        public string Nickname
        {
            get => playerAnalyticsDTO.Nickname;
            set
            {
                playerAnalyticsDTO.Nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }
        public int WordsFound
        {
            get => playerAnalyticsDTO.WordsFound;
            set
            {
                playerAnalyticsDTO.WordsFound = value;
                OnPropertyChanged(nameof(WordsFound));
            }
        }
        public int DroppedMatches
        {
            get => playerAnalyticsDTO.DroppedMatches;
            set
            {
                playerAnalyticsDTO.DroppedMatches = value;
                OnPropertyChanged(nameof(DroppedMatches));
            }
        }
        public int WonMatches
        {
            get => playerAnalyticsDTO.WonMatches;
            set
            {
                playerAnalyticsDTO.WonMatches = value;
                OnPropertyChanged(nameof(WonMatches));
            }
        }
        public int LostMatches
        {
            get => playerAnalyticsDTO.LostMatches;
            set
            {
                playerAnalyticsDTO.LostMatches = value;
                OnPropertyChanged(nameof(LostMatches));
            }
        }
        public int PlayedMatches
        {
            get => playerAnalyticsDTO.PlayedMatches;
            set
            {
                playerAnalyticsDTO.PlayedMatches = value;
                OnPropertyChanged(nameof(PlayedMatches));
            }
        }
        public int HighestScore
        {
            get => playerAnalyticsDTO.HighestScore;
            set
            {
                playerAnalyticsDTO.HighestScore = value;
                OnPropertyChanged(nameof(HighestScore));
            }
        }
        public int TotalScore
        {
            get => playerAnalyticsDTO.TotalScore;
            set
            {
                playerAnalyticsDTO.TotalScore = value;
                OnPropertyChanged(nameof(TotalScore));
            }
        }
    }
}