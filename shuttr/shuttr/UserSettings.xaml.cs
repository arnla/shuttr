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
        private string newUserName;
        private string newPassword;
        private string newEmail;

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
                newEmail = newUserName = newPassword = null;

                if (usernameBox.Text.Length != 0)
                {
                    newUserName = usernameBox.Text.ToString();
                }
                if (passwordBox.Text.Length != 0)
                {
                    newPassword = passwordBox.Text.ToString();
                }
                if (emailBox.Text.Length != 0)
                {
                    newEmail = emailBox.Text.ToString();
                }

                if ((newEmail != null) || (newUserName != null) || (newPassword != null))
                {
                    UserSettingsPrompt prompt = new UserSettingsPrompt(main, this);

                    List<string> changes = new List<string>();

                    if (newEmail != null)
                    {
                        changes.Add("email");
                    }
                    if (newUserName != null)
                    {
                        changes.Add("username");
                    }
                    if (newPassword != null)
                    {
                        changes.Add("password");
                    }

                    string message = "Enter your current password to save your new ";
                    if (changes.Count == 1)
                    {
                        message += changes[0];
                    }
                    else
                    {
                        for (int i = 0; i < changes.Count; i++)
                        {
                            if (i == changes.Count - 1)
                            {
                                message += " and " + changes[i];
                            }
                            else
                            {
                                message += " " + changes[i] + ",";
                            }
                        }
                    }

                    prompt.SetMessage(message);
                    prompt.ShowDialog();
                }
            }
        }

        public void MakeChanges()
        {
            displayedUser.UserName = newUserName;
            displayedUser.Password = newPassword;
            displayedUser.Email = newEmail;
            emailBox.Text = "";
            usernameBox.Text = "";
            passwordBox.Text = "";
            settingsLabel.Content = "Your changes have been saved";
            settingsLabel.Foreground = Brushes.Green;
        }
    }

}
