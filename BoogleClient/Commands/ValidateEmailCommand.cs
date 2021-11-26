using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;

namespace BoogleClient.Commands
{
    class ValidateEmailCommand : BaseCommand
    {
        private readonly EmailValidationViewModel emailValidationViewModel;
        private readonly LogInViewModel logInViewModel;
        private readonly string userEmail;

        public ValidateEmailCommand(
            EmailValidationViewModel emailValidationViewModel,
            LogInViewModel logInViewModel,
            string userEmail)
        {
            this.emailValidationViewModel = emailValidationViewModel;
            this.logInViewModel = logInViewModel;
            this.userEmail = userEmail;

            emailValidationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            BoggleServiceContractsClient contractsClient =
                new BoggleServiceContractsClient(
                    new InstanceContext(logInViewModel));
            try
            {
                contractsClient.ValidateEmail(
                    emailValidationViewModel.ValidationCode, userEmail);
            } catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return emailValidationViewModel.ValidationCode.Length.Equals(5)
                && !emailValidationViewModel.IsWaiting;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(EmailValidationViewModel.IsWaiting)
                || e.PropertyName == nameof(EmailValidationViewModel.ValidationCode))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
