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
        public DiscussionPage()
        {
            InitializeComponent();

            AddDiscussionPostsTest();
        }

        private void AddDiscussionPostsTest()
        {
            Discussion clickableDiscussion= new Discussion("User1", "Let's see your best nightlife photos!", 3);
            clickableDiscussion.MouseLeftButtonDown += new MouseButtonEventHandler(this.DiscussionClickTest);
            clickableDiscussion.Name = "discussion1";

            discussionFeed.Children.Add(clickableDiscussion);

            discussionFeed.Children.Add(new Discussion("User2", "Looking to shoot film, what do I need to know?", 24));
            discussionFeed.Children.Add(new Discussion("User3", "You all take beautiful photographs. Can I do the same with just an iPhone?", 23));
            discussionFeed.Children.Add(new Discussion("User4", "Do you understand your histograms?", 9));
            discussionFeed.Children.Add(new Discussion("User5", "Anyone excited for the new capture clip v3?", 0));
            discussionFeed.Children.Add(new Discussion("User6", "Who else is excited for snow photography???", 29));
            discussionFeed.Children.Add(new Discussion("User7", "Advice needed on having one of my pictures enlarged to 9ft tall.", 42));
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
