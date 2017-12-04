﻿using System;
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
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(loginButton))
            {
                if (usernameBox.Text == "")
                {
                    usernameBoxDefault.Foreground = Brushes.Red;
                    passwordBoxDefault.Foreground = Brushes.Red;
                    usernameBoxDefault.Opacity = 1;
                    passwordBoxDefault.Opacity = 1;
                }
                else
                {
                    // Instantiate main window's current user
                    main.currUser = new User(usernameBox.Text, passBox.Password.ToString(), DateTime.Today);
                    main.SignIn();
                    //LoginSwitcher.Switch(new FollowingPage());
                }
            }
            else if (sender.Equals(signupButton))
            {
                LoginSwitcher.Switch(new SignupPage());
            }
            else if (sender.Equals(recoverPasswordButton))
            {
                ForgotPasswordPopup popup = new ForgotPasswordPopup(main);
                popup.ShowDialog();
            }
        }

        public void Text_Changed(object sender, EventArgs e)
        { }
    }
}
