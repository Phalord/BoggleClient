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
        private const string accessGranted = "AccessGranted";
        private const string wrongPassword = "WrongPassword";
        private const string unverifiedEmail = "UnverifiedEmail";
        private const string nonExistentUser = "NonExistentUser";

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
            return new RegisterFormViewModel(new NavigationService(formsNavigationStore, CreateLogInFormViewModel));
        }

        private BaseViewModel CreateLogInFormViewModel()
        {
            return new LogInFormViewModel(this,
                new NavigationService(formsNavigationStore, CreateRegisterFormViewModel));
        }

        public void AskForEmailValidation()
        {
            MessageBox.Show("User Created");
        }

        public void GrantAccess(string accessStatus)
        {
            if (accessStatus == accessGranted)
            {
                MessageBox.Show(accessGranted);
            }
            else if (accessStatus == wrongPassword)
            {
                MessageBox.Show(wrongPassword);
            }
            else if (accessStatus == unverifiedEmail)
            {
                MessageBox.Show(unverifiedEmail);
            }
            else if (accessStatus == nonExistentUser)
            {
                MessageBox.Show(nonExistentUser);
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
        public RegisterFormViewModel(NavigationService formsNavigationService)
        {
            NavigateCommand = new NavigateCommand(formsNavigationService);
            CreateAccountCommand = new CreateAccountCommand(this);
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public ICommand NavigateCommand { get; }

        public ICommand CreateAccountCommand { get; set; }
    }

    internal partial class EmailValidationViewModel : BaseViewModel
    {

    }
}