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
    /// Interaction logic for PostPhotoPopup.xaml
    /// </summary>
    public partial class PostPhotoPopup : UserControl
    {
        MainWindow parent;

        public PostPhotoPopup()
        {
            InitializeComponent();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        public PostPhotoPopup(MainWindow main)
        {
            InitializeComponent();

            parent = main;
            parent.ChangeFill(Visibility.Visible);

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(BrowseButton))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                var result = dialog.ShowDialog();
                if (result == false)
                    return;
                ImageBox.Visibility = Visibility.Hidden;
                AddedImage.Source = new BitmapImage(new Uri(dialog.FileName));
                AddedImage.Visibility = Visibility.Visible;
            }
            else if (sender.Equals(CancelPostPhotoButton))
            {
                PostCancelPrompt prompt = new PostCancelPrompt(this);
                prompt.ShowDialog();
                /*
                parent.ChangeFill(Visibility.Hidden);
                AddedImage.Source = null;
                AddedImage.Visibility = Visibility.Hidden;
                ImageBox.Visibility = Visibility.Visible;
                BrowseButton.Foreground = new SolidColorBrush(Colors.Black);
                AddPhotoTitleDefault.Foreground = new SolidColorBrush(Colors.Black);
                AddPhotoCaptionDefault.Foreground = new SolidColorBrush(Colors.Black);
                this.Visibility = Visibility.Hidden;*/
            }
            else if (sender.Equals(ConfirmPostPhotoButton))
            {
                bool isComplete = true;
                // check if all fields are filled in
                if (AddedImage.Source == null)
                {
                    BrowseButton.Foreground = new SolidColorBrush(Colors.Red);
                    isComplete = false;
                }
                if (AddPhotoTitleBox.Text.Equals(""))
                {
                    AddPhotoTitleDefault.Foreground = new SolidColorBrush(Colors.Red);
                    isComplete = false;
                }
                // form is complete
                if (isComplete)
                {
                    Photo photoBeingAdded = new Photo(parent.currPhotosPage.photoIdCounter, AddedImage.Source);

                    if (checkPrivate.IsChecked.GetValueOrDefault() == true)
                    {
                        photoBeingAdded.IsPrivate = false;
                    }

                    parent.AddPhoto(photoBeingAdded, AddPhotoTitleBox.Text, AddPhotoCaptionBox.Text);
                    parent.ChangeFill(Visibility.Hidden);
                    this.Visibility = Visibility.Hidden;
                }
            }
        }


        public void Cancel()
        {
            parent.ChangeFill(Visibility.Hidden);
            AddedImage.Source = null;
            AddedImage.Visibility = Visibility.Hidden;
            ImageBox.Visibility = Visibility.Visible;
            BrowseButton.Foreground = new SolidColorBrush(Colors.Black);
            AddPhotoTitleDefault.Foreground = new SolidColorBrush(Colors.Black);
            AddPhotoCaptionDefault.Foreground = new SolidColorBrush(Colors.Black);
            this.Visibility = Visibility.Hidden;
        }

        private void rebrowse(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result == false)
                return;
            ImageBox.Visibility = Visibility.Hidden;
            AddedImage.Source = new BitmapImage(new Uri(dialog.FileName));
            AddedImage.Visibility = Visibility.Visible;
        }
    }
}
