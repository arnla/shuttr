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
        public SignupPage()
        {
            InitializeComponent();
            SignupSwitcher.signupSwitcher = this;
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(signupButton))
            {
                SignupSwitcher.Switch(new FollowingPage());
            }
        }

        private void passwordBoxDefault_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBoxDefault.Text = "";
        }

        private void passwordBoxDefault_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            passwordBoxDefault.Text = "";
        }
    }
}
