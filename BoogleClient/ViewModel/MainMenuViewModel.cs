namespace BoogleClient.ViewModel
{
    internal partial class MainMenuViewModel : BaseViewModel
    {
        public MainMenuViewModel()
        {
            CurrentMenuSelected = new PlayOptionsViewModel();
        }

        public BaseViewModel CurrentMenuSelected { get; set; }

    }
}
