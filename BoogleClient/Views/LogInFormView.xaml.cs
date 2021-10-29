using BoogleClient.BoggleServices;
using BoogleClient.Callbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoogleClient.Views
{
    /// <summary>
    /// Interaction logic for LogInFormView.xaml
    /// </summary>
    public partial class LogInFormView : UserControl
    {
        public LogInFormView()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserManagerContractClient contractClient = new UserManagerContractClient(new System.ServiceModel.InstanceContext(new UserManagerCallback()));
            MessageBox.Show("Loggeando como " + usernameTextBox.Text + " : " + passwordTextBox.Password);
            contractClient.LogIn(usernameTextBox.Text, passwordTextBox.Password.ToString());
        }
    }
}
