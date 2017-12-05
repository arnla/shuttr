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
    /// Interaction logic for PhotoPopup.xaml
    /// </summary>
    public partial class PhotoPopup : UserControl
    {
        private MainWindow main;
        private UserControl parent;
        private Photo photo;
        int replyFlag = 0; // 1 = reply to comment, 0 = reply to thread
        Comment commentToReplyTo = null;

        public PhotoPopup()
        {
            InitializeComponent();

            window.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.85;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.7;
        }

        public PhotoPopup(MainWindow main, UserControl parent, Photo sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill(Visibility.Visible);

            this.parent = parent;
            this.photo = sender;

            // Need to create a new photo, otherwise it will throw an exception because one object can't be the child of 2 elements
            Image embedImage = new Image();
            embedImage.Source = sender.imageSource;
            embedImage.MouseLeftButtonDown += Maximize;
            commentFeed.Children.Add(embedImage);

            Username.Text = sender.username;
            title.Text = sender.title;
            description.Text = sender.caption;
            NumRepliesButton.Content = sender.commentCount;
            MessageOrDeleteButton();

            DisplayComments();

            window.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.85;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.7;
        }

        public void SetReplyFlag(int flag)
        {
            replyFlag = flag;
        }

        public void SetCommentToReplyTo(Comment comment)
        {
            commentToReplyTo = comment;
        }

        public PhotoPopup(MainWindow main, Photo sender)
        {
            InitializeComponent();

            this.main = main;
            main.ChangeFill(Visibility.Visible);

            this.photo = sender;

            // Need to create a new photo, otherwise it will throw an exception because one object can't be the child of 2 elements
            Image embedImage = new Image();
            embedImage.Source = sender.imageSource;
            embedImage.MouseLeftButtonDown += Maximize;
            commentFeed.Children.Add(embedImage);

            Username.Text = sender.username;
            title.Text = sender.title;
            description.Text = sender.caption;
            NumRepliesButton.Content = sender.comments.Count();
            MessageOrDeleteButton();

            DisplayComments();

            window.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.85;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.7;
        }

        private void DisplayComments()
        {
            commentFeed.Children.Clear();

            Image embedImage = new Image();
            embedImage.Source = photo.imageSource;
            embedImage.MouseLeftButtonDown += Maximize;
            commentFeed.Children.Add(embedImage);
            foreach (Comment c in photo.comments)
            {
                c.parent = this;
                commentFeed.Children.Add(c);
            }
        }

        private void MessageOrDeleteButton()
        {
            if (photo.currentUser == true)
            {
                MessageUserButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageUserButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void Close(object sender, EventArgs e)
        {
            main.ChangeFill(Visibility.Hidden);
            this.Visibility = Visibility.Hidden;
            commentFeed.Children.Clear();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (main.signedIn)
            {
                if (sender.Equals(postCommentButton))
                {
                    if (replyFlag == 0)
                    {
                        Comment newComment = new Comment("current user", commentBox.Text, this);
                        newComment.CurrentUser = true;
                        commentFeed.Children.Add(newComment);
                        photoAndComments.ScrollToEnd();
                        photo.comments.Add(newComment);
                        commentBox.Text = "";
                        // Unnecessary line. Same as DiscussionPopup.
                        //parent.photoDict[photo.photoId] = photo;
                    }
                    else if (replyFlag == 1)
                    {
                        string[] reply = commentBox.Text.Split('\n');
                        Comment newComment = new Comment("current user", reply[1], this);
                        newComment.CurrentUser = true;
                        commentToReplyTo.repliesFeed.Children.Add(newComment);
                        commentBox.Text = "";
                        replyFlag = 0;
                        commentToReplyTo = null;
                    }
                }
                else if (sender.Equals(DeleteButton))
                {
                        // remove from photos page
                        main.currPhotosPage.photoDict.Remove(photo.photoId);
                        main.currPhotosPage.DisplayPhotos();
                        // remove from user's profile page
                        main.currUser.userPhotos.Remove(photo.photoId);
                        main.currProfilePage.DisplayPosts();
                        // close popup window
                        this.Visibility = Visibility.Hidden;
                        main.ChangeFill(Visibility.Hidden);
                }
            }
            else if (!main.signedIn)
            {
                NoBlurPrompt prompt = new NoBlurPrompt(main, this);
                prompt.SetMessage("You must sign in to discuss with users.");
                prompt.ShowDialog();
                main.HighlightTab();
            }
        }

        private Border imageBorder;
        private void Maximize(object sender, RoutedEventArgs e)
        {
            Image tmp = (Image)sender;

            // Border with a maximum width and height of 0.85%
            imageBorder = new Border();
            imageBorder.SetValue(Grid.RowSpanProperty, 3);
            imageBorder.SetValue(Grid.ColumnSpanProperty, 3);
            imageBorder.HorizontalAlignment = HorizontalAlignment.Center;
            imageBorder.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.85;
            imageBorder.MaxWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.85;

            // Grid that will hold a close button and the image.
            Grid maximizeGrid = new Grid();
            RowDefinition closeRow = new RowDefinition();
            closeRow.Height = GridLength.Auto;
            RowDefinition imageRow = new RowDefinition();
            maximizeGrid.RowDefinitions.Add(closeRow);
            maximizeGrid.RowDefinitions.Add(imageRow);
            ColumnDefinition column = new ColumnDefinition();
            column.Width = GridLength.Auto;
            maximizeGrid.ColumnDefinitions.Add(column);
            maximizeGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#F6FBFF"));

            // Close button
            Button closeMaximize = new Button();
            closeMaximize.Content = "X";
            closeMaximize.Width = 50;
            closeMaximize.FontWeight = FontWeights.Bold;
            closeMaximize.Background = new SolidColorBrush(Colors.Red);
            closeMaximize.Foreground = new SolidColorBrush(Colors.White);
            closeMaximize.HorizontalAlignment = HorizontalAlignment.Right;
            closeMaximize.SetValue(Grid.RowProperty, 0);
            closeMaximize.Click += CloseMaximizedImage;

            // The image to show
            Image maximizedImage = new Image();
            maximizedImage.Source = tmp.Source;
            maximizedImage.SetValue(Grid.RowProperty, 1);
            maximizedImage.MouseLeftButtonDown += CloseMaximizedImage;

            // Add the close button and image to the grid.
            maximizeGrid.Children.Add(closeMaximize);
            maximizeGrid.Children.Add(maximizedImage);

            // Add the grid to the border.
            imageBorder.Child = maximizeGrid;

            // Blur this popup.
            window.BorderThickness = new Thickness(0);
            fillPopup.Visibility = Visibility.Visible;
            mainGrid.ShowGridLines = false;

            // Add the maximized image to the main grid.
            main.mainGrid.Children.Add(imageBorder);
        }

        private void CloseMaximizedImage(object sender, RoutedEventArgs e)
        {
            window.BorderThickness = new Thickness(5);
            fillPopup.Visibility = Visibility.Hidden;
            mainGrid.ShowGridLines = true;
            imageBorder.Visibility = Visibility.Collapsed;
        }
    }
}
