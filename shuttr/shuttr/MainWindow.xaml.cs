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
using System.Timers;

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
        public MessagesPage currMessagesPage { get; }
        public User currUser { get; set; } = new User("Emilio", "password", DateTime.Today);
        public SavedPage currSavedPage { get; }
        public ProfilePage currProfilePage { get; set; }
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
            currPhotosPage.SortByPopular();

            currFollowingPage = new FollowingPage(this, followingSomeone);
            currSavedPage = new SavedPage(this);

            currMessagesPage = new MessagesPage(this);

            SignOut();
        }

        public void SignOut()
        {
            signedIn = false;
            foreach (KeyValuePair<int, Photo> pair in currPhotosPage.photoDict.AsEnumerable().Reverse())
            {
                if (pair.Value.currentUser == true)
                {
                    pair.Value.currentUser = false;
                }
            }
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
            currPhotosPage.SortByPopular();
            HighlightTab();
            // DONE: When pressing post photo or post discussion, ask to sign in.

            // FOR ALL THINGS ASKING TO LOGIN, USE A PROMPT LIKE LAWRENCE's

            // In other classes.
            // DONE: In PhotoPopup, any interaction requires login.
            // DONE: In DiscussionPopup, any interaction requires login.
            // DONE: In Photo, liking or saving requires login.
            // DONE: In Discussion, saving requires login.
        }

        public void SignIn()
        {
            signedIn = true;
            currProfilePage = new ProfilePage(this, currUser);
            currProfilePage.SetParent(this);
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
            // DONE: In PhotoPopup, interaction normal.
            // DONE: In DiscussionPopup, interaction normal.
            // DONE: In Photo, interaction normal.
            // DONE: In Discussion, interaction normal.
        }

        /// <summary>
        /// Fills the notification submenu with a hardcoded set of notifications.
        /// Creates new Notification items and adds them to the submenu.
        /// </summary>
        private void FillNotificationMenu()
        {
            Notification unreadNotification = new Notification(false, "Lawrence upvoted your photo", "17h", this);
            Notification readNotification = new Notification(true, "Lean upvoted your photo", "3d", this);

            notificationStackPanel.Children.Add(unreadNotification);
            notificationStackPanel.Children.Add(readNotification);
        }
        public void NotificationClick(object sender, RoutedEventArgs e)
        {
            Button tmp = (Button)sender;
            Notification temp = (Notification)tmp.Parent;
            if (temp.notificationContent.Text.ToString().Contains("Lawrence"))
            {
                temp.Read();
            }
            notificationsButtonDropdown.IsOpen = false;
            Photo randomPhoto = new Photo(357, "/Images/trackfield.jpg");
            randomPhoto.title = "On your marks...";
            randomPhoto.caption = "I tried a bit of black and white.";
            randomPhoto.username = "Angela";
            randomPhoto.score = 2;
            randomPhoto.displaySideInfo();
            PhotoPopup popup = new PhotoPopup(this, randomPhoto);
            popup.SetValue(Grid.RowProperty, 2);
            popup.SetValue(Grid.ColumnSpanProperty, 3);
            mainGrid.Children.Add(popup);
        }

        /// <summary>
        /// Fills the messages submenud with a hardcoded set of messages.
        /// Creates new MessageNotification items and adds them to the submenu.
        /// </summary>
        private void FillMessageNotificationMenu()
        {
            MessageNotification newMessage = new MessageNotification(false, "User 2", "What lens do you use for your night sky photography?", "3:01 PM");
            messagesStackPanel.Children.Add(newMessage);

            newMessage.containerButton.Click += MessageNotificationClick;
            message1.containerButton.Click += MessageNotificationClick;
        }
        public void MessageNotificationClick(object sender, RoutedEventArgs e)
        {
            MessageDevelopmentPrompt prompt = new MessageDevelopmentPrompt(this);
            ChangeFill(Visibility.Visible);
            prompt.ShowDialog();
        }
        public void OnCloseMessagePrompt()
        {
            ChangeFill(Visibility.Hidden);
        }
        public void HelpClick(object sender, RoutedEventArgs e)
        {
            HelpPromptPopup prompt = new HelpPromptPopup(this);
            ChangeFill(Visibility.Visible);
            prompt.ShowDialog();
        }
        public void OnCloseHelpPrompt()
        {
            ChangeFill(Visibility.Hidden);
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
                currPhotosPage.SortByPopular();
                HighlightTab();
            }
            else if (sender.Equals(discussionsTab))
            {
                contentControl.Content = currDiscussionPage;
                currDiscussionPage.SortByMostCommented();
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
                accountButtonDropdown.IsOpen = false;
                currProfilePage = new ProfilePage(this, currUser);
                contentControl.Content = currProfilePage;
                HighlightTab();
            }
            else if (sender.Equals(userSettingButton))
            {
                accountButtonDropdown.IsOpen = false;
                contentControl.Content = new UserSettings(this, currUser);
                HighlightTab();
            }
            else if (sender.Equals(logoutButton))
            {
                //LogoutPromptPopup popup = new LogoutPromptPopup(this);
                //popup.ShowDialog();
                //contentControl.Content = new LoginPage();
                //HighlightTab();
                if (!signedIn)
                {
                    accountButtonDropdown.IsOpen = false;
                    contentControl.Content = new LoginPage(this);
                    HighlightTab();
                }
                else if (signedIn)
                {
                    accountButtonDropdown.IsOpen = false;
                    LogoutPromptPopup popup = new LogoutPromptPopup(this);
                    popup.ShowDialog();
                }
            }
            else if (sender.Equals(seeAllMessagesButton))
            {
                contentControl.Content = currMessagesPage;
                messagesButtonDropdown.IsOpen = false;
                HighlightTab();
            }
            else if (sender.Equals(postPhotoButton))
            {
                if (signedIn)
                {
                    postButtonDropdown.IsOpen = false;
                    PostPhotoPopup photoPopup = new PostPhotoPopup(this);
                    photoPopup.SetValue(Grid.RowProperty, 2);
                    photoPopup.SetValue(Grid.ColumnSpanProperty, 3);
                    mainGrid.Children.Add(photoPopup);
                }
                else if (!signedIn)
                {
                    LoginPrompt prompt = new LoginPrompt(this);
                    prompt.SetMessage("You must sign in to create posts.");
                    prompt.ShowDialog();
                    HighlightTab();
                }
            }
            else if (sender.Equals(postDiscussionButton))
            {
                if (signedIn)
                {
                    postButtonDropdown.IsOpen = false;
                    PostDiscussionPopup discussionPopup = new PostDiscussionPopup(this);
                    discussionPopup.SetValue(Grid.RowProperty, 2);
                    discussionPopup.SetValue(Grid.ColumnSpanProperty, 3);
                    mainGrid.Children.Add(discussionPopup);
                }
                else if (!signedIn)
                {
                    LoginPrompt prompt = new LoginPrompt(this);
                    prompt.SetMessage("You must sign in to create posts.");
                    prompt.ShowDialog();
                    HighlightTab();
                }
            }
        }

        public void AddPhoto(Photo pic, string title, string description)
        {
            pic.title = title;
            pic.caption = description;
            // Assumes demo only yields one signed in user, i.e. all newly posted photos are under the one and only user
            pic.currentUser = true;
            pic.username = pic.sideUserName.Text = currUser.UserName;
            currPhotosPage.AddPhoto(pic);
            currUser.userPhotos[pic.photoId] = pic;
            currProfilePage.DisplayPosts();

            ShowPostCreated();
        }

        public void AddDiscussion(Discussion discussion)
        {
            discussion.currUser = true;
            currDiscussionPage.AddDiscussionPost(discussion);
            currUser.userDiscussions[discussion.discussionId] = discussion;
            currProfilePage.DisplayPosts();

            ShowPostCreated();
        }

        /// <summary>
        /// Shows a message on the top right letting the user know that their post was created.
        /// </summary>
        public void ShowPostCreated()
        {
            // Make the message of a post created visible.
            postAcceptedBorder.Visibility = Visibility.Visible;

            // Start a timer that will make the message invisible after a set time (5 seconds, 5000 ms).
            Timer countDownToHidePostCreateMessage = new Timer(5000);
            countDownToHidePostCreateMessage.Elapsed += HidePostCreated;
            countDownToHidePostCreateMessage.Enabled = true;
        }
        /// <summary>
        /// Hides the message created previously. Cancels the timer that called it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HidePostCreated(object sender, ElapsedEventArgs e)
        {
            // Hide the post created message.
            this.Dispatcher.Invoke(() =>
            {
                postAcceptedBorder.Visibility = Visibility.Hidden;
            });

            if (sender.GetType() == typeof(Timer))
            {
                Timer timer = (Timer)sender;
                timer.Stop();
            }
        }

        public void ChangeFill(Visibility visibility)
        {
            popUpPageFill.Visibility = visibility;
            /*
            if ((popUpPageFill.Visibility == Visibility.Hidden) || (popUpPageFill.Visibility == Visibility.Collapsed))
                popUpPageFill.Visibility = Visibility.Visible;
            else
                popUpPageFill.Visibility = Visibility.Hidden;*/
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
                string mountains = "mountains";
                string Mountains = "Mountains";
                if (mountains.StartsWith(searchBox.Text.ToString()) || Mountains.StartsWith(searchBox.Text.ToString()))
                {
                    contentControl.Content = new SearchResultsPage(this);
                }
                else
                {
                    contentControl.Content = new SearchResultsPageEmpty(this, searchBox.Text.ToString());
                }

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

                    AddSearchResult(text + e.Key.ToString().ToLower());
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

                    AddSearchResult(text + e.Key.ToString().ToLower());
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

                    AddSearchResult(text + e.Key.ToString().ToLower());
                    AddSearchResult("mouse");
                    AddSearchResult("mickey mouse");
                    AddSearchResult("mountains");
                    AddSearchResult("mountain biking");
                }
                else if (text.Length == 3)
                {
                    searchResults.Children.Clear();

                    searchResultsPopup.IsOpen = true;

                    AddSearchResult(text + e.Key.ToString().ToLower());
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
