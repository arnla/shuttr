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
    /// Interaction logic for PhotoPopup.xaml
    /// </summary>
    public partial class PhotoPopup : UserControl
    {
        private MainWindow main;
        private PhotosPage parent;
        private Photo photo;
        int replyFlag = 0; // 1 = reply to comment, 0 = reply to thread
        Comment commentToReplyTo = null;

        public PhotoPopup()
        {
            InitializeComponent();

            window.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.85;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.7;
        }

        public PhotoPopup(MainWindow main, PhotosPage parent, Photo sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill();

            this.parent = parent;
            this.photo = sender;

            // Need to create a new photo, otherwise it will throw an exception because one object can't be the child of 2 elements
            commentFeed.Children.Add(new Photo(sender.photoId, sender.imageName.Source));

            Username.Text = sender.username;
            title.Text = sender.title;
            description.Text = sender.caption;
            NumRepliesButton.Content = sender.commentCount;

            DisplayComments();

            window.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.85;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.7;
        }

        public void SetReplyFlag(int flag)
        {
            replyFlag = flag;
        }

        public void SetCommentToReplyTo(Comment comment)
        {
            commentToReplyTo = comment;
        }

        public PhotoPopup(MainWindow main, Photo sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill();

            this.photo = sender;

            // Need to create a new photo, otherwise it will throw an exception because one object can't be the child of 2 elements
            commentFeed.Children.Add(new Photo(sender.photoId, sender.imageName.Source));

            Username.Text = sender.username;
            title.Text = sender.title;
            description.Text = sender.caption;
            NumRepliesButton.Content = sender.comments.Count();

            DisplayComments();

            window.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.85;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.7;
        }

        private void DisplayComments()
        {
            foreach (Comment c in photo.comments)
            {
                if (c.parent == null)
                {
                    c.parent = this;
                }
                commentFeed.Children.Add(c);
            }
        }

        private void Close(object sender, EventArgs e)
        {
            main.ChangeFill();
            this.Visibility = Visibility.Hidden;
            commentFeed.Children.Clear();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender.Equals(postCommentButton))
            {
                if (replyFlag == 0)
                {
                    string richText = new TextRange(commentBox.Document.ContentStart, commentBox.Document.ContentEnd).Text;

                    Comment newComment = new Comment("current user", richText, this);
                    commentFeed.Children.Add(newComment);
                    photoAndComments.ScrollToEnd();
                    photo.comments.Add(newComment);
                    // Unnecessary line. Same as DiscussionPopup.
                    //parent.photoDict[photo.photoId] = photo;
                }
                else if (replyFlag == 1)
                {
                    string richText = new TextRange(commentBox.Document.ContentStart, commentBox.Document.ContentEnd).Text;

                    commentToReplyTo.repliesFeed.Children.Add(new Comment("current user", richText, this));
                    commentBox.Document.Blocks.Clear();
                    commentBox.Document.Blocks.Add(new Paragraph(new Run("Type a message...")));
                    replyFlag = 0;
                    commentToReplyTo = null;
                }
            }
        }
    }
}
