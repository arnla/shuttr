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
            newPhoto.IsPrivate = false;
            newPhoto.main = this.parent;
            photoDict.Add(100, newPhoto);

            newPhoto = new Photo(101, "/Images/tokyo.jpg");
            newPhoto.title = "I miss this place";
            newPhoto.caption = "Message me if you want to talk about Tokyo (:";
            newPhoto.username = "Ehud";
            newPhoto.score = 64;
            newPhoto.displaySideInfo();
            newPhoto.IsPrivate = false;
            newPhoto.main = this.parent;
            photoDict.Add(101, newPhoto);

            newPhoto = new Photo(102, "Images/Mountains.jpg");
            newPhoto.username = "Lean";
            newPhoto.title = "Rate my mountains photo";
            newPhoto.score = 5;
            newPhoto.displaySideInfo();
            newPhoto.commentCount = 1;
            newPhoto.comments.Add(new Comment("Emilio", "Cool photo. Where was this?"));
            newPhoto.IsPrivate = false;
            newPhoto.main = this.parent;
            photoDict.Add(102, newPhoto);

            newPhoto = new Photo(103, "Images/miami.jpg");
            newPhoto.username = "Lawrence";
            newPhoto.title = "From my trip in miami";
            newPhoto.score = 5;
            newPhoto.commentCount = 1;
            newPhoto.comments.Add(new Comment("Emilio", "I see that hotel in so many miami nightlife pictures. Has some cool lighting"));
            newPhoto.IsPrivate = false;
            newPhoto.displaySideInfo();
            newPhoto.main = this.parent;
            photoDict.Add(103, newPhoto);

            DisplayPhotos();
            //imageContentControl.Content = new PhotosPage();
        }

        public PhotosPage(Dictionary<int, Photo> photos)
        {
            InitializeComponent();
            photoDict = photos;
            DisplayPhotos();
        }

        private void SetParentOfEachPhoto()
        {
            foreach (KeyValuePair<int, Photo> pair in photoDict)
            {
                pair.Value.main = parent;
            }
        }

        public void DisplayPhotos()
        {
            photoFeed.Children.Clear();
            foreach (KeyValuePair<int, Photo> pair in photoDict.AsEnumerable().Reverse())
            {
                var parent = VisualTreeHelper.GetParent(pair.Value);
                if (parent == null)
                {
                    Photo photoToAdd = new Photo(pair.Value);
                    photoToAdd.main = this.parent;
                    photoFeed.Children.Add(photoToAdd);
                    MakePhotoClickable(photoToAdd);
                }
            }

            SetParentOfEachPhoto();
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
            SetParentOfEachPhoto();
        }

        private void MessageButton(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {

        }

        public void SortClick(object sender, EventArgs e)
        {
            if (sender.Equals(sortByMenu) || sender.Equals(currentSortOption))
            {
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortPopular))
            {
                currentSortOption.Content = "Popular";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByPopular();
            }
            else if (sender.Equals(sortNew))
            {
                currentSortOption.Content = "New";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByNew();
            }
            else if (sender.Equals(sortMostCommented))
            {
                currentSortOption.Content = "Most Commented";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByMostCommented();
            }
            else if (sender.Equals(sortMostUpvoted))
            {
                currentSortOption.Content = "Most Upvoted";
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
                SortByMostUpvoted();
            }
        }

        public void SortByPopular()
        {
            // Set the current sort option.
            currentSortOption.Content = "Popular";

            // Get the array of all the children in the page.
            Photo[] photosToSort = new Photo[photoFeed.Children.Count];
            photoFeed.Children.CopyTo(photosToSort, 0);

            // Sort the array using linear sort.
            int i = 1;
            int j;
            while (i < photosToSort.Length)
            {
                j = i;
                while ((j > 0) && ((photosToSort[j-1].score + photosToSort[j-1].commentCount ) > (photosToSort[j].score + photosToSort[j].commentCount)))
                {
                    Photo temp = photosToSort[j];
                    photosToSort[j] = photosToSort[j - 1];
                    photosToSort[j - 1] = temp;
                    j--;
                }
                i++;
            }

            // Clear the children.
            photoFeed.Children.Clear();
            // Add the sorted list of children (backwards | highest popularity at top)
            for (int k = photosToSort.Length - 1; k >= 0; k--)
            {
                Photo photoToAdd = new Photo(photosToSort[k]);
                photoToAdd.main = this.parent;
                photoFeed.Children.Add(photoToAdd);
                MakePhotoClickable(photoToAdd);
            }
        }
        public void SortByNew()
        {
            DisplayPhotos();
        }
        public void SortByMostCommented()
        {
            // Get the array of all the children in the page.
            Photo[] photosToSort = new Photo[photoFeed.Children.Count];
            photoFeed.Children.CopyTo(photosToSort, 0);

            // Sort the array using linear sort.
            int i = 1;
            int j;
            while (i < photosToSort.Length)
            {
                j = i;
                while ((j > 0) && (photosToSort[j - 1].commentCount > photosToSort[j].commentCount))
                {
                    Photo temp = photosToSort[j];
                    photosToSort[j] = photosToSort[j - 1];
                    photosToSort[j - 1] = temp;
                    j--;
                }
                i++;
            }

            // Clear the children.
            photoFeed.Children.Clear();
            // Add the sorted list of children (backwards | highest popularity at top)
            for (int k = photosToSort.Length - 1; k >= 0; k--)
            {
                Photo photoToAdd = new Photo(photosToSort[k]);
                photoToAdd.main = this.parent;
                photoFeed.Children.Add(photoToAdd);
                MakePhotoClickable(photoToAdd);
            }
        }
        public void SortByMostUpvoted()
        {
            // Get the array of all the children in the page.
            Photo[] photosToSort = new Photo[photoFeed.Children.Count];
            photoFeed.Children.CopyTo(photosToSort, 0);

            // Sort the array using linear sort.
            int i = 1;
            int j;
            while (i < photosToSort.Length)
            {
                j = i;
                while ((j > 0) && (photosToSort[j - 1].score > photosToSort[j].score))
                {
                    Photo temp = photosToSort[j];
                    photosToSort[j] = photosToSort[j - 1];
                    photosToSort[j - 1] = temp;
                    j--;
                }
                i++;
            }

            // Clear the children.
            photoFeed.Children.Clear();
            // Add the sorted list of children (backwards | highest popularity at top)
            for (int k = photosToSort.Length - 1; k >= 0; k--)
            {
                Photo photoToAdd = new Photo(photosToSort[k]);
                photoToAdd.main = this.parent;
                photoFeed.Children.Add(photoToAdd);
                MakePhotoClickable(photoToAdd);
            }
        }

        public void SetPhotoUnsaved(Photo photoToUnsave)
        {
            // Look through the children of the discussion page
            foreach (Photo photoInFeed in photoFeed.Children)
            {
                if (photoInFeed.photoId == photoToUnsave.photoId)
                {
                    // If the discussion is saved, remove it
                    photoInFeed.Saved = false;
                }
            }
        }
    }
}
