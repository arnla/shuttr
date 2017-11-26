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
using Microsoft.Win32;

namespace shuttr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PhotosPage currPhotosPage = new PhotosPage();
        private DiscussionPage currDiscussionPage = new DiscussionPage();
        private FollowingPage currFollowingPage = new FollowingPage();
        private MessagesPage currMessagesPage = new MessagesPage();
        private SavedPage currSavedPage = new SavedPage();

        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = currPhotosPage;
            //PhotosTab.Foreground = new SolidColorBrush(Color.FromRgb(116, 118, 119));

            FillNotificationMenu();
            FillMessageNotificationMenu();

            currDiscussionPage.SetParent(this);
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
                contentControl.Content = currFollowingPage;
            }
            else if (sender.Equals(photosTab))
            {
                contentControl.Content = currPhotosPage;
            }
            else if (sender.Equals(discussionsTab))
            {
                contentControl.Content = currDiscussionPage;
            }
            else if (sender.Equals(savedTab))
            {
                contentControl.Content = currSavedPage;
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
            else if (sender.Equals(logoutButton))
            {
                contentControl.Content = new LoginPage();
            }
            else if (sender.Equals(message1))
            {
                contentControl.Content = new MessagingPage();
            }
            else if (sender.Equals(seeAllMessagesButton))
            {
                contentControl.Content = currMessagesPage;
            }
            else if (sender.Equals(postPhotoButton))
            {
                PostPhotoPopup photoPopup = new PostPhotoPopup(this);
                photoPopup.SetValue(Grid.RowProperty, 2);
                photoPopup.SetValue(Grid.ColumnSpanProperty, 3);
                mainGrid.Children.Add(photoPopup);
            }
            else if (sender.Equals(postDiscussionButton))
            {
                PostDiscussionPopup discussionPopup = new PostDiscussionPopup(this);
                discussionPopup.SetValue(Grid.RowProperty, 2);
                discussionPopup.SetValue(Grid.ColumnSpanProperty, 3);
                mainGrid.Children.Add(discussionPopup);
            }
        }

        public void AddPhoto(Photo pic, string t, string c)
        {
            pic.title = t;
            pic.caption = c;
            currPhotosPage.GetPhotosList().Add(pic);
            currPhotosPage.DisplayPhotos();
        }

        public void AddDiscussion(string username, string title, string description, int numReplies)
        {
            currDiscussionPage.AddDiscussionPost(new Discussion(currDiscussionPage.GetDiscussionIdCtr() + 1, username, title, description, numReplies));
        }

        public void ChangeFill()
        {
            if (popUpPageFill.Visibility == Visibility.Hidden)
                popUpPageFill.Visibility = Visibility.Visible;
            else
                popUpPageFill.Visibility = Visibility.Hidden;
        }
    }
}
