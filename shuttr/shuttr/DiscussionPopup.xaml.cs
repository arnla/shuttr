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
        ProfilePage alternativeParent;
        Discussion discussion;
        int replyFlag = 0; // 1 = reply to comment, 0 = reply to thread
        Comment commentToReplyTo = null;

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


        public void SetReplyFlag(int flag)
        {
            replyFlag = flag;
        }

        public void SetCommentToReplyTo(Comment comment)
        {
            commentToReplyTo = comment;
        }

        public DiscussionPopup(MainWindow main, Discussion sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill();

            this.discussion = sender;

            Username.Text = sender.GetUser();
            DiscussionTitle.Text = sender.GetTitle();
            NumRepliesButton.Content = sender.GetNumReplies();
            DisplayComments();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        /// <summary>
        /// DO NOT USE.
        /// For now, it will break when adding a comment because the click on the 
        /// reply button will try to access the DiscussionPage parent, which would be null.
        /// 
        /// Creates a discussion popup for a discussion selected from a ProfilePage
        /// </summary>
        /// <param name="main"> The MainWindow of the program </param>
        /// <param name="alternativeParent"> The ProfilePage the popup belongs to </param>
        /// <param name="sender"> The discussion object that was clicked </param>
        public DiscussionPopup(MainWindow main, ProfilePage alternativeParent, Discussion sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill();

            this.alternativeParent = alternativeParent;
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

                if (replyFlag == 0)
                {
                    Comment newComment = new Comment("current user", CommentBox.Text, this);
                    commentsFeed.Children.Add(newComment);
                    ScrollViewComments.ScrollToEnd();
                    discussion.GetComments().Add(newComment);
                    //parent.GetDiscussionDict()[discussion.GetDiscussionId()] = discussion;
                }
                else if (replyFlag == 1)
                {
                    commentToReplyTo.repliesFeed.Children.Add(new Comment("current user", CommentBox.Text));
                    CommentBox.Text = "Type a message...";
                    replyFlag = 0;
                    commentToReplyTo = null;
                }

                /**Comment newComment = new Comment("current user", CommentBox.Text);
                commentsFeed.Children.Add(newComment);
                discussion.GetComments().Add(newComment);**/
                // This line is not necessary. You are changing the discussion object, not creating a new discussion object.
                // It will be updated as normal without reassinging it.
                //parent.GetDiscussionDict()[discussion.GetDiscussionId()] = discussion;

            }
        }
    }
}
