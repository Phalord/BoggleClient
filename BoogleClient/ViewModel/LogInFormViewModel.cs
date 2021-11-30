using BoogleClient.Commands;
using BoogleClient.Services;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class LogInFormViewModel : BaseViewModel
    {
        public LogInFormViewModel(
            LogInViewModel logInViewModel,
            NavigationService formsNavigationService)
        {
            LogInCommand = new LogInCommand(this, logInViewModel);
            NavigateCommand =
                new NavigateCommand(formsNavigationService, null);
        }

        public string UserName { get; set; }

        public ICommand LogInCommand { get; }

        public ICommand NavigateCommand { get; }
    }
}