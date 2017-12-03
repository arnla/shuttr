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
        public PhotosPage currPhotosPage { get; } = new PhotosPage();
        public DiscussionPage currDiscussionPage { get; } = new DiscussionPage();
        public FollowingPage currFollowingPage { get; } = new FollowingPage();
        public MessagesPage currMessagesPage { get; } = new MessagesPage();
        public SavedPage currSavedPage { get; } = new SavedPage();
        public User currUser { get; } = new User("photographyman", "password", DateTime.Today);

        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = currPhotosPage;
            HighlightTab();
            //PhotosTab.Foreground = new SolidColorBrush(Color.FromRgb(116, 118, 119));

            FillNotificationMenu();
            FillMessageNotificationMenu();

            currDiscussionPage.SetParent(this);
            currPhotosPage.SetParent(this);
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
            if ((sender.Equals(followingTab)) || (sender.Equals(logoButton)))
            {
                contentControl.Content = currFollowingPage;
                HighlightTab();
            }
            else if (sender.Equals(photosTab))
            {
                contentControl.Content = currPhotosPage;
                HighlightTab();
            }
            else if (sender.Equals(discussionsTab))
            {
                contentControl.Content = currDiscussionPage;
                HighlightTab();
            }
            else if (sender.Equals(savedTab))
            {
                contentControl.Content = currSavedPage;
                HighlightTab();
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
                contentControl.Content = new ProfilePage(this, currUser);
                HighlightTab();
            }
            else if (sender.Equals(userSettingButton))
            {
                contentControl.Content = new UserSettings();
                HighlightTab();
            }
            else if (sender.Equals(logoutButton))
            {
                contentControl.Content = new LoginPage();
                HighlightTab();
            }
            else if (sender.Equals(message1))
            {
                contentControl.Content = new MessagingPage();
                HighlightTab();
            }
            else if (sender.Equals(seeAllMessagesButton))
            {
                contentControl.Content = currMessagesPage;
                HighlightTab();
            }
            else if (sender.Equals(postPhotoButton))
            {
                postButtonDropdown.IsOpen = false;
                PostPhotoPopup photoPopup = new PostPhotoPopup(this);
                photoPopup.SetValue(Grid.RowProperty, 2);
                photoPopup.SetValue(Grid.ColumnSpanProperty, 3);
                mainGrid.Children.Add(photoPopup);
            }
            else if (sender.Equals(postDiscussionButton))
            {
                postButtonDropdown.IsOpen = false;
                PostDiscussionPopup discussionPopup = new PostDiscussionPopup(this);
                discussionPopup.SetValue(Grid.RowProperty, 2);
                discussionPopup.SetValue(Grid.ColumnSpanProperty, 3);
                mainGrid.Children.Add(discussionPopup);
            }
        }

        public void AddPhoto(Photo pic, string title, string description)
        {
            pic.title = title;
            pic.caption = description;
            currPhotosPage.AddPhoto(pic);
        }

        public void AddDiscussion(string username, string title, string description, int numReplies)
        {
            currDiscussionPage.AddDiscussionPost(new Discussion(currDiscussionPage.GetDiscussionIdCtr(), username, title, description, numReplies));
        }

        public void ChangeFill()
        {
            if ((popUpPageFill.Visibility == Visibility.Hidden) || (popUpPageFill.Visibility == Visibility.Collapsed))
                popUpPageFill.Visibility = Visibility.Visible;
            else
                popUpPageFill.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Highlights the tab that is currently in view.
        /// If the content is not one of the tabs, sets them all to unhighlighted.
        /// </summary>
        public void HighlightTab()
        {
            if (contentControl.Content.Equals(currPhotosPage))
            {
                photosTab.Foreground = new SolidColorBrush(Colors.White);
                discussionsTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                followingTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                savedTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
            }
            else if (contentControl.Content.Equals(currDiscussionPage))
            {
                photosTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                discussionsTab.Foreground = new SolidColorBrush(Colors.White);
                followingTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                savedTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
            }
            else if (contentControl.Content.Equals(currFollowingPage))
            {
                photosTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                discussionsTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                followingTab.Foreground = new SolidColorBrush(Colors.White);
                savedTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
            }
            else if (contentControl.Content.Equals(currSavedPage))
            {
                photosTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                discussionsTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                followingTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                savedTab.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                photosTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                discussionsTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                followingTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
                savedTab.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7B7B7"));
            }
        }

        /// <summary>
        /// Hardcoded for the search "mountain"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchSuggestions(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                contentControl.Content = new SearchResultsPage(this);
                searchResultsPopup.IsOpen = false;
                HighlightTab();
            }
            else
            {
                string text = searchBox.Text;

                if (text.Length == 0)
                {
                    searchResults.Children.Clear();

                    searchResultsPopup.IsOpen = true;

                    AddSearchResult("m");
                    AddSearchResult("moe");
                    AddSearchResult("mouse");
                    AddSearchResult("mickey mouse");
                    AddSearchResult("mountains");
                    AddSearchResult("mountain biking");
                }
                else if (text.Length == 1)
                {
                    searchResults.Children.Clear();

                    searchResultsPopup.IsOpen = true;

                    AddSearchResult("mo");
                    AddSearchResult("moe");
                    AddSearchResult("mouse");
                    AddSearchResult("mickey mouse");
                    AddSearchResult("mountains");
                    AddSearchResult("mountain biking");
                }
                else if (text.Length == 2)
                {
                    searchResults.Children.Clear();

                    searchResultsPopup.IsOpen = true;

                    AddSearchResult("mou");
                    AddSearchResult("mouse");
                    AddSearchResult("mickey mouse");
                    AddSearchResult("mountains");
                    AddSearchResult("mountain biking");
                }
                else if (text.Length == 3)
                {
                    searchResults.Children.Clear();

                    searchResultsPopup.IsOpen = true;

                    AddSearchResult("moun");
                    AddSearchResult("mountains");
                    AddSearchResult("mountain biking");
                    AddSearchResult("mount royal university");
                }
                else if ((text.Length >= 5) && (text.Length < 8))
                {
                    searchResults.Children.Clear();

                    searchResultsPopup.IsOpen = true;

                    AddSearchResult(text + e.Key.ToString().ToLower());
                    AddSearchResult("mountains");
                    AddSearchResult("mountain biking");
                }
                else if (text.Length >= 8)
                {
                    searchResults.Children.Clear();

                    searchResultsPopup.IsOpen = true;

                    AddSearchResult(text + e.Key.ToString().ToLower());
                    AddSearchResult("mountain biking");
                }
            }
        }

        private void AddSearchResult(string content)
        {
            Button result = new Button();
            result.Style = Resources["searchResultStyle"] as Style;
            result.Click += SearchResultClick;
            result.Content = content;
            searchResults.Children.Add(result);
        }

        private void SearchResultClick(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new SearchResultsPage(this);
            searchResultsPopup.IsOpen = false;
            HighlightTab();
        }
    }
}
