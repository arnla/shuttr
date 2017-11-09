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
    /// Interaction logic for Discussion.xaml
    /// </summary>
    public partial class Discussion : UserControl
    {
        public Discussion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a discussion feed item with the default profile picture icon and the specified contents.
        /// </summary>
        /// <param name="name">The username of the poster</param>
        /// <param name="title">The title of the discussion post</param>
        /// <param name="numReplies">The number of replies the discussion post has</param>
        public Discussion(string name, string title, int numReplies)
        {
            InitializeComponent();

            userName.Text = name;
            discussionTitle.Text = title;

            // If the reply count is 1, show "1 reply" instead of "1 replies"
            replyCount.Text = numReplies.ToString() + ((numReplies == 1) ? " reply" : " replies");
        }

        /// <summary>
        /// Creates a discussion feed item with the specified contents.
        /// </summary>
        /// <param name="picture">An ImageSource object pertaining to the user's profile picture</param>
        /// <param name="name">The username of the original poster</param>
        /// <param name="title">The title of the discussion post</param>
        /// <param name="numReplies">The number of replies the discussion post has</param>
        public Discussion(ImageSource picture, string name, string title, int numReplies)
        {
            InitializeComponent();

            userPicture.Source = picture;
            userName.Text = name;
            discussionTitle.Text = title;

            // If the reply count is 1, show "1 reply" instead of "1 replies"
            replyCount.Text = numReplies.ToString() + ((numReplies == 1) ? " reply" : " replies");
        }
    }
}
