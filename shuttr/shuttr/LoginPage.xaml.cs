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
    /// Interaction logic for PhotosPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        private MainWindow main;

        public LoginPage(MainWindow main)
        {
            InitializeComponent();
            LoginSwitcher.loginSwitcher = this;
            this.main = main;

            Loaded += LoginLoaded;
        }

        private void LoginLoaded(object sender, RoutedEventArgs e)
        {
            usernameBox.Focus();
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            bool formComplete = true;
            if (sender.Equals(loginButton))
            {
                if (usernameBox.Text == "")
                {
                    usernameBoxDefault.Foreground = Brushes.Red;
                    usernameBoxDefault.Opacity = 1;
                    formComplete = false;
                }
                if (passBox.Password == "")
                {
                    passwordBoxDefault.Foreground = Brushes.Red;
                    passwordBoxDefault.Opacity = 1;
                    formComplete = false;
                }
                if (formComplete)
                {
                    // Instantiate main window's current user
                    main.currUser = new User(usernameBox.Text, passBox.Password.ToString(), DateTime.Today);
                    main.SignIn();
                    //LoginSwitcher.Switch(new FollowingPage());
                }
            }
            else if (sender.Equals(signupButton))
            {
                LoginSwitcher.Switch(new SignupPage(main));
            }
            else if (sender.Equals(recoverPasswordButton))
            {
                ForgotPasswordPopup popup = new ForgotPasswordPopup(main);
                popup.ShowDialog();
            }
        }

        public void passwordChanged(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(passBox.Password))
            {
                passwordBoxDefault.Text = "";
            }
            else
            {
                passwordBoxDefault.Text = "Password";
            }
        }

        public void Text_Changed(object sender, EventArgs e)
        { }

        public void NextField(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                passBox.Focus();
            }
        }

        public void CheckForEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bool formComplete = true;

                if (passBox.Password == "")
                {
                    passwordBoxDefault.Foreground = Brushes.Red;
                    passwordBoxDefault.Opacity = 1;
                    formComplete = false;
                    passBox.Focus();
                }
                if (usernameBox.Text == "")
                {
                    usernameBoxDefault.Foreground = Brushes.Red;
                    usernameBoxDefault.Opacity = 1;
                    formComplete = false;
                    usernameBox.Focus();
                }
                if (formComplete)
                {
                    //SignupSwitcher.Switch(new FollowingPage());
                    main.currUser = new User(usernameBox.Text, passBox.Password.ToString(), DateTime.Today);
                    main.SignIn();
                }
            }
        }
    }
}
