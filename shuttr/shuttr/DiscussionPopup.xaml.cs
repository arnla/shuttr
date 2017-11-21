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
    /// Interaction logic for DiscussionPopup.xaml
    /// </summary>
    public partial class DiscussionPopup : UserControl
    {
        MainWindow main;
        DiscussionPage parent;
        Discussion discussion;

        public DiscussionPopup()
        {
            InitializeComponent();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        public DiscussionPopup(MainWindow main, DiscussionPage parent, Discussion sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill();

            this.parent = parent;
            this.discussion = sender;

            Username.Text = sender.GetUser();
            DiscussionTitle.Text = sender.GetTitle();
            NumRepliesButton.Content = sender.GetNumReplies();
            DisplayComments();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        private void DisplayComments()
        {
            foreach (Comment c in discussion.GetComments())
            {
                commentsFeed.Children.Add(c);
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(CloseDiscussionButton))
            {
                main.ChangeFill();
                this.Visibility = Visibility.Hidden;
                commentsFeed.Children.Clear();
            }
            else if (sender.Equals(PostCommentButton))
            {
                Comment newComment = new Comment("current user", CommentBox.Text);
                commentsFeed.Children.Add(newComment);
                discussion.GetComments().Add(newComment);
                parent.GetDiscussionDict()[discussion.GetDiscussionId()] = discussion;
            }
        }
    }
}
