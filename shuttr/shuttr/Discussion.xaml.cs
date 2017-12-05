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
        public int discussionId { get; set; }
        public string user { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int numReplies { get; set; }
        public int score { get; set; }
        public List<Comment> comments { get; set; }
        public bool currUser { get; set; } = false;

        public MainWindow main { get; set; }
        public bool saved { get; set; }
        public bool Saved
        {
            get
            {
                return saved;
            }
            set
            {
                if (value == true)
                {
                    saved = value;
                    saveDiscussion.Content = "Unsave";
                }
                else if (value == false)
                {
                    saved = value;
                    saveDiscussion.Content = "Save";
                }
            }
        }

        public Discussion(Discussion newDiscussion)
        {
            InitializeComponent();
            discussionId = newDiscussion.discussionId;
            user = userName.Text = newDiscussion.user;
            title = discussionTitle.Text = newDiscussion.title;
            description = newDiscussion.description;
            numReplies = newDiscussion.numReplies;
            score = 0;
            comments = newDiscussion.comments;
            currUser = true;
            saved = false;
        }

        public Discussion()
        {
            InitializeComponent();

            saved = false;
        }

        /// <summary>
        /// Creates a discussion feed item with the default profile picture icon and the specified contents.
        /// </summary>
        /// <param name="name">The username of the poster</param>
        /// <param name="title">The title of the discussion post</param>
        /// <param name="numReplies">The number of replies the discussion post has</param>
        public Discussion(int discussionId, string name, string title, string description, int numReplies)
        {
            InitializeComponent();

            this.discussionId = discussionId;
            this.user = name;
            this.title = title;
            this.description = description;
            this.numReplies = numReplies;
            userName.Text = name;
            discussionTitle.Text = title;
            saved = false;

            // comments test
            comments = new List<Comment>();
            //comments.Add(new Comment("user", "comment1"));
            //comments.Add(new Comment("user", "comment2"));

            // If the reply count is 1, show "1 reply" instead of "1 replies"
            replyCount.Text = numReplies.ToString() + ((numReplies == 1) ? " reply" : " replies");
        }

        /// Creates a discussion feed item with the default profile picture icon and the specified contents.
        /// </summary>
        /// <param name="name">The username of the poster</param>
        /// <param name="title">The title of the discussion post</param>
        /// <param name="numReplies">The number of replies the discussion post has</param>
        public Discussion(int discussionId, string name, string title, string description, int numReplies, bool currUser)
        {
            InitializeComponent();

            this.discussionId = discussionId;
            this.user = name;
            this.title = title;
            this.description = description;
            this.numReplies = numReplies;
            userName.Text = name;
            discussionTitle.Text = title;
            saved = false;
            currUser = true;

            // comments test
            comments = new List<Comment>();
            //comments.Add(new Comment("user", "comment1"));
            //comments.Add(new Comment("user", "comment2"));

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
        public Discussion(int discussionId, ImageSource picture, string name, string title, string description, int numReplies)
        {
            InitializeComponent();

            this.discussionId = discussionId;
            this.user = name;
            this.title = title;
            this.description = description;
            this.numReplies = numReplies;
            userPicture.Source = picture;
            userName.Text = name;
            discussionTitle.Text = title;
            saved = false;

            // If the reply count is 1, show "1 reply" instead of "1 replies"
            replyCount.Text = numReplies.ToString() + ((numReplies == 1) ? " reply" : " replies");
        }

        public string GetUser()
        {
            return user;
        }

        public int GetDiscussionId()
        {
            return discussionId;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetDescription()
        {
            return description;
        }

        public int GetNumReplies()
        {
            return numReplies;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (main.signedIn)
            {
                if (!saved)
                {
                    // Create a new instance with the same attributes
                    Discussion copyOfDiscussion = new Discussion(discussionId, user, title, description, numReplies);
                    copyOfDiscussion.score = this.score;
                    copyOfDiscussion.main = this.main;
                    copyOfDiscussion.comments = this.comments;

                    // Set the saved flag of the new Discussion to true
                    copyOfDiscussion.Saved = true;
                    //  Pass it to SavedPage.AddPost()
                    main.currSavedPage.AddPost(copyOfDiscussion);

                    // Set the Saved button content of this discussion to Unsave
                    // Set the saved flag of this dicussion to true
                    this.Saved = true;
                }
                else if (saved)
                {
                    this.Saved = false;

                    main.currSavedPage.RemovePost(this);
                    main.currDiscussionPage.SetDiscussionUnsaved(this);
                }
            }
            else if (!main.signedIn)
            {
                LoginPrompt prompt = new LoginPrompt(main);
                prompt.SetMessage("You must sign in to save discussions.");
                prompt.ShowDialog();
                main.HighlightTab();
            }
        }

        public void OtherUserPage(object sender, RoutedEventArgs e)
        {
            this.main.contentControl.Content = new ProfilePageOtherUser(main);
            this.main.HighlightTab();
        }
    }
}
