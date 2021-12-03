using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace BoogleClient.Commands
{
    internal class LogInCommand : BaseCommand
    {
        private readonly LogInFormViewModel logInFormViewModel;
        private readonly LogInViewModel logInViewModel;

        public LogInCommand(
            LogInFormViewModel logInFormViewModel,
            LogInViewModel logInViewModel)
        {
            this.logInFormViewModel = logInFormViewModel;
            this.logInViewModel = logInViewModel;
        }

        public override void Execute(object parameter)
        {
            BoggleServiceContractsClient contractsClient =
                new BoggleServiceContractsClient(
                    new InstanceContext(logInViewModel));

            PasswordBox passwordBox = (PasswordBox) parameter;

            try
            {
                contractsClient.LogIn(logInFormViewModel.UserName, passwordBox.Password);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }
    }
}
