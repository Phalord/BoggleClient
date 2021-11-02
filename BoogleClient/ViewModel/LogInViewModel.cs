using BoogleClient.Commands;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal partial class LogInViewModel : BaseViewModel
    {
        public LogInViewModel()
        {
            CurrentFormView = new LogInFormViewModel();
            //CurrentFormView = new RegisterFormViewModel();
            //CurrentFormView = new EmailValidationViewModel();
        }

        public BaseViewModel CurrentFormView { get; set; }

    }

    internal partial class LogInFormViewModel : BaseViewModel
    {
        public string UserName { get; set; }

        public LogInFormViewModel()
        {
            LogInCommand = new LogInCommand(this);
        }

        public ICommand LogInCommand { get; }
    }

    internal partial class RegisterFormViewModel : BaseViewModel
    {

    }

    internal partial class EmailValidationViewModel : BaseViewModel
    {

    }
}