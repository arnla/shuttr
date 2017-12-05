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
using System.Windows.Shapes;

namespace shuttr
{
    /// <summary>
    /// Interaction logic for DeletePrompt.xaml
    /// </summary>
    public partial class DeletePrompt : Window
    {
        private MainWindow main;
        private UserControl parent;
        public bool confirmed { get; set; }

        public DeletePrompt(MainWindow main, UserControl parent)
        {
            InitializeComponent();

            this.main = main;
            this.parent = parent;
        }

        public DeletePrompt(UserControl parent)
        {
            InitializeComponent();
            main = null;
            this.parent = parent;
        }

        public void SetMessage(string messageToDisplay)
        {
            message.Text = messageToDisplay;
        }

        public void SetConfirmText(string confirmText)
        {
            confirmButton.Content = confirmText;
        }

        /// <summary>
        /// Interaction logic for closing popup prompt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Interaction logic for clicking the logout confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm(object sender, RoutedEventArgs e)
        {
            if (main != null)
            {
                confirmed = true;
                main.ChangeFill(Visibility.Hidden);
                parent.Visibility = Visibility.Hidden;
                this.Close();
            }
            // For comments deletions
            else
            {
                confirmed = true;
                this.Close();
            }
        }

        /// <summary>
        /// Interaction logic for clicking the cancel confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            confirmed = false;
            this.Close();
        }
    }
}
