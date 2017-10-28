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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = new PhotosPage();
            //PhotosTab.Foreground = new SolidColorBrush(Color.FromRgb(116, 118, 119));

            FillNotificationMenu();
            FillMessageNotificationMenu();
        }

        /// <summary>
        /// Fills the notification submenu with a hardcoded set of notifications.
        /// Creates new Notification items and adds them to the submenu.
        /// </summary>
        private void FillNotificationMenu()
        {
            NotificationStackPanel.Children.Add(new Notification(false, "User2 commented on your photo", "17h"));
            NotificationStackPanel.Children.Add(new Notification(false, "User2 replied to your comment", "18h"));
            NotificationStackPanel.Children.Add(new Notification(false, "User3 commented on your photo", "3d"));
            NotificationStackPanel.Children.Add(new Notification(false, "User4 replied to your comment", "4d"));
            NotificationStackPanel.Children.Add(new Notification(false, "User2 commented on your photo", "5d"));
        }

        /// <summary>
        /// Fills the messages submenud with a hardcoded set of messages.
        /// Creates new MessageNotification items and adds them to the submenu.
        /// </summary>
        private void FillMessageNotificationMenu()
        {
            MessagesStackPanel.Children.Add(new MessageNotification(false, "User 2", "What lens do you use for your night sky photography?", "3:01 PM"));
        }

        protected void Button_Click(Object sender, EventArgs e)
        {
            // Some stuff happens here.
            if (sender.Equals(PhotosTab))
            {
                contentControl.Content = new PhotosPage();
            }
            else if (sender.Equals(DiscussionsTab))
            {
                contentControl.Content = new DiscussionPage();
            }
            else if (sender.Equals(PostButton))
            {
                PostButtonDropdown.IsOpen = !PostButtonDropdown.IsOpen;
            }
            else if (sender.Equals(NotificationsButton))
            {
                NotificationsButtonDropdown.IsOpen = !NotificationsButtonDropdown.IsOpen;
            }
            else if (sender.Equals(MessageButton))
            {
                MessagesButtonDropdown.IsOpen = !MessagesButtonDropdown.IsOpen;
            }
            else if (sender.Equals(AccountButton))
            {
                AccountButtonDropdown.IsOpen = !AccountButtonDropdown.IsOpen;
            }
            else if (sender.Equals(SeeAllMessagesButton))
            {
                contentControl.Content = new MessagesPage();
            }
        }
    }
}
