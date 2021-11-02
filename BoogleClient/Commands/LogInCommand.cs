using BoogleClient.BoggleServices;
using BoogleClient.Callbacks;
using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BoogleClient.Commands
{
    internal class LogInCommand : BaseCommand
    {
        private LogInFormViewModel logInFormViewModel;

        public LogInCommand(LogInFormViewModel logInFormViewModel)
        {
            this.logInFormViewModel = logInFormViewModel;
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient = new UserManagerContractClient(
                new System.ServiceModel.InstanceContext(new UserManagerCallback()));
            PasswordBox passwordBox = (PasswordBox) parameter;
            contractClient.LogIn(logInFormViewModel.UserName, passwordBox.Password);
        }
    }
}
