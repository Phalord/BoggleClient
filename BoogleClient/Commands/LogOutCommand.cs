using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;

namespace BoogleClient.Commands
{
    internal class LogOutCommand : BaseCommand
    {
        private readonly LogInViewModel logInViewModel;
        private readonly AccountDTO userAccount;

        public LogOutCommand(
            LogInViewModel logInViewModel,
            AccountDTO userAccount)
        {
            this.logInViewModel = logInViewModel;
            this.userAccount = userAccount;
        }

        public override void Execute(object parameter)
        {
            UserManagerContractClient contractClient =
                new UserManagerContractClient(
                    new System.ServiceModel.InstanceContext(logInViewModel));

            try
            {
                contractClient.LogOut(userAccount.UserName);
            }
            catch(EntryPointNotFoundException entryPointException)
            {
                Console.WriteLine(entryPointException.Message);
            }
        }
    }
}
