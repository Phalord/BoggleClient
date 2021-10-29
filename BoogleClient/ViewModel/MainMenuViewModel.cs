namespace BoogleClient.ViewModel
{
    internal partial class MainMenuViewModel : BaseViewModel
    {
        public MainMenuViewModel()
        {
            //CurrentMenuSelected = new PlayOptionsViewModel();
            CurrentMenuSelected = new SocialsMenuViewModel();
        }

        public BaseViewModel CurrentMenuSelected { get; set; }

    }

    internal class PlayOptionsViewModel : BaseViewModel
    {

    }

    internal partial class SocialsMenuViewModel : BaseViewModel
    {

    }
}
