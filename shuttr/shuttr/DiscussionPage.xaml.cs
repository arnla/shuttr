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
    /// Interaction logic for DiscussionPage.xaml
    /// </summary>
    public partial class DiscussionPage : UserControl
    {
        private MainWindow parent;
        private int discussionIdCtr = 0;
        public Dictionary<int, Discussion> discussionDict { get; set; } = new Dictionary<int, Discussion>();

        public DiscussionPage()
        {
            InitializeComponent();
            HardcodedInitialDiscussion();
            DisplayDiscussionPosts();
        }

        private void SetParentOfEachDiscussion()
        {
            foreach (KeyValuePair<int, Discussion> pair in discussionDict)
            {
                pair.Value.main = parent;
            }
        }

        public void SetParent(MainWindow parent)
        {
            this.parent = parent;
            SetParentOfEachDiscussion();
        }

        public Dictionary<int, Discussion> GetDiscussionDict()
        {
            return discussionDict;
        }

        public int GetDiscussionIdCtr()
        {
            return discussionIdCtr;
        }

        public void HardcodedInitialDiscussion()
        {

            Discussion discussion = new Discussion(100, "Lawrence", "Is there even a point to stand alone cameras?", "Google keeps mentioning how amazing the Pixel 2 camera is with its machine learning stuffs, and in general phone cameras are super convenient. Is there even a point to them anymore?", 3);
            Comment commentWithReply = new Comment("Angela", "I'll be honest, all I need at this point is my Google Pixel.");
            commentWithReply.repliesFeed.Children.Add(new Comment("Lawrence", "This is exactly what I mean, why should I pay $2000 for a stand alone camer?"));
            discussion.GetComments().Add(commentWithReply);
            discussion.GetComments().Add(new Comment("Anonymoose", "Point and shoots barely have a purpose now, but DSLRs and professional gear are still relevant. For any regular user, a phone is fine. But think about the professionals who need the features of a DSLR. Manual focus and switching lenses is a big deal, let alone the massive boost in quality. They let you be more creative, as opposed to shooting a picture the same way every time."));
            discussion.main = this.parent;
            discussion.numReplies = 3;
            discussionDict.Add(100, discussion);

            discussion = new Discussion(101, "Lean", "Pixel 2 Portrait Mode", "Isn't it crazy that these images are created through machine learning?", 2);
            discussion.GetComments().Add(new Comment("Lawrence", "It's insane that our phone camera technology can do that nowadays!"));
            discussion.GetComments().Add(new Comment("Emilio", "My moto g does the job just fine."));
            discussion.main = this.parent;
            discussionDict.Add(101, discussion);

            discussion = new Discussion(102, "Jessi", "Good places to take mountain pictures in Alberta?", "I'm visiting Alberta this summer, and was wondering what the best places to take mountain pictures are. Ideally they would be near the Banff area.", 2);
            discussion.score = 1;
            discussion.GetComments().Add(new Comment("Lawrence", "Lake Louise looks spectacular during the summer! Just go early to avoid the crowds."));
            discussion.GetComments().Add(new Comment("Anonymoose", "Basically anywhere near the rockies. Alberta is pretty amazing like that."));
            discussion.numReplies = 2;
            discussion.main = this.parent;
            discussionDict.Add(102, discussion);
            /*
            discussionDict.Add(100, new Discussion(100, "User2", "Looking to shoot film, what do I need to know?", "description", 24));
            discussionDict.Add(101, new Discussion(101, "User3", "You all take beautiful photographs. Can I do the same with just an iPhone?", "description", 23));
            discussionDict.Add(102, new Discussion(102, "User4", "Do you understand your histograms?", "description", 9));
            discussionDict.Add(103, new Discussion(103, "User5", "Anyone excited for the new capture clip v3?", "description", 0));
            discussionDict.Add(104, new Discussion(104, "User6", "Who else is excited for snow photography???", "description", 29));
            discussionDict.Add(105, new Discussion(105, "User7", "Advice needed on having one of my pictures enlarged to 9ft tall.", "description", 42));*/
        }

        private void MakeDiscussionClickable(Discussion discussion)
        {
                discussion.MouseLeftButtonDown += new MouseButtonEventHandler(this.DiscussionClickTest);
        }

        public void DisplayDiscussionPosts()
        {
            discussionFeed.Children.Clear();
            foreach (KeyValuePair<int, Discussion> pair in discussionDict.AsEnumerable().Reverse())
            {
                var parent = VisualTreeHelper.GetParent(pair.Value);
                if (parent == null)
                {
                    Discussion discussionToAdd = new Discussion(pair.Value);
                    discussionToAdd.main = this.parent;
                    discussionFeed.Children.Add(discussionToAdd);
                    MakeDiscussionClickable(discussionToAdd);
                }
            }
            SetParentOfEachDiscussion();
        }

        public void UpdateDiscussionDict(int id, Discussion newDiscussion)
        {
            discussionDict[id] = newDiscussion;
        }

        public void AddDiscussionPost(Discussion newDiscussion)
        {
            discussionDict.Add(discussionIdCtr++, newDiscussion);
            discussionIdCtr++;
            DisplayDiscussionPosts();
        }

        /**private void AddDiscussionPostsTest()
        {
            Discussion clickableDiscussion = new Discussion(discussionIdCtr, "User1", "Let's see your best nightlife photos!", "description", 3);
            clickableDiscussion.MouseLeftButtonDown += new MouseButtonEventHandler(this.DiscussionClickTest);
            clickableDiscussion.Name = "discussion1";

            discussionFeed.Children.Add(clickableDiscussion);

            discussionFeed.Children.Add(new Discussion(discussionIdCtr, "User2", "Looking to shoot film, what do I need to know?", "description", 24));
            discussionFeed.Children.Add(new Discussion(discussionIdCtr, "User3", "You all take beautiful photographs. Can I do the same with just an iPhone?", "description", 23));
            discussionFeed.Children.Add(new Discussion(discussionIdCtr, "User4", "Do you understand your histograms?", "description", 9));
            discussionFeed.Children.Add(new Discussion(discussionIdCtr, "User5", "Anyone excited for the new capture clip v3?", "description", 0));
            discussionFeed.Children.Add(new Discussion(discussionIdCtr, "User6", "Who else is excited for snow photography???", "description", 29));
            discussionFeed.Children.Add(new Discussion(discussionIdCtr, "User7", "Advice needed on having one of my pictures enlarged to 9ft tall.", "description", 42));
        }**/

        /**private void DiscussionClick(object sender, MouseButtonEventArgs e)
        {
            if (sender.GetType().Equals(typeof(Discussion)))
            {
                Discussion senderCast = (Discussion) sender;
                if (senderCast.Name == "discussion1")
                {
                    DiscussionPage popUp = new DiscussionPage();
                    popUp.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                    popUp.popUpPageFill.Visibility = Visibility.Visible;
                    discussionContentControl.Content = popUp;
                    popUp.discussionPopUpWindow.IsOpen = true;
                }
            } 
        }**/

        private void DiscussionClickTest(object sender, MouseButtonEventArgs e)
        {
            Discussion tmp = (Discussion)sender;
            DiscussionPopup discussionPopup = new DiscussionPopup(parent, this, tmp);
            discussionPopup.SetValue(Grid.RowProperty, 2);
            discussionPopup.SetValue(Grid.ColumnSpanProperty, 3);
            parent.mainGrid.Children.Add(discussionPopup);
        }

        public void SortClick(object sender, EventArgs e)
        {
            if (sender.Equals(sortByMenu) || sender.Equals(currentSortOption))
            {
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortMostCommented))
            {
                currentSortOption.Content = "Most Commented";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByMostCommented();
            }
            /*
            else if (sender.Equals(sortPopular))
            {
                currentSortOption.Content = "Popular";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByPopular();
            }
            */
            else if (sender.Equals(sortNew))
            {
                currentSortOption.Content = "New";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByNew();
            }
            /*
            else if (sender.Equals(sortMostUpvoted))
            {
                currentSortOption.Content = "Most Upvoted";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByMostUpvoted();
            }
            */
        }

        public void SortByPopular()
        {
            // Set the current sort option.
            currentSortOption.Content = "Popular";
            
            // Get the array of all the children in the page.
            Discussion[] discussionsToSort = new Discussion[discussionFeed.Children.Count];
            discussionFeed.Children.CopyTo(discussionsToSort, 0);

            // Sort the array using linear sort.
            int i = 1;
            int j;
            while (i < discussionsToSort.Length)
            {
                j = i;
                while ((j > 0) && ((discussionsToSort[j - 1].score + discussionsToSort[j - 1].GetNumReplies()) > (discussionsToSort[j].score + discussionsToSort[j].GetNumReplies())))
                {
                    Discussion temp = discussionsToSort[j];
                    discussionsToSort[j] = discussionsToSort[j - 1];
                    discussionsToSort[j - 1] = temp;
                    j--;
                }
                i++;
            }

            // Clear the children.
            discussionFeed.Children.Clear();
            // Add the sorted list of children (backwards | highest popularity at top)
            for (int k = discussionsToSort.Length - 1; k >= 0; k--)
            {
                discussionFeed.Children.Add(discussionsToSort[k]);
                discussionsToSort[k].main = parent;
            }
        }
        public void SortByNew()
        {
            DisplayDiscussionPosts();
        }
        public void SortByMostCommented()
        {
            // Get the array of all the children in the page.
            Discussion[] discussionsToSort = new Discussion[discussionFeed.Children.Count];
            discussionFeed.Children.CopyTo(discussionsToSort, 0);

            // Sort the array using linear sort.
            int i = 1;
            int j;
            while (i < discussionsToSort.Length)
            {
                j = i;
                while ((j > 0) && (discussionsToSort[j - 1].GetNumReplies() > discussionsToSort[j].GetNumReplies()))
                {
                    Discussion temp = discussionsToSort[j];
                    discussionsToSort[j] = discussionsToSort[j - 1];
                    discussionsToSort[j - 1] = temp;
                    j--;
                }
                i++;
            }

            // Clear the children.
            discussionFeed.Children.Clear();
            // Add the sorted list of children (backwards | highest popularity at top)
            for (int k = discussionsToSort.Length - 1; k >= 0; k--)
            {
                Discussion discussionToAdd = new Discussion(discussionsToSort[k]);
                discussionToAdd.main = this.parent;
                discussionFeed.Children.Add(discussionToAdd);
                MakeDiscussionClickable(discussionToAdd);
            }
        }
        public void SortByMostUpvoted()
        {
            // Get the array of all the children in the page.
            Discussion[] discussionsToSort = new Discussion[discussionFeed.Children.Count];
            discussionFeed.Children.CopyTo(discussionsToSort, 0);

            // Sort the array using linear sort.
            int i = 1;
            int j;
            while (i < discussionsToSort.Length)
            {
                j = i;
                while ((j > 0) && (discussionsToSort[j - 1].score > discussionsToSort[j].score))
                {
                    Discussion temp = discussionsToSort[j];
                    discussionsToSort[j] = discussionsToSort[j - 1];
                    discussionsToSort[j - 1] = temp;
                    j--;
                }
                i++;
            }

            // Clear the children.
            discussionFeed.Children.Clear();
            // Add the sorted list of children (backwards | highest popularity at top)
            for (int k = discussionsToSort.Length - 1; k >= 0; k--)
            {
                discussionFeed.Children.Add(discussionsToSort[k]);
                discussionsToSort[k].main = parent;
            }
        }

        public void SetDiscussionUnsaved(Discussion discussionToUnsave)
        {
            // Look through the children of the discussion page
            foreach (Discussion discussionInFeed in discussionFeed.Children)
            {
                if (discussionInFeed.GetDiscussionId() == discussionToUnsave.GetDiscussionId())
                {
                    // If the discussion is saved, remove it
                    discussionInFeed.Saved = false;
                }
            }
        }
    }
}
