using Microsoft.Win32;
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
        public ImageSource imageSource { get; set; }
        public int score { get; set; }
        public bool upvoted;
        public bool currentUser { get; set; }
        private bool saved;
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
                    savePhoto.Content = "Unsave";
                }
                else if (value == false)
                {
                    saved = value;
                    savePhoto.Content = "Save";
                }
            }
        }
        public int commentCount { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public string time { get; set; }
        //private DateTime date;
        public double ageDays { get; set; }
        public double ageHours { get; set; }
        public List<Comment> comments { get; set; } = new List<Comment>();
        private bool isPrivate = true;
        public bool IsPrivate
        {
            get
            {
                return isPrivate;
            }
            set
            {
                isPrivate = value;
            }
        }

        public MainWindow main { get; set; }

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
            saved = false;
            currentUser = false;
        }

        public Photo(int id, String image)
        {
            InitializeComponent();
            String stringPath = image;
            Uri imageUri = new Uri(stringPath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            imageName.Source = imageSource = imageBitmap;

            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
            photoId = id;
            upvoted = false;
            sideScore.Text = score.ToString();
            saved = false;
            currentUser = false;
        }

        public Photo(int id, ImageSource image)
        {
            InitializeComponent();
            imageName.Source = imageSource = image;

            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
            photoId = id;
            upvoted = false;
            sideScore.Text = score.ToString();
            saved = false;
            currentUser = false;
        }

        public Photo(Photo photo)
        {
            InitializeComponent();
            imageName.Source = imageSource = photo.imageName.Source;

            title = photo.title;
            caption = photo.caption;
            time = DateTime.Now.ToString("hh:mm");
            score = 0;
            commentCount = 0;
            upvoted = false;
            sideScore.Text = score.ToString();
            saved = false;
            currentUser = true;
            this.isPrivate = photo.IsPrivate;
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
            if (main.signedIn)
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
            else if (!main.signedIn)
            {
                LoginPrompt prompt = new LoginPrompt(main);
                prompt.SetMessage("You must sign in to upvote photos.");
                prompt.ShowDialog();
                main.HighlightTab();
            }
        }

        /// <summary>
        /// Interaction logic for save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void savePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (main.signedIn)
            {
                if (!saved)
                {
                    // Create a new instance with the same attributes
                    Photo copyOfPhoto = new Photo(photoId, imageName.Source);
                    copyOfPhoto.title = this.title;
                    copyOfPhoto.caption = this.caption;
                    copyOfPhoto.username = this.username;
                    copyOfPhoto.ageDays = this.ageDays;
                    copyOfPhoto.ageHours = this.ageHours;
                    copyOfPhoto.time = this.time;
                    copyOfPhoto.score = this.score;
                    copyOfPhoto.main = this.main;
                    copyOfPhoto.displaySideInfo();
                    copyOfPhoto.comments = this.comments;
                    copyOfPhoto.commentCount = this.commentCount;
                    copyOfPhoto.upvoted = this.upvoted;

                    // Set the saved flag of the new Discussion to true
                    copyOfPhoto.Saved = true;
                    //  Pass it to SavedPage.AddPost()
                    main.currSavedPage.AddPost(copyOfPhoto);

                    // Set the Saved button content of this discussion to Unsave
                    // Set the saved flag of this dicussion to true
                    this.Saved = true;
                }
                else if (saved)
                {
                    this.Saved = false;
                    main.currSavedPage.RemovePost(this);
                    main.currPhotosPage.SetPhotoUnsaved(this);
                }
            }
            else if (!main.signedIn)
            {
                LoginPrompt prompt = new LoginPrompt(main);
                prompt.SetMessage("You must sign in to save photos.");
                prompt.ShowDialog();
                main.HighlightTab();
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
                imageStats.Text = score.ToString() + " points  " + commentCount.ToString() + " comments  " + ageHours.ToString() + "h ago\t";

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
                imageStats.Text = score.ToString() + " points  " + commentCount.ToString() + " comments  " + ageDays.ToString() + "d ago\t";

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

        public void OtherUserPage(object sender, RoutedEventArgs e)
        {
            this.main.contentControl.Content = new ProfilePageOtherUser(main);
            this.main.HighlightTab();
        }

        public void SavePhoto(object sender, RoutedEventArgs e)
        {
            if (!isPrivate)
            {
                captureClicks.Visibility = Visibility.Visible;
                savePopup.IsOpen = true;
            }
        }

        public void DownloadPhoto(object sender, RoutedEventArgs e)
        {
            // Display the save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            saveFileDialog.Title = "Download " + title;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = title;

            // Save the file
            if ((bool)saveFileDialog.ShowDialog())
            {
                // File stream to save image.
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

                // Saves the image in the proper format.
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        BitmapEncoder encoderJpg = new JpegBitmapEncoder();
                        encoderJpg.Frames.Add(BitmapFrame.Create(imageName.Source as BitmapImage));
                        encoderJpg.Save(fs);
                        break;
                    case 2:
                        BitmapEncoder encoderBmp = new BmpBitmapEncoder();
                        encoderBmp.Frames.Add(BitmapFrame.Create(imageName.Source as BitmapImage));
                        encoderBmp.Save(fs);
                        break;
                    case 3:
                        BitmapEncoder encoderGif = new GifBitmapEncoder();
                        encoderGif.Frames.Add(BitmapFrame.Create(imageName.Source as BitmapImage));
                        encoderGif.Save(fs);
                        break;
                    case 4:
                        BitmapEncoder encoderPng = new PngBitmapEncoder();
                        encoderPng.Frames.Add(BitmapFrame.Create(imageName.Source as BitmapImage));
                        encoderPng.Save(fs);
                        break;
                }

                fs.Close();
            }

            savePopup.IsOpen = false;
            captureClicks.Visibility = Visibility.Hidden;
        }

        public void CloseDownloadPopup(object sender, RoutedEventArgs e)
        {
            savePopup.IsOpen = false;
            captureClicks.Visibility = Visibility.Hidden;
        }

        private void HideRectangle(object sender, EventArgs e)
        {
            captureClicks.Visibility = Visibility.Hidden;
        }
    }
}
