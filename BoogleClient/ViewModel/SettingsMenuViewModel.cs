using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class SettingsMenuViewModel : BaseViewModel
    {
        public SettingsMenuViewModel(
            AccountDTO userAccount,
            LogInViewModel logInViewModel)
        {
            LogOutCommand = new LogOutCommand(logInViewModel, userAccount);
        }

        public ICommand LogOutCommand { get; set; }
    }
}
