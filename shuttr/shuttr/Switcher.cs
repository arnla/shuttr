using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace shuttr
{
    class LoginSwitcher
    {
        public static LoginPage loginSwitcher;

        public static void Switch(UserControl newPage)
        {
            loginSwitcher.Navigate(newPage);
        }
    }

    class SignupSwitcher
    {
        public static SignupPage signupSwitcher;

        public static void Switch(UserControl newPage)
        {
            signupSwitcher.Navigate(newPage);
        }
    }
}
