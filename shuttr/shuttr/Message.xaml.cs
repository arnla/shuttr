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
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : UserControl
    {
        public Message()
        {
            InitializeComponent();
        }

        public Message(bool user, string username, string message, string date)
        {
            InitializeComponent();

            if (user)
            {
                /*
                C0.Width = new GridLength(13, GridUnitType.Star);
                C1.Width = new GridLength(1, GridUnitType.Star);
                Grid.SetColumn(UserName, 0);
                Grid.SetColumn(DateReceived, 0);
                Grid.SetColumn(MessageContent, 0);
                Grid.SetColumn(UserProfilePicture, 1);*/
                messageBorder.Background = new SolidColorBrush(Colors.PaleTurquoise);
            }

            messageContent.Text = message;
            dateReceived.Content = date;
            userName.Content = username;
        }
    }
}
