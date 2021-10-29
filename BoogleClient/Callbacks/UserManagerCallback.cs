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

        public void GrantAccess(bool access)
        {
            if (access)
            {
                MessageBox.Show("Acceso Permitido!");
            } else
            {
                MessageBox.Show("Acceso Denegado!");
            }
        }
    }
}
