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
    /// Interaction logic for UserSettingsPrompt.xaml
    /// </summary>
    public partial class UserSettingsPrompt : Window
    {
        private MainWindow main;
        private UserSettings parent;

        public UserSettingsPrompt(MainWindow main, UserSettings parent)
        {
            InitializeComponent();

            this.main = main;
            this.parent = parent;
            main.ChangeFill(Visibility.Visible);

            Loaded += PromptLoaded;
        }

        private void PromptLoaded(object sender, RoutedEventArgs e)
        {
            passwordBox.Focus();
        }

        public void SetMessage(string messageToDisplay)
        {
            message.Text = messageToDisplay;
            message.TextAlignment = TextAlignment.Center;
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
            main.ChangeFill(Visibility.Hidden);
            this.Close();
        }

        /// <summary>
        /// Interaction logic for clicking the logout confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm(object sender, RoutedEventArgs e)
        {
            parent.MakeChanges();
            main.ChangeFill(Visibility.Hidden);
            this.Close();
        }

        /// <summary>
        /// Interaction logic for clicking the cancel confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            main.ChangeFill(Visibility.Hidden);
            this.Close();
        }

        public void CheckForEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                parent.MakeChanges();
                main.ChangeFill(Visibility.Hidden);
                this.Close();
            }
        }
    }
}
