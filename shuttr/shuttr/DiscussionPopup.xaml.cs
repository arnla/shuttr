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
        public Discussion discussion;
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
            main.ChangeFill(Visibility.Visible);

            this.parent = parent;
            this.discussion = sender;

            Username.Text = sender.GetUser();
            DiscussionTitle.Text = sender.GetTitle();
            NumRepliesButton.Content = sender.GetNumReplies();
            DisplayComments();
            MessageOrDeleteButton();
            SaveOrUnsaveButton();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        public DiscussionPopup(MainWindow main, Discussion sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill(Visibility.Visible);

            this.discussion = sender;

            Username.Text = sender.GetUser();
            DiscussionTitle.Text = sender.GetTitle();
            NumRepliesButton.Content = sender.GetNumReplies();
            DisplayComments();
            MessageOrDeleteButton();
            SaveOrUnsaveButton();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        private void SaveOrUnsaveButton()
        {
            if (discussion.saved)
            {
                saveButton.Content = "Unsave";
            }
            else if (!discussion.saved)
            {
                saveButton.Content = "Save";
            }
        }

        private void MessageOrDeleteButton()
        {
            if (discussion.currUser == true)
            {
                MessageUserButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageUserButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Collapsed;
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
            commentsFeed.Children.Clear();
            foreach (Comment c in discussion.GetComments())
            {
                Comment copy = new Comment(c);
                copy.parent = this;
                commentsFeed.Children.Add(copy);
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(CloseDiscussionButton))
            {
                main.ChangeFill(Visibility.Hidden);
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
                        newComment.CurrentUser = true;
                        commentsFeed.Children.Add(newComment);
                        ScrollViewComments.ScrollToEnd();
                        discussion.GetComments().Add(newComment);
                        CommentBox.Text = "";
                        CommentBoxDefault.Text = "Type a message...";
                        //parent.GetDiscussionDict()[discussion.GetDiscussionId()] = discussion;
                    }
                    else if (replyFlag == 1)
                    {
                        //string[] reply = CommentBox.Text.Split('\n');
                        Comment newComment = new Comment("current user", CommentBox.Text, this);
                        newComment.CurrentUser = true;
                        commentToReplyTo.repliesFeed.Children.Add(newComment);
                        CommentBox.Text = "";
                        CommentBoxDefault.Text = "Type a message...";
                        replyFlag = 0;
                        commentToReplyTo = null;
                    }
                }
                else if (sender.Equals(DeleteButton))
                {
                    DeletePrompt prompt = new DeletePrompt(main, this);
                    prompt.SetMessage("This action cannot be undone, are you sure you want to proceed?");
                    prompt.ShowDialog();
                    main.HighlightTab();
                    if (prompt.confirmed == true)
                    {
                        // remove from discussions page
                        main.currDiscussionPage.discussionDict.Remove(discussion.discussionId);
                        main.currDiscussionPage.DisplayDiscussionPosts();
                        // remove from user's profile page
                        main.currUser.userDiscussions.Remove(discussion.discussionId);
                        main.currProfilePage.DisplayPosts();
                        // close popup window
                        this.Visibility = Visibility.Hidden;
                        main.ChangeFill(Visibility.Hidden);
                    }
                }
                else if (sender.Equals(saveButton))
                {
                    if (!discussion.saved)
                    {
                        // Create a new instance with the same attributes
                        Discussion copyOfDiscussion = new Discussion(discussion.discussionId, discussion.user, discussion.title, discussion.description, discussion.numReplies);
                        copyOfDiscussion.score = discussion.score;
                        copyOfDiscussion.main = discussion.main;
                        copyOfDiscussion.comments = discussion.comments;

                        // Set the saved flag of the new Discussion to true
                        copyOfDiscussion.Saved = true;
                        //  Pass it to SavedPage.AddPost()
                        main.currSavedPage.AddPost(copyOfDiscussion);

                        // Set the Saved button content of this discussion to Unsave
                        // Set the saved flag of this dicussion to true
                        discussion.saved = true;
                        discussion.saveDiscussion.Content = "Unsave";
                        saveButton.Content = "Unsave";
                    }
                    else if (discussion.saved)
                    {
                        discussion.saved = false;

                        main.currSavedPage.RemovePost(discussion);
                        main.currDiscussionPage.SetDiscussionUnsaved(discussion);
                        discussion.saveDiscussion.Content = "Save";
                        saveButton.Content = "Save";
                    }
                }
            }
            else if (!main.signedIn)
            {
                NoBlurPrompt prompt = new NoBlurPrompt(main, this);
                prompt.SetMessage("You must sign in to discuss with users.");
                prompt.ShowDialog();
                main.HighlightTab();
            }
        }
    }
}
