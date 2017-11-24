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
        public LoginPage()
        {
            InitializeComponent();
            LoginSwitcher.loginSwitcher = this;
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(loginButton))
            {
                LoginSwitcher.Switch(new FollowingPage());
            }
            else if (sender.Equals(signupButton))
            {
                LoginSwitcher.Switch(new SignupPage());
            }
        }

        public void Text_Changed(object sender, EventArgs e)
        { }
    }
}
