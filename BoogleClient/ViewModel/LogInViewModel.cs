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
            
            this.windowNavigationService = windowNavigationService;

            formsNavigationStore
                .CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentFormView));
        }

        public BaseViewModel CurrentFormView =>
            formsNavigationStore.CurrentViewModel;

        private RegisterFormViewModel CreateRegisterFormViewModel(AccountDTO userAccount)
        {
            return new RegisterFormViewModel(this,
                new NavigationService(formsNavigationStore, CreateLogInFormViewModel));
        }

        private LogInFormViewModel CreateLogInFormViewModel(AccountDTO userAccount)
        {
            return new LogInFormViewModel(this,
                new NavigationService(formsNavigationStore, CreateRegisterFormViewModel));
        }

        private EmailValidationViewModel CreateEmailValidationViewModel(string userEmail)
        {
            return new EmailValidationViewModel(this, userEmail);
        }

        #region Callback
        public void GrantAccess(string accessStatus, AccountDTO userAccount)
        {
            if (accessStatus == accessGranted)
            {
                windowNavigationService.Navigate(userAccount);
            }
            else if (accessStatus == wrongPassword)
            {
                MessageBox.Show(wrongPassword);
            }
            else if (accessStatus == unverifiedEmail)
            {
                formsNavigationStore.CurrentViewModel =
                    CreateEmailValidationViewModel(userAccount.Email);
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
            }
            else if (accountCreationStatus.Equals(emailRegistered))
            {
                MessageBox.Show(emailRegistered);
            }
            else if (accountCreationStatus.Equals(accountCreated))
            {
                formsNavigationStore.CurrentViewModel = CreateEmailValidationViewModel(userEmail);
            }
        }

        public void GrantValidation(string validationStatus, AccountDTO userAccount)
        {
            if (validationStatus.Equals(emailNotFound))
            {
                MessageBox.Show(emailNotFound);
            }
            else if (validationStatus.Equals(wrongValidationCode))
            {
                MessageBox.Show(wrongValidationCode);
            }
            else if (validationStatus.Equals(emailValidated))
            {
                windowNavigationService.Navigate(userAccount);
            }
        }

        #endregion

    }

    internal partial class LogInFormViewModel : BaseViewModel
    {
        public LogInFormViewModel(
            LogInViewModel logInViewModel,
            NavigationService formsNavigationService)
        {
            LogInCommand = new LogInCommand(this, logInViewModel);
            NavigateCommand = new NavigateCommand(formsNavigationService, null);
        }

        public string UserName { get; set; }

        public ICommand LogInCommand { get; }

        public ICommand NavigateCommand { get; }
    }

    internal partial class RegisterFormViewModel : BaseViewModel
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

    internal partial class EmailValidationViewModel : BaseViewModel
    {
        private bool isWaiting;
        private string validationCode;

        public EmailValidationViewModel(
            LogInViewModel logInViewModel,
            string userEmail)
        {
            ValidateEmailCommand = new ValidateEmailCommand(this, logInViewModel, userEmail);
            IsWaiting = false;
            ValidationCode = string.Empty;
        }

        public bool IsWaiting
        {
            get => isWaiting;
            set
            {
                isWaiting = value;
                OnPropertyChanged(nameof(IsWaiting));
            }
        }

        public string ValidationCode
        {
            get => validationCode;
            set
            {
                validationCode = value;
                OnPropertyChanged(nameof(ValidationCode));
            }
        }

        public ICommand ValidateEmailCommand { get; set; }
    }
}