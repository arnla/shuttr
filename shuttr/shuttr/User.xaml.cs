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

        // Posts. list of UserControls

        public User()
        {
            InitializeComponent();
        }

        public void setProfilePicture(BitmapImage image)
        {
            userPicture.Source = image;
        }

        public void setProfilePicture(string imagePath)
        {
            Uri imageUri = new Uri(imagePath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            userPicture.Source = imageBitmap;
        }
    }
}
