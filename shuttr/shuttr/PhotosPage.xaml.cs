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
            photoDict.Add(100, new Photo(100, "/Images/Coast.jpg"));
            photoDict.Add(101, new Photo(101, "/Images/tokyo.jpg"));
            DisplayPhotos();
            //imageContentControl.Content = new PhotosPage();
        }

        public PhotosPage(Dictionary<int, Photo> photos)
        {
            InitializeComponent();
            photoDict = photos;
            DisplayPhotos();
        }

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
    }
}
