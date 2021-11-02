using BoogleClient.Commands;
using BoogleClient.Stores;
using System;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal partial class LogInViewModel : BaseViewModel
    {
        NavigationStore LogInNavigationStore;

        public LogInViewModel(NavigationStore navigationStore)
        {
            LogInNavigationStore = new NavigationStore();
            LogInNavigationStore.CurrentViewModel =
                new LogInFormViewModel(navigationStore, LogInNavigationStore);

            LogInNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentFormView));
        }

        public BaseViewModel CurrentFormView => LogInNavigationStore.CurrentViewModel;

    }

    internal partial class LogInFormViewModel : BaseViewModel
    {
        private readonly NavigationStore windowNavigationStore;
        private readonly NavigationStore logInNavigationStore;

        public LogInFormViewModel(
            NavigationStore windowNavigationStore,
            NavigationStore logInNavigationStore)
        {
            LogInCommand = new LogInCommand(this, windowNavigationStore);
            LogInViewNavigateCommand = new LogInViewNavigateCommand(
                logInNavigationStore, CreateRegisterFormViewModel);
            this.windowNavigationStore = windowNavigationStore;
            this.logInNavigationStore = logInNavigationStore;
        }

        public string UserName { get; set; }

        public ICommand LogInCommand { get; }

        public ICommand LogInViewNavigateCommand { get; }

        private RegisterFormViewModel CreateRegisterFormViewModel()
        {
            return new RegisterFormViewModel(windowNavigationStore, logInNavigationStore);
        }
    }

    internal partial class RegisterFormViewModel : BaseViewModel
    {
        private readonly NavigationStore logInNavigationStore;
        private readonly NavigationStore windowNavigationStore;

        public RegisterFormViewModel(
            NavigationStore windowNavigationStore, NavigationStore logInNavigationStore)
        {
            LogInViewNavigateCommand = new LogInViewNavigateCommand(
                logInNavigationStore, CreateLogInFormViewModel);
            this.logInNavigationStore = logInNavigationStore;
            this.windowNavigationStore = windowNavigationStore;
        }

        private BaseViewModel CreateLogInFormViewModel()
        {
            return new LogInFormViewModel(windowNavigationStore, logInNavigationStore);
        }

        public ICommand LogInViewNavigateCommand { get; }
    }

    internal partial class EmailValidationViewModel : BaseViewModel
    {

    }
}