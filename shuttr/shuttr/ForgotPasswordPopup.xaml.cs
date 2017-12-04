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
            main.ChangeFill();
            submitted = false;
        }

        private void close(object sender, RoutedEventArgs e)
        {
            main.ChangeFill();
            this.Close();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (submitted == false)
            {
                headText.Text = "We sent instructions to the email";
                subText.Text = "associated with that account";
                usernameOrEmailBox.Visibility = Visibility.Collapsed;
                submitButton.Content = "Got it!";
                submitted = true;
            }
            // Else it is the "Got it" button
            else
            {
                main.ChangeFill();
                this.Close();
            }

        }
    }
}
