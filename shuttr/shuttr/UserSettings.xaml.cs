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
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : ContentControl
    {
        private MainWindow main;
        private User displayedUser;

        public UserSettings(MainWindow parent, User currentUser)
        {
            InitializeComponent();

            displayedUser = currentUser;
            main = parent;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(changeButton))
            {
                if (usernameBox.Text.Length != 0)
                {
                    displayedUser.UserName = usernameBox.Text.ToString();
                }
                if (passwordBox.Text.Length != 0)
                {
                    displayedUser.Password = passwordBox.Text.ToString();
                }
                if (emailBox.Text.Length != 0)
                {
                    displayedUser.Email = emailBox.Text.ToString();
                }
            }
        }

    }

}
