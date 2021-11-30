using BoogleClient.Commands;
using BoogleClient.Services;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class RegisterFormViewModel : BaseViewModel
    {
        private string userName;
        private string email;
        private string password;
        private string passwordConfirmation;

        public RegisterFormViewModel(
            LogInViewModel logInViewModel,
            NavigationService formsNavigationService)
        {
            NavigateCommand = new NavigateCommand(formsNavigationService, null);
            CreateAccountCommand = new CreateAccountCommand(this, logInViewModel);
            Password = string.Empty;
            PasswordConfirmation = string.Empty;
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

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string PasswordConfirmation
        {
            get => passwordConfirmation;
            set
            {
                passwordConfirmation = value;
                OnPropertyChanged(nameof(PasswordConfirmation));
            }
        }

        public ICommand NavigateCommand { get; }

        public ICommand CreateAccountCommand { get; set; }
    }
}