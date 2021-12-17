using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.ComponentModel;
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

            logInFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LogInFormViewModel.UserName))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient =
                new UserManagerContractClient(
                    new InstanceContext(logInViewModel));

            PasswordBox passwordBox = (PasswordBox) parameter;

            try
            {
                contractClient.LogIn(logInFormViewModel.UserName, passwordBox.Password);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }
    }
}
