using BoogleClient.Commands;
using BoogleClient.Services;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class LogInFormViewModel : BaseViewModel
    {
        private string userName;

        public LogInFormViewModel(
            LogInViewModel logInViewModel,
            NavigationService formsNavigationService)
        {
            LogInCommand = new LogInCommand(this, logInViewModel);
            NavigateCommand =
                new NavigateCommand(formsNavigationService);

            UserName = string.Empty;
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public ICommand LogInCommand { get; }

        public ICommand NavigateCommand { get; }
    }
}