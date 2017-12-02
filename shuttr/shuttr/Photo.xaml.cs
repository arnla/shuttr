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
    /// Interaction logic for Photo.xaml
    /// </summary>
    public partial class Photo : UserControl
    {
        public User originalPoster;
        public string username { get; set; }
        public int photoId { get; }
        public int score { get; set; }
        public bool upvoted;
        public int commentCount { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public string time { get; }
        //private DateTime date;
        private double ageDays;
        private double ageHours;
        public List<Comment> comments { get; set; } = new List<Comment>();

        /// <summary>
        /// Initialize photo object with the time (in duration) it was posted
        /// </summary>
        public Photo()
        {
            InitializeComponent();
            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
            upvoted = false;
            sideScore.Text = score.ToString();
        }

        public Photo(int id, String image)
        {
            InitializeComponent();
            String stringPath = image;
            Uri imageUri = new Uri(stringPath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            imageName.Source = imageBitmap;

            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
            photoId = id;
            upvoted = false;
            sideScore.Text = score.ToString();
        }

        public Photo(int id, ImageSource image)
        {
            InitializeComponent();
            imageName.Source = image;

            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
            photoId = id;
            upvoted = false;
            sideScore.Text = score.ToString();
        }

        /// <summary>
        /// Shows the info in the side of the photo
        /// Had to be a separate method to avoid overloading the constructors further
        /// </summary>
        /// <param name="username"></param>
        public void displaySideInfo()
        {
            sideUserName.Text = username;
            sideScore.Text = score.ToString();
        }


         /// <summary>
         /// Interaction logic for voting button
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void upVote(object sender, RoutedEventArgs e)
        {
            if (upvoted == false)
            {
                upvoted = true;
                String stringPath = "Images/Icons/arrow.png";
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                upvoteImage.Source = imageBitmap;
                score++;
                sideScore.Text = score.ToString();
            }
            else
            {
                upvoted = false;
                String stringPath = "Images/Icons/arrow_blank.png";
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                upvoteImage.Source = imageBitmap;
                score--;
                sideScore.Text = score.ToString();
            }
        }

        public void ClickPhoto(object sender, MouseButtonEventArgs e)
        {

        }

        /// <summary>
        /// Interaction logic for hovering over a photo
        /// Time logic has been modified to simulate accelerated time and not real time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoverPhoto(object sender, MouseEventArgs e)
        {
            // Time has been modified to simulate a longer period
            string timeNow = DateTime.Now.ToString("hh:mm");
            TimeSpan ts = TimeSpan.Parse(time);
            TimeSpan ts0 = TimeSpan.Parse(timeNow);
            ageDays = (ts0 - ts).TotalMinutes;

            // Creates the "blur" when hovering over a photo
            imageName.Opacity = 0.45;

            if (ageDays < 2.00)
            {
                string timeNow2 = DateTime.Now.ToString("hh:mm");
                TimeSpan ts1 = TimeSpan.Parse(time);
                TimeSpan ts2 = TimeSpan.Parse(timeNow2);

                ageHours = (ts2 - ts1).TotalSeconds / 12;

                // Display the image stats
                imageStats.Visibility = Visibility.Visible;
                imageStats.Text = score.ToString() + " points  " + commentCount.ToString() + " comments  " + ageHours.ToString() + "h ago ";

                // Display the caption and title
                imageCaption.Visibility = Visibility.Visible;
                imageCaption.Text = caption;
                imageTitle.Visibility = Visibility.Visible;
                imageTitle.Text = title;
            }
            else
            {
                // Display the image stats
                imageStats.Visibility = Visibility.Visible;
                imageStats.Text = score.ToString() + " points  " + commentCount.ToString() + " comments  " + ageDays.ToString() + "d ago ";

                // Display the caption and title
                imageCaption.Visibility = Visibility.Visible;
                imageCaption.Text = caption;
                imageTitle.Visibility = Visibility.Visible;
                imageTitle.Text = title;
            }
        }

        /// <summary>
        /// Hovering off a photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void MouseLeave(object sender, MouseEventArgs e)
        {
            imageName.Opacity = 1;
            imageStats.Visibility = Visibility.Hidden;

            imageCaption.Visibility = Visibility.Hidden;
            imageTitle.Visibility = Visibility.Hidden;
        }
    }
}
