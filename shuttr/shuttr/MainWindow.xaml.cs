﻿using System;
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
        public FollowingPage currFollowingPage { get; set; }
        public MessagesPage currMessagesPage { get; } = new MessagesPage();
        public SavedPage currSavedPage { get; }
        public bool followingSomeone = false;
        public bool signedIn = false;

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

            currFollowingPage = new FollowingPage(this, followingSomeone);
            currSavedPage = new SavedPage(this);

            SignOut();
        }

        public void SignOut()
        {
            signedIn = false;
            // DONE: Make logo go to photos page.
            // DONE: Collapse following and saved page.
            followingTab.Visibility = Visibility.Collapsed;
            savedTab.Visibility = Visibility.Collapsed;
            // DONE: Collapse message icon.
            messageButton.Visibility = Visibility.Collapsed;
            // DONE: Collapse notifications icon.
            notificationsButton.Visibility = Visibility.Collapsed;
            // DONE: Collapse your profile button.
            profileButton.Visibility = Visibility.Collapsed;
            // DONE: Collapse user settings button.
            userSettingButton.Visibility = Visibility.Collapsed;
            // DONE: logoutButton => loginButton
            logoutButton.Content = "Login";
            // DONE: Navigate to the photos page.
            contentControl.Content = currPhotosPage;
            // When pressing post photo or post discussion, ask to sign in.

            // FOR ALL THINGS ASKING TO LOGIN, USE A PROMPT LIKE LAWRENCE's

            // In other classes.
            // In PhotoPopup, any interaction requires login.
            // In DiscussionPopup, any interaction requires login.
            // In Photo, liking or saving requires login.
            // In Discussion, saving requires login.
        }

        public void SignIn()
        {
            signedIn = true;
            // DONE: Make logo go to following page.
            // DONE: Make visible the following and saved page.
            followingTab.Visibility = Visibility.Visible;
            savedTab.Visibility = Visibility.Visible;
            // Post photo and post discussion work.
            // DONE: Show message icon.
            messageButton.Visibility = Visibility.Visible;
            // DONE: Show notification icon.
            notificationsButton.Visibility = Visibility.Visible;
            // DONE: Show your profile button.
            profileButton.Visibility = Visibility.Visible;
            // DONE: Show user settings button.
            userSettingButton.Visibility = Visibility.Visible;
            // DONE: logoutButton => logoutButton
            logoutButton.Content = "Logout";
            // DONE: Navigate user to FollowingPage:
            currFollowingPage = new FollowingPage(this, followingSomeone);
            contentControl.Content = currFollowingPage;
            HighlightTab();

            // In other classes.
            // In PhotoPopup, interaction normal.
            // In DiscussionPopup, interaction normal.
            // In Photo, interaction normal.
            // In Discussion, interaction normal.
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
                if (signedIn)
                {
                    currFollowingPage = new FollowingPage(this, followingSomeone);
                    contentControl.Content = currFollowingPage;
                    HighlightTab();
                }
                else
                {
                    contentControl.Content = currPhotosPage;
                    HighlightTab();
                }
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
                ProfilePage newProfilePage = new ProfilePage();
                newProfilePage.SetParent(this);
                contentControl.Content = newProfilePage;

                HighlightTab();
            }
            else if (sender.Equals(userSettingButton))
            {
                contentControl.Content = new UserSettings();
                HighlightTab();
            }
            else if (sender.Equals(logoutButton))
            {
                contentControl.Content = new LoginPage(this);
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
