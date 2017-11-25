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
        /// User object here
        private int score;
        private int commentCount;
        // Format - hh:mm
        private string time;
        // Format - MM/DD/YYYY
        private string date;

        public Photo()
        {
            InitializeComponent();
            time = DateTime.Now.ToShortTimeString();
            date = DateTime.Now.ToShortDateString();
            score = 0;
            commentCount = 0;
        }

        public Photo(String image)
        {
            InitializeComponent();
            String stringPath = image;
            Uri imageUri = new Uri(stringPath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            imageName.Source = imageBitmap;

            time = DateTime.Now.ToShortTimeString();
            date = DateTime.Now.ToShortDateString();
            score = 0;
            commentCount = 0;
        }

        public Photo(ImageSource image)
        {
            InitializeComponent();
            imageName.Source = image;

            time = DateTime.Now.ToShortTimeString();
            date = DateTime.Now.ToShortDateString();
            score = 0;
            commentCount = 0;
        }

        public void ClickPhoto(object sender, MouseButtonEventArgs e)
        {

        }

        private void HoverPhoto(object sender, MouseEventArgs e)
        {
            imageStats.Width = imageName.Width;
            imageStats.Visibility = Visibility.Visible;
            imageStats.Text = score.ToString() + " points  " + commentCount.ToString() + " comments";
        }

        private new void MouseLeave(object sender, MouseEventArgs e)
        {
            imageStats.Visibility = Visibility.Hidden;
        }
    }
}
