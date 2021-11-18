using BoogleClient.BoggleServices;
using BoogleClient.Services;
using BoogleClient.Stores;

namespace BoogleClient.ViewModel
{
    internal partial class MainMenuViewModel : BaseViewModel
    {
        private readonly NavigationService windowNavigationService;
        private readonly NavigationStore menusNavigationStore;

        public MainMenuViewModel(NavigationService windowNavigationService)
        {
            menusNavigationStore = new NavigationStore();
            menusNavigationStore.CurrentViewModel = new PlayOptionsViewModel();

            this.windowNavigationService = windowNavigationService;
        }

        public BaseViewModel CurrentMenuSelected =>
            menusNavigationStore.CurrentViewModel;

    }

    internal class PlayOptionsViewModel : BaseViewModel
    {

    }

    internal partial class SocialsMenuViewModel : BaseViewModel
    {

    }
}
