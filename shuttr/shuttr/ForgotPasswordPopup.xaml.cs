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
    /// Interaction logic for ForgotPasswordPopup.xaml
    /// </summary>
    public partial class ForgotPasswordPopup : Window
    {
        private MainWindow main;
        private bool submitted;

        public ForgotPasswordPopup(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            main.ChangeFill(Visibility.Visible);
            submitted = false;

            Loaded += PromptLoaded;
        }

        private void PromptLoaded(object sender, RoutedEventArgs e)
        {
            usernameOrEmailBox.Focus();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            main.ChangeFill(Visibility.Hidden);
            this.Close();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (submitted == false)
            {
                if (usernameOrEmailBox.Text == "")
                {
                    usernameOrEmailBoxDefault.Foreground = Brushes.Red;
                    usernameOrEmailBoxDefault.Opacity = 1;
                }
                else
                {
                    headText.Text = "We sent instructions to the email";
                    subText.Text = "associated with that account";
                    usernameOrEmailBox.Visibility = Visibility.Collapsed;
                    submitButton.Content = "Got it!";
                    submitted = true;
                }
            }
            // Else it is the "Got it" button
            else
            {
                main.ChangeFill(Visibility.Hidden);
                this.Close();
            }

        }

        public void CheckForEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (submitted == false)
                {
                    if (usernameOrEmailBox.Text == "")
                    {
                        usernameOrEmailBoxDefault.Foreground = Brushes.Red;
                        usernameOrEmailBoxDefault.Opacity = 1;
                        usernameOrEmailBox.Focus();
                    }
                    else
                    {
                        headText.Text = "We sent instructions to the email";
                        subText.Text = "associated with that account";
                        usernameOrEmailBox.Visibility = Visibility.Collapsed;
                        submitButton.Content = "Got it!";
                        submitted = true;
                    }
                }
                // Else it is the "Got it" button
                else
                {
                    main.ChangeFill(Visibility.Hidden);
                    this.Close();
                }
            }
        }
    }
}
