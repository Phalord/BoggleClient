using BoogleClient.BoggleServices;
using BoogleClient.Callbacks;
using BoogleClient.Services;
using BoogleClient.ViewModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace BoogleClient.Commands
{
    internal class LogInCommand : BaseCommand
    {
        private LogInFormViewModel logInFormViewModel;
        private readonly NavigationService navigationService;

        public LogInCommand(
            LogInFormViewModel logInFormViewModel,
            NavigationService navigationService)
        {
            this.logInFormViewModel = logInFormViewModel;
            this.navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient =
                new UserManagerContractClient(
                    new InstanceContext(new UserManagerCallback()));

            PasswordBox passwordBox = (PasswordBox) parameter;

            try
            {
                contractClient.LogIn(logInFormViewModel.UserName, passwordBox.Password);
            } catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }
    }
}
