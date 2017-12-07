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
    /// Interaction logic for FollowingPage.xaml
    /// </summary>
    public partial class FollowingPage : UserControl
    {
        private Photo photo;
        private Discussion discussion;
        private MainWindow parent;

        public FollowingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new following page that is either empty or has some posts of the people the user is following.
        /// Hard-coded.
        /// </summary>
        /// <param name="main"> The MainWindow the following page is created in. </param>
        /// <param name="followingFlag"> If set to false, no posts appear. If true, will show 2 hardcoded posts. </param>
        public FollowingPage(MainWindow main, bool followingFlag)
        {
            InitializeComponent();

            parent = main;

            if (followingFlag == true)
            {
                // Create a photo and discussion.
                photo = new Photo(103, "Images/miami.jpg");
                photo.username = "Lawrence";
                photo.title = "From my trip in miami";
                photo.score = 5;
                photo.commentCount = 1;
                photo.comments.Add(new Comment("Emilio", "I see that hotel in so many miami nightlife pictures. Has some cool lighting"));
                photo.displaySideInfo();
                photo.main = this.parent;
                photo.IsPrivate = false;
                photo.MouseLeftButtonDown += ClickPost;

                discussion = new Discussion(100, "Lawrence", "Is there even a point to stand alone cameras?", "Google keeps mentioning how amazing the Pixel 2 camera is with its machine learning stuffs, and in general phone cameras are super convenient. Is there even a point to them anymore?", 3);
                discussion.score = -1;
                Comment commentWithReply = new Comment("Angela", "I'll be honest, all I need at this point is my Google Pixel.");
                commentWithReply.repliesFeed.Children.Add(new Comment("Lawrence", "This is exactly what I mean, why should I pay $2000 for a stand alone camer?"));
                discussion.GetComments().Add(commentWithReply);
                discussion.GetComments().Add(new Comment("Anonymoose", "Point and shoots barely have a purpose now, but DSLRs and professional gear are still relevant. For any regular user, a phone is fine. But think about the professionals who need the features of a DSLR. Manual focus and switching lenses is a big deal, let alone the massive boost in quality. They let you be more creative, as opposed to shooting a picture the same way every time."));
                discussion.main = this.parent;
                discussion.numReplies = 3;
                discussion.MouseLeftButtonDown += ClickPost;

                // Add to the children of feed.
                followingFeed.Children.Add(photo);
                followingFeed.Children.Add(discussion);
            }
            else
            {
                // Clear children of the feed.
                followingFeed.Children.Clear();

                AddEmptyMessage();
            }
        }

        private void AddEmptyMessage()
        {
            Border border = new Border();
            border.BorderBrush = Brushes.Gray;
            border.BorderThickness = new Thickness(2);
            border.Opacity = 50;
            border.Width = 780;
            border.Margin = new Thickness(10);
            TextBlock text = new TextBlock();
            text.Text = "This is your home page when you log in.\nFollow some users, and their posts will appear on this page!";
            text.FontFamily = new FontFamily("Microsoft YaHei");
            text.FontSize = 26;
            text.TextAlignment = TextAlignment.Center;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextWrapping = TextWrapping.Wrap;

            border.Child = text;

            followingFeed.Children.Add(border);
        }

        private void ClickPost(object sender, MouseEventArgs e)
        {
            if (sender.Equals(discussion))
            {
                DiscussionPopup discussionPopup = new DiscussionPopup(parent, discussion);
                discussionPopup.SetValue(Grid.RowProperty, 2);
                discussionPopup.SetValue(Grid.ColumnSpanProperty, 3);
                parent.mainGrid.Children.Add(discussionPopup);
            }
            else
            {
                PhotoPopup photoPopup = new PhotoPopup(parent, photo);
                photoPopup.SetValue(Grid.RowProperty, 2);
                photoPopup.SetValue(Grid.ColumnSpanProperty, 3);
                parent.mainGrid.Children.Add(photoPopup);
            }
        }

        private void AddDiscussionPostsTest()
        {
            followingFeed.Children.Add(new Discussion(1, "Anonymoose", "A nice title", "A nice description", 500));
            followingFeed.Children.Add(new Discussion(1, "Admin", "Not a nice title", "A nice description", 1));
        }
    }
}
