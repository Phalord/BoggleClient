using BoogleClient.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BoogleClient.Views
{
    /// <summary>
    /// Interaction logic for RegisterFormView.xaml
    /// </summary>
    public partial class RegisterFormView : UserControl
    {
        public RegisterFormView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((RegisterFormViewModel)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((RegisterFormViewModel)DataContext).PasswordConfirmation = ((PasswordBox)sender).Password;
            }
        }

        private void InputPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.ContextMenu ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
