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
            notificationStackPanel.Children.Add(new Notification(false, "User2 commented on your photo", "17h"));
            notificationStackPanel.Children.Add(new Notification(false, "User2 replied to your comment", "18h"));
            notificationStackPanel.Children.Add(new Notification(false, "User3 commented on your photo", "3d"));
            notificationStackPanel.Children.Add(new Notification(false, "User4 replied to your comment", "4d"));
            notificationStackPanel.Children.Add(new Notification(false, "User2 commented on your photo", "5d"));
        }

        /// <summary>
        /// Fills the messages submenud with a hardcoded set of messages.
        /// Creates new MessageNotification items and adds them to the submenu.
        /// </summary>
        private void FillMessageNotificationMenu()
        {
            messagesStackPanel.Children.Add(new MessageNotification(false, "User 2", "What lens do you use for your night sky photography?", "3:01 PM"));
        }

        protected void Button_Click(Object sender, EventArgs e)
        {
            if (sender.Equals(followingTab))
            {
                contentControl.Content = new FollowingPage();
            }
            else if (sender.Equals(photosTab))
            {
                contentControl.Content = new PhotosPage();
            }
            else if (sender.Equals(discussionsTab))
            {
                contentControl.Content = new DiscussionPage();
            }
            else if (sender.Equals(savedTab))
            {
                contentControl.Content = new SavedPage();
            }
            else if (sender.Equals(postButton))
            {
                postButtonDropdown.IsOpen = !postButtonDropdown.IsOpen;
            }
            else if (sender.Equals(notificationsButton))
            {
                notificationsButtonDropdown.IsOpen = !notificationsButtonDropdown.IsOpen;
            }
            else if (sender.Equals(messageButton))
            {
                messagesButtonDropdown.IsOpen = !messagesButtonDropdown.IsOpen;
            }
            else if (sender.Equals(accountButton))
            {
                accountButtonDropdown.IsOpen = !accountButtonDropdown.IsOpen;
            }
            else if (sender.Equals(profileButton))
            {
                contentControl.Content = new ProfilePage();
            }
            else if (sender.Equals(message1))
            {
                contentControl.Content = new MessagingPage();
            }
            else if (sender.Equals(seeAllMessagesButton))
            {
                contentControl.Content = new MessagesPage();
            }
            else if (sender.Equals(postPhotoButton))
            {
                MessagesPage test = new MessagesPage();
                test.MessagesPageFill.Fill = new SolidColorBrush(Colors.Black);
                test.NewPhotoFromMessages.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
                test.NewPhotoFromMessages.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
                contentControl.Content = test;
                test.NewPhotoFromMessages.IsOpen = true;
            }
            else if (sender.Equals(postDiscussionButton))
            {
                MessagesPage test = new MessagesPage();
                test.MessagesPageFill.Fill = new SolidColorBrush(Colors.Black);
                test.NewDiscussionFromMessages.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
                test.NewDiscussionFromMessages.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
                contentControl.Content = test;
                test.NewDiscussionFromMessages.IsOpen = true;
            }
        }
    }
}
