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

namespace shuttr
{
    /// <summary>
    /// Interaction logic for LogoutPromptPopup.xaml
    /// </summary>
    public partial class LogoutPromptPopup : Window
    {
        private MainWindow main;

        public LogoutPromptPopup(MainWindow main)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill();
        }

        /// <summary>
        /// Interaction logic for closing popup prompt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close(object sender, RoutedEventArgs e)
        {
            main.ChangeFill();
            this.Close();
        }

        /// <summary>
        /// Interaction logic for clicking the logout confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmLogout(object sender, RoutedEventArgs e)
        {
            main.contentControl.Content = new LoginPage();
            main.ChangeFill();
            this.Close();
        }

        /// <summary>
        /// Interaction logic for clicking the cancel confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmCancel(object sender, RoutedEventArgs e)
        {
            main.ChangeFill();
            this.Close();
        }
    }
}
