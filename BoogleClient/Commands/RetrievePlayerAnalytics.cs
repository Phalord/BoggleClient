using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BoogleClient.Commands
{
    internal class RetrievePlayerAnalytics : BaseCommand
    {
        private readonly ProfileViewModel profileViewModel;
        private readonly AccountDTO userAccount;

        public RetrievePlayerAnalytics(ProfileViewModel profileViewModel, AccountDTO userAccount)
        {
            this.profileViewModel = profileViewModel;
            this.userAccount = userAccount;
        }

        public override void Execute(object parameter)
        {
            ProfileManagerContractClient contractClient =
                new ProfileManagerContractClient(
                    new System.ServiceModel.InstanceContext(profileViewModel));

            try
            {
                contractClient.RetreivePlayerAnalytics(userAccount.UserName);
            }
            catch (EntryPointNotFoundException)
            {
                MessageBox.Show("Error al establecer conexión con el servidor",
                    "Error de conexión");
            }
        }
    }
}
