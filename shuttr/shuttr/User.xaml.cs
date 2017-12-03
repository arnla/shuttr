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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public Dictionary<int, Photo> userPhotos { get; set; } = new Dictionary<int, Photo>();
        public Dictionary<int, Discussion> userDiscussion { get; set; } = new Dictionary<int, Discussion>();

        /// <summary>
        /// The user name of this user.
        /// </summary>
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// The password this user uses to enter shuttr.
        /// </summary>
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// The description a user chooses for their profile and/or themselves.
        /// </summary>
        private string biography;
        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        /// <summary>
        /// The date the user joined, represented as a DateTime object.
        /// Use DateTime.Today to get the current date.
        /// </summary>
        private DateTime dateJoined;
        public DateTime DateJoined
        {
            get { return dateJoined; }
            set { dateJoined = DateJoined; }
        }

        /// <summary>
        /// A list of posts this user has made.
        /// Stored as a list of UserControls, allowing storage of both Photo and Discussion posts.
        /// </summary>
        private List<UserControl> posts = new List<UserControl>();
        public List<UserControl> Posts
        {
            get { return posts; }
        }


        /// <summary>
        /// A new user with no parameters set.
        /// </summary>
        public User()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A new user with a specific username and join date.
        /// </summary>
        /// <param name="name"> The username of the user </param>
        /// <param name="password"> The password of the user </param>
        /// <param name="date"> The date the user joined </param>
        public User(string name, string password, DateTime date)
        {
            InitializeComponent();

            userName = name;
            dateJoined = date;
        }

        /// <summary>
        /// A new user with a specific username, profile picture, and date.
        /// </summary>
        /// <param name="name"> The username of the user </param>
        /// <param name="password"> The password of the user </param>
        /// <param name="imagePath"> The full path to the user's profile picture </param>
        /// <param name="date"> The date the user joined </param>
        public User(string name, string password, string imagePath, DateTime date)
        {
            InitializeComponent();

            userName = name;
            SetProfilePicture(imagePath);
            dateJoined = date;
        }

        /// <summary>
        /// A new user with a specific username, profile picture, and date.
        /// </summary>
        /// <param name="name"> The username of the user </param>
        /// <param name="password"> The password of the user </param>
        /// <param name="profilePicture"> An ImageSource representing the user's profile picture </param>
        /// <param name="date"> The date the user joined </param>
        public User(string name, string password, ImageSource profilePicture, DateTime date)
        {
            InitializeComponent();

            userName = name;
            userPicture.Source = profilePicture;
            dateJoined = date;
        }

        
        /// <summary>
        /// Changes the profile picture of this user to the specified image.
        /// </summary>
        /// <param name="image"> An ImageSource representing the desired profile picture </param>
        public void SetProfilePicture(ImageSource image)
        {
            userPicture.Source = image;
        }

        /// <summary>
        /// Changes the profile picture of this user to the specific image.
        /// </summary>
        /// <param name="imagePath"> The path to the user's desired profile picture </param>
        public void SetProfilePicture(string imagePath)
        {
            Uri imageUri = new Uri(imagePath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            userPicture.Source = imageBitmap;
        }

        /// <summary>
        /// Adds a post to this user's profile.
        /// </summary>
        /// <param name="post"> A discussion or photo to add to this user's posts </param>
        public void AddPost(UserControl post)
        {
            posts.Add(post);
        }
    }
}
