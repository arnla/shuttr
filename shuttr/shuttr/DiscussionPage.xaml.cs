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
        private int discussionIdCtr = 0;
        private Dictionary<int, Discussion> discussionDict = new Dictionary<int, Discussion>();

        public DiscussionPage()
        {
            InitializeComponent();
            HardcodedInitialDiscussion();
            DisplayDiscussionPosts();
        }

        public Dictionary<int, Discussion> GetDiscussionDict()
        {
            return discussionDict;
        }

        public int GetDiscussionIdCtr()
        {
            return discussionIdCtr;
        }

        public void SetDisucssionIdCtr()
        {
            discussionIdCtr++;
        }

        public void HardcodedInitialDiscussion()
        {
            discussionDict.Add(100, new Discussion(discussionIdCtr, "User2", "Looking to shoot film, what do I need to know?", "description", 24));
            discussionDict.Add(101, new Discussion(discussionIdCtr, "User3", "You all take beautiful photographs. Can I do the same with just an iPhone?", "description", 23));
            discussionDict.Add(102, new Discussion(discussionIdCtr, "User4", "Do you understand your histograms?", "description", 9));
            discussionDict.Add(103, new Discussion(discussionIdCtr, "User5", "Anyone excited for the new capture clip v3?", "description", 0));
            discussionDict.Add(104, new Discussion(discussionIdCtr, "User6", "Who else is excited for snow photography???", "description", 29));
            discussionDict.Add(105, new Discussion(discussionIdCtr, "User7", "Advice needed on having one of my pictures enlarged to 9ft tall.", "description", 42));
        }

        public void DisplayDiscussionPosts()
        {
            foreach (KeyValuePair<int, Discussion> pair in discussionDict)
            {
                var parent = VisualTreeHelper.GetParent(pair.Value);
                if (parent == null)
                    discussionFeed.Children.Add(pair.Value);
            }
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

        private void AddDiscussionPost()
        {

        }

        private void DiscussionClick(object sender, MouseButtonEventArgs e)
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
            
        }

        private void DiscussionClickTest(object sender, MouseButtonEventArgs e)
        {
            DiscussionPage popUp = new DiscussionPage();
            popUp.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
            popUp.popUpPageFill.Visibility = Visibility.Visible;
            discussionContentControl.Content = popUp;
            popUp.discussionPopUpWindow.IsOpen = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
