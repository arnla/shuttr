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
        private PhotosPage currPhotosPage;

        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = new PhotosPage();
            currPhotosPage = (PhotosPage) contentControl.Content;
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
                contentControl.Content = currPhotosPage;
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
                ChangeFill();
                NewPhotoPopup.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
                NewPhotoPopup.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
                NewPhotoPopup.IsOpen = true;
            }
            else if (sender.Equals(postDiscussionButton))
            {
                /**MessagesPage test = new MessagesPage();
                test.MessagesPageFill.Fill = new SolidColorBrush(Colors.Black);
                test.NewDiscussionFromMessages.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
                test.NewDiscussionFromMessages.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
                contentControl.Content = test;
                test.NewDiscussionFromMessages.IsOpen = true;**/
            }
            else if (sender.Equals(CancelPostPhotoButton))
            {
                ChangeFill();
                NewPhotoPopup.IsOpen = false;
                AddedImage.Source = null;
                AddedImage.Visibility = Visibility.Hidden;
                ImageBox.Visibility = Visibility.Visible;
                BrowseButton.Foreground = new SolidColorBrush(Colors.Black);
                AddPhotoTitleBox.Foreground = new SolidColorBrush(Colors.Black);
                AddPhotoCaptionBox.Foreground = new SolidColorBrush(Colors.Black);
                ClosePopup();
            }
            else if (sender.Equals(CancelPostDiscussionButton))
            {
                ChangeFill();
                NewDiscussionPopup.IsOpen = false;
            }
            else if (sender.Equals(BrowseButton))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                var result = dialog.ShowDialog();
                if (result == false)
                    return;
                ImageBox.Visibility = Visibility.Hidden;
                AddedImage.Source = new BitmapImage(new Uri(dialog.FileName));
                AddedImage.Visibility = Visibility.Visible;
            }
            else if (sender.Equals(ConfirmPostPhotoButton))
            {
                bool isComplete = true;
                // check if all fields are filled in
                if (AddedImage.Source == null)
                {
                    BrowseButton.Foreground = new SolidColorBrush(Colors.Red);
                    isComplete = false;
                }
                if (AddPhotoTitleBox.Text.Equals("Add a title"))
                {
                    AddPhotoTitleBox.Foreground = new SolidColorBrush(Colors.Red);
                    isComplete = false;
                }
                if (AddPhotoCaptionBox.Text.Equals("Add a caption"))
                {
                    AddPhotoCaptionBox.Foreground = new SolidColorBrush(Colors.Red);
                    isComplete = false;
                }
                // form is complete
                if (isComplete)
                {
                    currPhotosPage.GetPhotosList().Add(new Photo(AddedImage.Source));
                    ChangeFill();
                    NewPhotoPopup.IsOpen = false;
                    currPhotosPage.DisplayPhotos();
                    ClosePopup();
                }
            }
        }

        public void ChangeFill()
        {
            if (contentControl.Content.GetType() == typeof(PhotosPage))
            {
                PhotosPage photosPage = contentControl.Content as PhotosPage;
                if (ColorsEqual((SolidColorBrush)photosPage.popUpPageFill.Fill, new SolidColorBrush(Colors.Black)))
                    photosPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Transparent);
                else
                    photosPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                photosPage.popUpPageFill.Visibility = Visibility.Visible;
            }
            else if (contentControl.Content.GetType() == typeof(MessagesPage))
            {
                MessagesPage messagesPage = contentControl.Content as MessagesPage;
                if (ColorsEqual((SolidColorBrush)messagesPage.popUpPageFill.Fill, new SolidColorBrush(Colors.Black)))
                    messagesPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Transparent);
                else
                    messagesPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                messagesPage.popUpPageFill.Visibility = Visibility.Visible;
            }
            else if (contentControl.Content.GetType() == typeof(DiscussionPage))
            {
                DiscussionPage discussionPage = contentControl.Content as DiscussionPage;
                if (ColorsEqual((SolidColorBrush)discussionPage.popUpPageFill.Fill, new SolidColorBrush(Colors.Black)))
                    discussionPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Transparent);
                else
                    discussionPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                discussionPage.popUpPageFill.Visibility = Visibility.Visible;
            }
            else if (contentControl.Content.GetType() == typeof(SavedPage))
            {
                SavedPage savedPage = contentControl.Content as SavedPage;
                if (ColorsEqual((SolidColorBrush)savedPage.popUpPageFill.Fill, new SolidColorBrush(Colors.Black)))
                    savedPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Transparent);
                else
                    savedPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                savedPage.popUpPageFill.Visibility = Visibility.Visible;
            }
            else if (contentControl.Content.GetType() == typeof(FollowingPage))
            {
                FollowingPage followingPage = contentControl.Content as FollowingPage;
                if (ColorsEqual((SolidColorBrush)followingPage.popUpPageFill.Fill, new SolidColorBrush(Colors.Black)))
                    followingPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Transparent);
                else
                    followingPage.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                followingPage.popUpPageFill.Visibility = Visibility.Visible;
            }
        }

        public bool ColorsEqual(SolidColorBrush x, SolidColorBrush y)
        {
            if (x.Color == y.Color)
                return true;
            else
                return false;
        }

        public void ClosePopup()
        {
            if (contentControl.Content.GetType() == typeof(PhotosPage))
            {
                PhotosPage photosPage = contentControl.Content as PhotosPage;
                photosPage.popUpPageFill.Visibility = Visibility.Hidden;
            }
            else if (contentControl.Content.GetType() == typeof(MessagesPage))
            {
                MessagesPage messagesPage = contentControl.Content as MessagesPage;
                messagesPage.popUpPageFill.Visibility = Visibility.Hidden;
            }
            else if (contentControl.Content.GetType() == typeof(DiscussionPage))
            {
                DiscussionPage discussionPage = contentControl.Content as DiscussionPage;
                discussionPage.popUpPageFill.Visibility = Visibility.Hidden;
            }
            else if (contentControl.Content.GetType() == typeof(SavedPage))
            {
                SavedPage savedPage = contentControl.Content as SavedPage;
                savedPage.popUpPageFill.Visibility = Visibility.Hidden;
            }
            else if (contentControl.Content.GetType() == typeof(FollowingPage))
            {
                FollowingPage followingPage = contentControl.Content as FollowingPage;
                followingPage.popUpPageFill.Visibility = Visibility.Hidden;
            }
        }
    }
}
