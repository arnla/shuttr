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
    /// Interaction logic for Comment.xaml
    /// </summary>
    public partial class Comment : UserControl
    {
        private string username;
        private string comment;
        public UserControl parent { get; set; }
        private bool currentUser = false;
        public bool CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                if (currentUser)
                {
                    deleteButton.Visibility = Visibility.Visible;
                }
                else
                {
                    deleteButton.Visibility = Visibility.Hidden;
                }
            }
        }

        public Comment()
        {
            InitializeComponent();
        }

        public Comment(string username, string comment)
        {
            InitializeComponent();
            this.username = username;
            this.comment = comment;
            usernameText.Text = username;
            commentBox.Text = comment;
            CurrentUser = false;
        }

        public Comment(string username, string comment, PhotoPopup parent)
        {
            InitializeComponent();
            this.username = username;
            this.comment = comment;
            usernameText.Text = username;
            commentBox.Text = comment;
            this.parent = parent;
            CurrentUser = false;
        }

        public Comment(string username, string comment, DiscussionPopup parent)
        {
            InitializeComponent();
            this.username = username;
            this.comment = comment;
            usernameText.Text = username;
            commentBox.Text = comment;
            this.parent = parent;
            CurrentUser = false;
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(replyButton))
                {
                    if (parent.GetType() == typeof(DiscussionPopup))
                    {
                        DiscussionPopup castedParent = (DiscussionPopup)parent;
                        castedParent.CommentBox.Text = "Replying to " + username + "'s comment: " + comment + "\n";
                        castedParent.SetReplyFlag(1);
                        castedParent.SetCommentToReplyTo(this);
                    }
                    else if (parent.GetType() == typeof(PhotoPopup))
                    {
                        PhotoPopup castedParent = (PhotoPopup)parent;
                        castedParent.commentBox.Text = "Replying to " + username + "'s comment: " + comment + "\n";
                        castedParent.SetReplyFlag(1);
                        castedParent.SetCommentToReplyTo(this);
                    }
                }
            }
            catch (NullReferenceException exception)
            {
                //This is due to the par
            }
        }

        private void DeleteComment(object sender, RoutedEventArgs e)
        {
            username = "deleted";
            comment = "deleted";
            commentBox.Text = "deleted";
            usernameText.Text = "deleted";
            CurrentUser = false;
        }
    }
}
