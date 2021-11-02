using BoogleClient.BoggleServices;
using BoogleClient.Callbacks;
using BoogleClient.Stores;
using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BoogleClient.Commands
{
    internal class LogInCommand : BaseCommand
    {
        private LogInFormViewModel logInFormViewModel;
        private readonly NavigationStore navigationStore;

        public LogInCommand(LogInFormViewModel logInFormViewModel, NavigationStore navigationStore)
        {
            this.logInFormViewModel = logInFormViewModel;
            this.navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient = new UserManagerContractClient(
                new System.ServiceModel.InstanceContext(new UserManagerCallback()));
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
