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
    /// Interaction logic for PhotosPage.xaml
    /// </summary>
    public partial class PhotosPage : UserControl
    {
        private List<Photo> photosList;

        public PhotosPage()
        {
            InitializeComponent();
            photosList = new List<Photo>();
            photosList.Add(new Photo());
            photosList.Add(new Photo("/Images/Coast.jpg"));
            photosList.Add(new Photo("/Images/tokyo.jpg"));
            DisplayPhotos();
            //imageContentControl.Content = new PhotosPage();
        }

        public PhotosPage(List<Photo> photos)
        {
            InitializeComponent();
            photosList = photos;
            DisplayPhotos();
        }

        public List<Photo> GetPhotosList()
        {
            return photosList;
        }

        public void DisplayPhotos()
        {
            foreach (Photo photo in photosList)
            {
                var parent = VisualTreeHelper.GetParent(photo);
                if (parent == null)
                    photoFeed.Children.Add(photo);
            }
        }
        /// <summary>
        /// Handles a clicked photo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PhotoClick(object sender, MouseButtonEventArgs e)
        {
            /**if (sender.Equals(image2))
            {
                PhotosPage popUp = new PhotosPage();
                popUp.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                popUp.popUpPageFill.Visibility = Visibility.Visible;
                imageContentControl.Content = popUp;
                popUp.photoPopUpWindow.IsOpen = true;
            }**/
        }

        private void MessageButton(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
