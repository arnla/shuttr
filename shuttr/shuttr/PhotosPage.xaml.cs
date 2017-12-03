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
        private MainWindow parent;
        public Dictionary<int, Photo> photoDict { get; set; } = new Dictionary<int, Photo>();
        public int photoIdCounter { get; set; } = 0;

        public PhotosPage()
        {
            InitializeComponent();
            Photo newPhoto = new Photo(100, "/Images/Coast.jpg");
            newPhoto.title = "Wavy Days & Sun Rays";
            newPhoto.caption = "A picture I took on my recent trip to some islands";
            newPhoto.username = "Angela";
            newPhoto.score = 42;
            newPhoto.displaySideInfo();
            photoDict.Add(100, newPhoto);

            newPhoto = new Photo(101, "/Images/tokyo.jpg");
            newPhoto.title = "I miss this place";
            newPhoto.caption = "Message me if you want to talk about Tokyo (:";
            newPhoto.username = "Emilio";
            newPhoto.score = 64;
            newPhoto.displaySideInfo();
            photoDict.Add(101, newPhoto);
            DisplayPhotos();
            //imageContentControl.Content = new PhotosPage();
        }

        public PhotosPage(Dictionary<int, Photo> photos)
        {
            InitializeComponent();
            photoDict = photos;
            DisplayPhotos();
        }

        /* For later. Still need to add button to photo.
        private void SetParentOfEachDiscussion()
        {
            foreach (KeyValuePair<int, Photo> pair in photoDict)
            {
                pair.Value.main = parent;
            }
        }*/

        public void DisplayPhotos()
        {
            photoFeed.Children.Clear();
            foreach (KeyValuePair<int, Photo> pair in photoDict.AsEnumerable().Reverse())
            {
                var parent = VisualTreeHelper.GetParent(pair.Value);
                if (parent == null)
                {
                    photoFeed.Children.Add(pair.Value);
                    MakePhotoClickable(pair.Value);
                }
            }

            //SetParentOfEachPhoto();
        }

        public void MakePhotoClickable(Photo photo)
        {
            photo.MouseLeftButtonDown += new MouseButtonEventHandler(this.PhotoClick);
        }

        public void AddPhoto(Photo photo)
        {
            photoDict.Add(photoIdCounter++, photo);
            DisplayPhotos();
        }

        /// <summary>
        /// Handles a clicked photo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PhotoClick(object sender, MouseButtonEventArgs e)
        {
            Photo tmp = (Photo)sender;
            PhotoPopup photoPopup = new PhotoPopup(parent, this, photoDict[tmp.photoId]);
            photoPopup.SetValue(Grid.RowProperty, 2);
            photoPopup.SetValue(Grid.ColumnSpanProperty, 3);
            parent.mainGrid.Children.Add(photoPopup);
        }

        public void SetParent(MainWindow main)
        {
            parent = main;
        }

        private void MessageButton(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {

        }

        public void SortClick(object sender, EventArgs e)
        {
            if (sender.Equals(sortByMenu))
            {
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortPopular))
            {
                currentSortOption.Content = "Popular";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortNew))
            {
                currentSortOption.Content = "New";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortMostCommented))
            {
                currentSortOption.Content = "Most Commented";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortMostUpvoted))
            {
                currentSortOption.Content = "Most Upvoted";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
        }
    }
}
