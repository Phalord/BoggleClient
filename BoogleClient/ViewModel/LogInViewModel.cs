using BoogleClient.BoggleServices;
using BoogleClient.Services;
using BoogleClient.Stores;
using System.Windows;

namespace BoogleClient.ViewModel
{
    internal class LogInViewModel : BoggleServiceCallback
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
        private const string playerLogged = "PlayerAlreadyLogged";
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

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentFormView));
        }

        #region Callback

        public override void GrantAccess(string accessStatus, AccountDTO userAccount)
        {
            if (accessStatus.Equals(accessGranted))
            {
                windowNavigationService.Navigate(userAccount);
            }
            else if (accessStatus.Equals(playerLogged))
            {
                MessageBox.Show(playerLogged);
            }
            else if (accessStatus.Equals(wrongPassword))
            {
                MessageBox.Show(wrongPassword);
            }
            else if (accessStatus.Equals(unverifiedEmail))
            {
                formsNavigationStore.CurrentViewModel =
                    CreateEmailValidationViewModel(userAccount.Email);
            }
            else if (accessStatus.Equals(nonExistentUser))
            {
                MessageBox.Show(nonExistentUser);
            }
        }

        public override void AskForEmailValidation(string accountCreationStatus, string userEmail)
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

        public override void GrantValidation(string validationStatus, AccountDTO userAccount)
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
}