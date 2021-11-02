using BoogleClient.Commands;
using BoogleClient.Services;
using BoogleClient.Stores;
using System;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal partial class LogInViewModel : BaseViewModel
    {
        private readonly NavigationService navigationService;
        private readonly NavigationStore logInNavigationStore;

        public LogInViewModel(NavigationService navigationService)
        {
            logInNavigationStore = new NavigationStore();
            logInNavigationStore.CurrentViewModel =
                new LogInFormViewModel(
                    navigationService,
                    new NavigationService(
                        logInNavigationStore, CreateRegisterFormViewModel));

            logInNavigationStore
                .CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.navigationService = navigationService;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentFormView));
        }

        public BaseViewModel CurrentFormView =>
            logInNavigationStore.CurrentViewModel;


        private RegisterFormViewModel CreateRegisterFormViewModel()
        {
            return new RegisterFormViewModel(new NavigationService(logInNavigationStore, CreateLogInFormViewModel));
        }

        private BaseViewModel CreateLogInFormViewModel()
        {
            return new LogInFormViewModel(
                navigationService,
                new NavigationService(logInNavigationStore, CreateRegisterFormViewModel));
        }
    }

    internal partial class LogInFormViewModel : BaseViewModel
    {

        public LogInFormViewModel(
            NavigationService windowNavigationService,
            NavigationService formsNavigationService)
        {
            LogInCommand = new LogInCommand(this, windowNavigationService);
            NavigateCommand = new NavigateCommand(formsNavigationService);

            NavigationService = windowNavigationService;
        }

        public string UserName { get; set; }

        public ICommand LogInCommand { get; }

        public ICommand NavigateCommand { get; }

        public NavigationService NavigationService { get; }
    }

    internal partial class RegisterFormViewModel : BaseViewModel
    {
        public RegisterFormViewModel(NavigationService formsNavigationService)
        {
            NavigateCommand = new NavigateCommand(formsNavigationService);
        }

        public ICommand NavigateCommand { get; }
    }

    internal partial class EmailValidationViewModel : BaseViewModel
    {

    }
}