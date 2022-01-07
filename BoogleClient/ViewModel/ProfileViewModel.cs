using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Stores;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class ProfileViewModel : BaseViewModel, IProfileManagerContractCallback
    {
        private readonly NavigationStore profileNavigationStore;

        public ProfileViewModel(AccountDTO userAccount)
        {
            profileNavigationStore = new NavigationStore();
            profileNavigationStore
                .CurrentViewModelChanged += OnCurrentViewModelChanged;

            DisplayAnalyticsViewCommand = new RetrievePlayerAnalytics(this, userAccount);
            DisplayProfileOverviewCommand = new RetrieveProfileOverview(this, userAccount);

            DisplayProfileOverviewCommand.Execute(null);
        }

        public BaseViewModel CurrentViewSelected => profileNavigationStore.CurrentViewModel;
        public ICommand DisplayProfileOverviewCommand { get; set; }
        public ICommand DisplayAnalyticsViewCommand { get; set; }

        private BaseViewModel CreateProfileOverviewViewModel(
            PlayerOverviewDTO playerOverviewDTO)
        {
            return new ProfileOverviewViewModel(playerOverviewDTO); ;
        }

        private BaseViewModel CreateProfileAnalyticsViewModel(
            PlayerAnalyticsDTO playerAnalyticsDTO)
        {
            return new ProfileAnalyticsViewModel(playerAnalyticsDTO);
        }

        public void DisplayPlayerOverview(PlayerOverviewDTO playerOverviewDTO)
        {
            profileNavigationStore.CurrentViewModel =
                CreateProfileOverviewViewModel(playerOverviewDTO);
                
        }

        public void DisplayPlayerAnalytics(PlayerAnalyticsDTO playerAnalyticsDTO)
        {
            profileNavigationStore.CurrentViewModel =
                CreateProfileAnalyticsViewModel(playerAnalyticsDTO);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewSelected));
        }
    }
}
