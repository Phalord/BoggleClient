
using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace BoogleClient.Commands
{
    internal class CreateAccountCommand : BaseCommand
    {
        private RegisterFormViewModel registerFormViewModel;
        private readonly LogInViewModel logInViewModel;

        public CreateAccountCommand(RegisterFormViewModel registerFormViewModel, LogInViewModel logInViewModel)
        {
            this.registerFormViewModel = registerFormViewModel;
            this.logInViewModel = logInViewModel;
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient =
                new UserManagerContractClient(
                    new InstanceContext(logInViewModel));

            PasswordBox passwordBox = (PasswordBox)parameter;

            try
            {
                contractClient.CreateAccount(registerFormViewModel.UserName, registerFormViewModel.Email, passwordBox.Password);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }
    }
}
