using BoogleClient.BoggleServices;
using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoogleClient.Callbacks
{
    class UserManagerCallback : IUserManagerContractCallback
    {
        private MainViewModel mainViewModel;
        private const string accessGranted = "AccessGranted";
        private const string wrongPassword = "WrongPassword";
        private const string unverifiedEmail = "UnverifiedEmail";
        private const string nonExistentUser = "NonExistentUser";

        public void AskForEmailValidation()
        {
            MessageBox.Show("User Created");
        }

        public void GrantAccess(string accessStatus)
        {
            if (accessStatus == accessGranted)
            {
                MessageBox.Show(accessGranted);
            } else if (accessStatus == wrongPassword)
            {
                MessageBox.Show(wrongPassword);
            } else if (accessStatus == unverifiedEmail)
            {
                MessageBox.Show(unverifiedEmail);
            } else if (accessStatus == nonExistentUser)
            {
                MessageBox.Show(nonExistentUser);
            }
        }
    }
}
