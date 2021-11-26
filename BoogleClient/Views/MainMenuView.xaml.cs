using System;
using System.Windows;
using System.Windows.Controls;

namespace BoogleClient.Views
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Boton apretado");
            Console.WriteLine(((Button)sender).Command.ToString());
            Console.WriteLine(((Button)sender).CommandBindings.ToString());
        }
    }
}
