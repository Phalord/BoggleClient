using BoogleClient.Commands;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class EmailValidationViewModel : BaseViewModel
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