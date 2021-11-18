
using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace BoogleClient.Commands
{
    internal class CreateAccountCommand : BaseCommand
    {
        private readonly RegisterFormViewModel registerFormViewModel;
        private readonly LogInViewModel logInViewModel;

        public CreateAccountCommand(
            RegisterFormViewModel registerFormViewModel,
            LogInViewModel logInViewModel)
        {
            this.registerFormViewModel = registerFormViewModel;
            this.logInViewModel = logInViewModel;

            registerFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterFormViewModel.UserName)
                || e.PropertyName == nameof(RegisterFormViewModel.Email)
                || e.PropertyName == nameof(RegisterFormViewModel.Password)
                || e.PropertyName == nameof(RegisterFormViewModel.PasswordConfirmation))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            bool canExecute = false;

            if (!AreInputBoxesEmpty())
            {
                if (PasswordMatches())
                {
                    canExecute = true;
                }
            }

            return canExecute;
        }

        private bool PasswordMatches()
        {
            return registerFormViewModel.Password.Equals(
                registerFormViewModel.PasswordConfirmation);
        }

        private bool AreInputBoxesEmpty()
        {
            return registerFormViewModel.Email == string.Empty
                || registerFormViewModel.UserName == string.Empty
                || registerFormViewModel.Password == string.Empty
                || registerFormViewModel.PasswordConfirmation == string.Empty;
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient =
                new UserManagerContractClient(
                    new InstanceContext(logInViewModel));

            string hashedPassword =
                GenerateHashedPassword((PasswordBox)parameter);
            
            AccountDTO accountDTO = new AccountDTO
            {
                UserName = registerFormViewModel.UserName,
                Email = registerFormViewModel.Email,
                Password = hashedPassword
            };

            try
            {
                contractClient.CreateAccount(accountDTO);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor", "Error de conexión");
            }
        }

        private string GenerateHashedPassword(PasswordBox parameter)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(7);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(parameter.Password, salt);

            return hashedPassword;
        }
    }
}
