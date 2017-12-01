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
        }

        public Comment(string username, string comment, PhotoPopup parent)
        {
            InitializeComponent();
            this.username = username;
            this.comment = comment;
            usernameText.Text = username;
            commentBox.Text = comment;
            this.parent = parent;
        }

        public Comment(string username, string comment, DiscussionPopup parent)
        {
            InitializeComponent();
            this.username = username;
            this.comment = comment;
            usernameText.Text = username;
            commentBox.Text = comment;
            this.parent = parent;
        }

        protected void Button_Click(object sender, EventArgs e)
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
                    castedParent.commentBox.Document.Blocks.Clear();
                    castedParent.commentBox.Document.Blocks.Add(new Paragraph(new Run("Replying to " + username + "'s comment: " + comment + "\n")));
                    castedParent.SetReplyFlag(1);
                    castedParent.SetCommentToReplyTo(this);
                }
            }
        }
    }
}
