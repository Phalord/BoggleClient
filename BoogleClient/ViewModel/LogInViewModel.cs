using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System.Windows;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal partial class LogInViewModel : BaseViewModel, IUserManagerContractCallback
    {
        private readonly NavigationService windowNavigationService;
        private readonly NavigationStore formsNavigationStore;


        #region Constants
        private const string accessGranted = "AccessGranted";
        private const string wrongPassword = "WrongPassword";
        private const string unverifiedEmail = "UnverifiedEmail";
        private const string nonExistentUser = "NonExistentUser";
        private const string usernameRegistered = "UserNameRegistered";
        private const string emailRegistered = "EmailRegistered";
        private const string accountCreated = "AccountCreated";
        private const string emailNotFound = "EmailNotFound";
        private const string wrongValidationCode = "WrongValidationCode";
        private const string emailValidated = "EmailValidated";
        #endregion

        public LogInViewModel(NavigationService windowNavigationService)
        {
            formsNavigationStore = new NavigationStore();
            formsNavigationStore.CurrentViewModel =
                new LogInFormViewModel(this, new NavigationService(
                    formsNavigationStore, CreateRegisterFormViewModel));

            formsNavigationStore
                .CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.windowNavigationService = windowNavigationService;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentFormView));
        }

        public BaseViewModel CurrentFormView =>
            formsNavigationStore.CurrentViewModel;

        private RegisterFormViewModel CreateRegisterFormViewModel()
        {
            return new RegisterFormViewModel(this,
                new NavigationService(formsNavigationStore, CreateLogInFormViewModel));
        }

        private LogInFormViewModel CreateLogInFormViewModel()
        {
            return new LogInFormViewModel(this,
                new NavigationService(formsNavigationStore, CreateRegisterFormViewModel));
        }

        private EmailValidationViewModel CreateEmailValidationViewModel(string userEmail)
        {
            return new EmailValidationViewModel(userEmail);
        }

        public void GrantAccess(string accessStatus)
        {
            if (accessStatus == accessGranted)
            {
                windowNavigationService.Navigate();
            }
            else if (accessStatus == wrongPassword)
            {
                MessageBox.Show(wrongPassword);
            }
            else if (accessStatus == unverifiedEmail)
            {
                formsNavigationStore.CurrentViewModel = CreateEmailValidationViewModel(string.Empty);
            }
            else if (accessStatus == nonExistentUser)
            {
                MessageBox.Show(nonExistentUser);
            }
        }

        public void AskForEmailValidation(string accountCreationStatus, string userEmail)
        {
            if (accountCreationStatus.Equals(usernameRegistered))
            {
                MessageBox.Show(usernameRegistered);
            } else if (accountCreationStatus.Equals(emailRegistered))
            {
                MessageBox.Show(emailRegistered);
            } else if (accountCreationStatus.Equals(accountCreated))
            {
                formsNavigationStore.CurrentViewModel = CreateEmailValidationViewModel(userEmail);
            }
        }

        public void GrantValidation(string validationStatus)
        {
            if (validationStatus.Equals(emailNotFound))
            {

            } else if (validationStatus.Equals(wrongValidationCode))
            {

            } else if (validationStatus.Equals(emailValidated))
            {
                windowNavigationService.Navigate();
            }
        }
    }

    internal partial class LogInFormViewModel : BaseViewModel
    {
        public LogInFormViewModel(
            LogInViewModel logInViewModel,
            NavigationService formsNavigationService)
        {
            LogInCommand = new LogInCommand(this, logInViewModel);
            NavigateCommand = new NavigateCommand(formsNavigationService);
        }

        public string UserName { get; set; }

        public ICommand LogInCommand { get; }

        public ICommand NavigateCommand { get; }
    }

    internal partial class RegisterFormViewModel : BaseViewModel
    {
        public RegisterFormViewModel(
            LogInViewModel logInViewModel,
            NavigationService formsNavigationService)
        {
            NavigateCommand = new NavigateCommand(formsNavigationService);
            CreateAccountCommand = new CreateAccountCommand(this, logInViewModel);
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public ICommand NavigateCommand { get; }

        public ICommand CreateAccountCommand { get; set; }
    }

    internal partial class EmailValidationViewModel : BaseViewModel
    {
        private readonly string userEmail;

        public EmailValidationViewModel(string userEmail)
        {
            this.userEmail = userEmail;
        }
    }
}