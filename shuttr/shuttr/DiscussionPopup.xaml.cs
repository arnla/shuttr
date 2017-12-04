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
            MessageOrDeleteButton();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
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
            MessageOrDeleteButton();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        private void MessageOrDeleteButton()
        {
            if (discussion.currUser == true)
            {
                MessageUserButton.Content = "DELETE";
                MessageUserButton.Background = Brushes.Red;
            }
        }
        
        public void SetReplyFlag(int flag)
        {
            replyFlag = flag;
        }

        public void SetCommentToReplyTo(Comment comment)
        {
            commentToReplyTo = comment;
        }

        private void DisplayComments()
        {
            foreach (Comment c in discussion.GetComments())
            {
                c.parent = this;
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
        }

        protected void ButtonClick(object sender, EventArgs e)
        {
            if (main.signedIn)
            {
                if (sender.Equals(PostCommentButton))
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
                        string[] reply = CommentBox.Text.Split('\n');
                        commentToReplyTo.repliesFeed.Children.Add(new Comment("current user", reply[1], this));
                        CommentBox.Text = "Type a message...";
                        replyFlag = 0;
                        commentToReplyTo = null;
                    }
                }
                else if (sender.Equals(MessageUserButton))
                {
                    // remove from discussions page
                    main.currDiscussionPage.discussionDict.Remove(discussion.discussionId);
                    main.currDiscussionPage.DisplayDiscussionPosts();
                    // remove from user's profile page
                    main.currUser.userDiscussions.Remove(discussion.discussionId);
                    main.currProfilePage.DisplayPosts();
                    // close popup window
                    this.Visibility = Visibility.Hidden;
                    main.ChangeFill();
                }
            }
            else if (!main.signedIn)
            {
                LoginPrompt prompt = new LoginPrompt(main);
                prompt.SetMessage("You must sign in to discuss with users.");
                prompt.ShowDialog();
                main.HighlightTab();
            }
        }
    }
}
