using System.Windows;
using System.Windows.Input;

namespace BoogleClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Window Window => Application.Current.MainWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        /// <summary>
        /// Drag Window by clicking the custom titlebar
        /// </summary>
        private void Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Window.DragMove();
            }
        }
    }
}
