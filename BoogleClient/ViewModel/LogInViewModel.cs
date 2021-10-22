namespace BoogleClient.ViewModel
{
    internal partial class LogInViewModel : BaseViewModel
    {
        public LogInViewModel()
        {
            //CurrentFormView = new LogInFormViewModel();
            CurrentFormView = new RegisterFormViewModel();
        }

        public BaseViewModel CurrentFormView { get; set; }

    }

    internal partial class LogInFormViewModel : BaseViewModel
    {
        
    }

    internal partial class RegisterFormViewModel : BaseViewModel
    {

    }
}