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
    /// Interaction logic for ProfilePageOtherUser.xaml
    /// </summary>
    public partial class ProfilePageOtherUser : UserControl
    {
        private MainWindow main;
        private Photo photo;
        private Discussion discussion;

        public ProfilePageOtherUser(MainWindow main)
        {
            InitializeComponent();

            this.main = main;

            userName.Content = "Lawrence";

            // Determine whether this user is being followed.
            if (main.followingSomeone)
            {
                followButton.Content = "Unfollow";
            }
            else
            {
                followButton.Content = "Follow";
            }

            // Create a photo and discussion.
            photo = new Photo(103, "Images/miami.jpg");
            photo.username = "Lawrence";
            photo.title = "From my trip in miami";
            photo.score = 5;
            photo.commentCount = 1;
            photo.comments.Add(new Comment("Emilio", "I see that hotel in so many miami nightlife pictures. Has some cool lighting"));
            photo.displaySideInfo();
            photo.sidePhotoInfo.Visibility = Visibility.Collapsed;
            photo.main = this.main;
            photo.MouseLeftButtonDown += ClickPost;

            discussion = new Discussion(100, "Lawrence", "Is there even a point to stand alone cameras?", "Google keeps mentioning how amazing the Pixel 2 camera is with its machine learning stuffs, and in general phone cameras are super convenient. Is there even a point to them anymore?", 3);
            discussion.score = -1;
            Comment commentWithReply = new Comment("Angela", "I'll be honest, all I need at this point is my Google Pixel.");
            commentWithReply.repliesFeed.Children.Add(new Comment("Lawrence", "This is exactly what I mean, why should I pay $2000 for a stand alone camer?"));
            discussion.GetComments().Add(commentWithReply);
            discussion.GetComments().Add(new Comment("Anonymoose", "Point and shoots barely have a purpose now, but DSLRs and professional gear are still relevant. For any regular user, a phone is fine. But think about the professionals who need the features of a DSLR. Manual focus and switching lenses is a big deal, let alone the massive boost in quality. They let you be more creative, as opposed to shooting a picture the same way every time."));
            discussion.main = this.main;
            discussion.numReplies = 3;
            discussion.MouseLeftButtonDown += ClickPost;

            // Photo = 5 Score, 1 Comment, Discussion = -1 score, 3 comments
            userProfileFeed.Children.Add(photo);
            userProfileFeed.Children.Add(discussion);

            currentFilterOption.Content = filterAll.Content;
        }

        private void FollowClick(object sender, RoutedEventArgs e)
        {
            if (main.signedIn)
            {
                if ((followButton.Content as string) == "Follow")
                {
                    followButton.Content = "Unfollow";
                    main.followingSomeone = true;
                }
                else if ((followButton.Content as string) == "Unfollow")
                {
                    followButton.Content = "Follow";
                    main.followingSomeone = false;
                }
            }
            else
            {
                LoginPrompt prompt = new LoginPrompt(main);
                prompt.SetMessage("You must sign in to follow other users.");
                prompt.ShowDialog();
                main.HighlightTab();
            }
        }

        private void DevClick(object sender, RoutedEventArgs e)
        {
            if (main.signedIn)
            {
                if (sender.Equals(messageButton))
                {
                    MessageDevelopmentPrompt prompt = new MessageDevelopmentPrompt(this);
                    main.ChangeFill(Visibility.Visible);
                    prompt.ShowDialog();
                }
                else if (sender.Equals(blockButton))
                {
                    MessageDevelopmentPrompt prompt = new MessageDevelopmentPrompt(this);
                    prompt.SetMessage("Blocking is currently under development.");
                    main.ChangeFill(Visibility.Visible);
                    prompt.ShowDialog();
                }
            }
            else
            {
                if (sender.Equals(messageButton))
                {
                    LoginPrompt prompt = new LoginPrompt(main);
                    prompt.SetMessage("You must sign in to message other users.\n(This feature is under development)");
                    prompt.ShowDialog();
                    main.HighlightTab();
                }
                else if (sender.Equals(blockButton))
                {
                    LoginPrompt prompt = new LoginPrompt(main);
                    prompt.SetMessage("You must sign in to block users.\n(This feature is under development)");
                    prompt.ShowDialog();
                    main.HighlightTab();
                }
            }
        }

        public void OnCloseMessagePrompt()
        {
            main.ChangeFill(Visibility.Hidden);
        }

        private void ClickPost(object sender, MouseEventArgs e)
        {
            if (sender.Equals(discussion))
            {
                DiscussionPopup discussionPopup = new DiscussionPopup(main, discussion);
                discussionPopup.SetValue(Grid.RowProperty, 2);
                discussionPopup.SetValue(Grid.ColumnSpanProperty, 3);
                main.mainGrid.Children.Add(discussionPopup);
            }
            else
            {
                PhotoPopup photoPopup = new PhotoPopup(main, photo);
                photoPopup.SetValue(Grid.RowProperty, 2);
                photoPopup.SetValue(Grid.ColumnSpanProperty, 3);
                main.mainGrid.Children.Add(photoPopup);
            }
        }

        public void SortClick(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(sortByMenu) || sender.Equals(currentSortOption))
            {
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortPopular))
            {
                currentSortOption.Content = sortPopular.Content;
                sortByDropdown.IsOpen = false;

                userProfileFeed.Children.Clear();

                // If showing both photos and discussions, make sure posts are sorted
                if (currentFilterOption.Content == filterAll.Content)
                {
                    userProfileFeed.Children.Add(photo);
                    userProfileFeed.Children.Add(discussion);
                }
                else if (currentFilterOption.Content == filterPhotos.Content)
                {
                    userProfileFeed.Children.Add(photo);
                }
                else if (currentFilterOption.Content == filterDiscussions.Content)
                {
                    userProfileFeed.Children.Add(discussion);
                }
            }
            else if (sender.Equals(sortNew))
            {
                currentSortOption.Content = sortNew.Content;
                sortByDropdown.IsOpen = false;

                userProfileFeed.Children.Clear();

                // If showing both photos and discussions, make sure posts are sorted
                if (currentFilterOption.Content == filterAll.Content)
                {
                    userProfileFeed.Children.Add(photo);
                    userProfileFeed.Children.Add(discussion);
                }
                else if (currentFilterOption.Content == filterPhotos.Content)
                {
                    userProfileFeed.Children.Add(photo);
                }
                else if (currentFilterOption.Content == filterDiscussions.Content)
                {
                    userProfileFeed.Children.Add(discussion);
                }
            }
            else if (sender.Equals(sortMostCommented))
            {
                currentSortOption.Content = sortMostCommented.Content;
                sortByDropdown.IsOpen = false;

                userProfileFeed.Children.Clear();

                // If showing both photos and discussions, make sure posts are sorted
                if (currentFilterOption.Content == filterAll.Content)
                {
                    userProfileFeed.Children.Add(discussion);
                    userProfileFeed.Children.Add(photo);
                }
                else if (currentFilterOption.Content == filterPhotos.Content)
                {
                    userProfileFeed.Children.Add(photo);
                }
                else if (currentFilterOption.Content == filterDiscussions.Content)
                {
                    userProfileFeed.Children.Add(discussion);
                }
            }
            else if (sender.Equals(sortMostUpvoted))
            {
                currentSortOption.Content = sortMostUpvoted.Content;
                sortByDropdown.IsOpen = false;

                userProfileFeed.Children.Clear();

                // If showing both photos and discussions, make sure posts are sorted
                if (currentFilterOption.Content == filterAll.Content)
                {
                    userProfileFeed.Children.Add(photo);
                    userProfileFeed.Children.Add(discussion);
                }
                else if (currentFilterOption.Content == filterPhotos.Content)
                {
                    userProfileFeed.Children.Add(photo);
                }
                else if (currentFilterOption.Content == filterDiscussions.Content)
                {
                    userProfileFeed.Children.Add(discussion);
                }
            }
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(filterByMenu) || sender.Equals(currentFilterOption))
            {
                filterByDropdown.IsOpen = !filterByDropdown.IsOpen;
            }
            else if (sender.Equals(filterAll))
            {
                currentFilterOption.Content = filterAll.Content;
                filterByDropdown.IsOpen = false;

                userProfileFeed.Children.Clear();
                if (currentSortOption.Content == sortMostCommented.Content)
                {
                    userProfileFeed.Children.Add(discussion);
                    userProfileFeed.Children.Add(photo);
                }
                else
                {
                    userProfileFeed.Children.Add(photo);
                    userProfileFeed.Children.Add(discussion);
                }
            }
            else if (sender.Equals(filterPhotos))
            {
                currentFilterOption.Content = filterPhotos.Content;
                filterByDropdown.IsOpen = false;

                userProfileFeed.Children.Clear();

                userProfileFeed.Children.Add(photo);
            }
            else if (sender.Equals(filterDiscussions))
            {
                currentFilterOption.Content = filterDiscussions.Content;
                filterByDropdown.IsOpen = false;

                userProfileFeed.Children.Clear();

                userProfileFeed.Children.Add(discussion);
            }
        }
    }
}
