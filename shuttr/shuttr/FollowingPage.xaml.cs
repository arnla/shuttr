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
            if (followingFlag == true)
            {
                // Create a photo and discussion.
                photo = new Photo(999, "Images/miami.jpg");
                photo.username = "Lawrence";
                photo.title = "From my trip in miami";
                photo.score = 5;
                photo.commentCount = 1;
                photo.comments.Add(new Comment("Emilio", "I see that hotel in so many miami nightlife pictures. Has some cool lighting"));

                discussion = new Discussion(999, "Lawrence", "Is there even a point to stand alone cameras?", "Google keeps mentioning how amazing the Pixel 2 camera is with its machine learning stuffs, and in general phone cameras are super convenient. Is there even a point to them anymore?", 3);
                discussion.score = -1;
                Comment commentWithReply = new Comment("Angela", "I'll be honest, all I need at this point is a phone camera.");
                commentWithReply.repliesFeed.Children.Add(new Comment("Lawrence", "This is exactly what I mean, why should I pay $2000 for a stand alone camer?"));
                discussion.GetComments().Add(new Comment("Anonymoose", "For any regular user, sure. But think about the professionals who need the features of a DSLR. Manual focus alone is a big deal, let alone the massive boost in quality. They let you be more creative, as opposed to shooting a picture the same way every time."));

                // Add to the children of feed.
                followingFeed.Children.Add(photo);
                followingFeed.Children.Add(discussion);
            }
            else
            {
                // Clear children of the feed.
                followingFeed.Children.Clear();
            }
        }

        private void AddDiscussionPostsTest()
        {
            followingFeed.Children.Add(new Discussion(1, "Anonymoose", "A nice title", "A nice description", 500));
            followingFeed.Children.Add(new Discussion(1, "Admin", "Not a nice title", "A nice description", 1));
        }
    }
}
