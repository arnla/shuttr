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
    public partial class SavedPage : UserControl
    {
        MainWindow parent;

        public SavedPage(MainWindow main)
        {
            InitializeComponent();

            parent = main;
        }

        public void AddPost(UserControl post)
        {
            // Check the type of the post to add
            if (post.GetType() == typeof(Discussion))
            {
                // Cast the post properly
                Discussion discussionToAdd = (Discussion)post;

                // Look through the children of the saved page
                foreach (UserControl postInFeed in savedFeed.Children)
                {
                    // If a child is the same type as the post being add it, compare them
                    if (postInFeed.GetType() == typeof(Discussion))
                    {
                        Discussion discussionInFeed = (Discussion)postInFeed;
                        if (discussionInFeed.GetDiscussionId() == discussionToAdd.GetDiscussionId())
                        {
                            // If the discussion is already saved, don't add it again
                            // Simply leave this method
                            return;
                        }
                    }
                }

                // Add the discussion to the SavedPage.
                AddToTop(discussionToAdd);
            }
            else if (post.GetType() == typeof(Photo))
            {
                // Cast the post properly
                Photo photoToAdd = (Photo)post;
                foreach (UserControl postInFeed in savedFeed.Children)
                {
                    // If a child is the same type as the post being add it, compare them
                    if (postInFeed.GetType() == typeof(Photo))
                    {
                        Photo photoInFeed = (Photo)postInFeed;
                        if (photoInFeed.photoId == photoToAdd.photoId)
                        {
                            // If the photo is already saved, don't add it again
                            // Simply leave this method
                            return;
                        }
                    }
                }

                // Add the photo to the SavedPage.
                AddToTop(photoToAdd);
            }

            emptyMessage.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Shifts children down to allow inserting a post at the top.
        /// </summary>
        private void AddToTop(UserControl post)
        {
            UserControl[] postsToShift = new UserControl[savedFeed.Children.Count + 1];
            savedFeed.Children.CopyTo(postsToShift, 0);
            savedFeed.Children.Clear();

            for (int i = postsToShift.Length - 2; i >= 0; i--)
            {
                postsToShift[i + 1] = postsToShift[i];
            }

            if (post.GetType() == typeof(Discussion))
            {
                Discussion castedPost = (Discussion)post;
                castedPost.main = this.parent;
                castedPost.MouseLeftButtonDown += ClickPost;
                postsToShift[0] = castedPost;
            }
            else if (post.GetType() == typeof(Photo))
            {
                Photo castedPost = (Photo)post;
                castedPost.main = this.parent;
                castedPost.MouseLeftButtonDown += ClickPost;
                postsToShift[0] = castedPost;
            }

            for (int i = 0; i < postsToShift.Length; i++)
            {
                savedFeed.Children.Add(postsToShift[i]);
            }
        }

        public void RemovePost(UserControl post)
        {
            UserControl[] posts = new UserControl[savedFeed.Children.Count];
            savedFeed.Children.CopyTo(posts, 0);

            // Check the type of the post to add
            if (post.GetType() == typeof(Discussion))
            {
                // Cast the post properly
                Discussion discussionToRemove = (Discussion)post;

                // Look through the children of the saved page
                foreach (UserControl postInFeed in posts)
                {
                    // If a child is the same type as the post being removed, compare them
                    if (postInFeed.GetType() == typeof(Discussion))
                    {
                        Discussion discussionInFeed = (Discussion)postInFeed;
                        if (discussionInFeed.GetDiscussionId() == discussionToRemove.GetDiscussionId())
                        {
                            // If the discussion is saved, remove it
                            savedFeed.Children.Remove(discussionInFeed);
                        }
                    }
                }
            }
            else if (post.GetType() == typeof(Photo))
            {
                // Cast the post properly
                Photo photoToRemove = (Photo)post;
                foreach (UserControl postInFeed in posts)
                {
                    // If a child is the same type as the post being add it, compare them
                    if (postInFeed.GetType() == typeof(Photo))
                    {
                        Photo photoInFeed = (Photo)postInFeed;
                        if (photoInFeed.photoId == photoToRemove.photoId)
                        {
                            // If the photo is saved, remove it
                            savedFeed.Children.Remove(photoInFeed);
                        }
                    }
                }
            }

            if (savedFeed.Children.Count == 0)
            {
                emptyMessage.Visibility = Visibility.Visible;
            }
        }

        private void MakePostClickable(UserControl post)
        {
            post.MouseLeftButtonDown += ClickPost;
        }

        private void ClickPost(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(Discussion))
            {
                Discussion temp = (Discussion)sender;
                DiscussionPopup discussionPopup = new DiscussionPopup(parent, temp);
                discussionPopup.SetValue(Grid.RowProperty, 2);
                discussionPopup.SetValue(Grid.ColumnSpanProperty, 3);
                parent.mainGrid.Children.Add(discussionPopup);
            }
            else if (sender.GetType() == typeof(Photo))
            {
                Photo temp = (Photo)sender;
                PhotoPopup photoPopup = new PhotoPopup(parent, temp);
                photoPopup.SetValue(Grid.RowProperty, 2);
                photoPopup.SetValue(Grid.ColumnSpanProperty, 3);
                parent.mainGrid.Children.Add(photoPopup);
            }
        }
    }
}
