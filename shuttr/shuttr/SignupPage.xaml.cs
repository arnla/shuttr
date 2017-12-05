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
    public partial class SignupPage : UserControl
    {
        private MainWindow main;

        public SignupPage(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            SignupSwitcher.signupSwitcher = this;
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            bool formComplete = true;
            if (sender.Equals(signupButton))
            {
                if (emailBox.Text == "")
                {
                    emailBoxDefault.Foreground = Brushes.Red;
                    emailBoxDefault.Opacity = 1;
                    formComplete = false;
                }
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
                    //SignupSwitcher.Switch(new FollowingPage());
                    main.SignIn();
                }
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

        public void LoginClick(object sender, RoutedEventArgs e)
        {
            main.contentControl.Content = new LoginPage(main);
        }
    }
}
