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
        /// User object of original poster here
        public string username { get; }
        public int photoId { get; }
        private int score;
        public int commentCount { get; }
        public string title { get; set; }
        public string caption { get; set; }
        private string time;
        //private DateTime date;
        private double ageDays;
        private double ageHours;
        public List<Comment> comments { get; set; } = new List<Comment>();

        public Photo()
        {
            InitializeComponent();
            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
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
        }

        public Photo(int id, ImageSource image)
        {
            InitializeComponent();
            imageName.Source = image;

            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
            photoId = id;
        }

        public void ClickPhoto(object sender, MouseButtonEventArgs e)
        {

        }

        private void HoverPhoto(object sender, MouseEventArgs e)
        {
            // Time has been modified to simulate a longer period
            string timeNow = DateTime.Now.ToString("hh:mm");
            TimeSpan ts = TimeSpan.Parse(time);
            TimeSpan ts0 = TimeSpan.Parse(timeNow);
            ageDays = (ts0 - ts).TotalMinutes;

            if (ageDays < 2.00)
            {
                string timeNow2 = DateTime.Now.ToString("hh:mm");
                TimeSpan ts1 = TimeSpan.Parse(time);
                TimeSpan ts2 = TimeSpan.Parse(timeNow2);

                ageHours = (ts2 - ts1).TotalSeconds / 12;

                imageStats.Visibility = Visibility.Visible;
                imageStats.Text = score.ToString() + " points  " + commentCount.ToString() + " comments  " + ageHours.ToString() + "h ago" + "  title: " + title + " caption: " + caption;
            }
            else
            {
                imageStats.Visibility = Visibility.Visible;
                imageStats.Text = score.ToString() + " points  " + commentCount.ToString() + " comments  " + ageDays.ToString() + "d ago";
            }
        }

        private new void MouseLeave(object sender, MouseEventArgs e)
        {
            imageStats.Visibility = Visibility.Hidden;
        }
    }
}
