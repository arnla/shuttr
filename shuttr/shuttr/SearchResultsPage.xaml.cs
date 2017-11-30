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
    /// Interaction logic for SearchResultsPage.xaml
    /// </summary>
    public partial class SearchResultsPage : UserControl
    {
        private Photo photo;
        private Discussion discussion;

        public SearchResultsPage()
        {
            InitializeComponent();

            InitializePosts();

            FilterPhotosDiscussions();
        }

        private void InitializePosts()
        {
            photo = new Photo(999, "Images/Mountains.jpg");
            photo.username = "Lean";
            discussion = new Discussion(999, "Emilio", "Good places to take mountain pictures in Alberta?", "I'm visiting Alberta this summer, and was wondering what the best places to take mountain pictures are. Ideally they would be near the Banff area.", 2);
        }

        private void FilterPhotosDiscussions()
        {
            resultsFeed.Children.Clear();
            resultsFeed.Children.Add(photo);
            resultsFeed.Children.Add(discussion);
        }
        
        private void FilterPhotos()
        {
            resultsFeed.Children.Clear();
            resultsFeed.Children.Add(photo);
        }

        private void FilterDiscussions()
        {
            resultsFeed.Children.Clear();
            resultsFeed.Children.Add(discussion);
        }

        public void SortClick(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(sortByMenu))
            {
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortPopular))
            {
                currentSortOption.Content = "Popular";
                sortByDropdown.IsOpen = false;
            }
            else if (sender.Equals(sortNew))
            {
                currentSortOption.Content = "New";
                sortByDropdown.IsOpen = false;
            }
            else if (sender.Equals(sortMostCommented))
            {
                currentSortOption.Content = "Most Commented";
                sortByDropdown.IsOpen = false;
            }
            else if (sender.Equals(sortMostUpvoted))
            {
                currentSortOption.Content = "Most Upvoted";
                sortByDropdown.IsOpen = false;
            }
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(filterByMenu))
            {
                filterByDropdown.IsOpen = !filterByDropdown.IsOpen;
            }
            else if (sender.Equals(filterAll))
            {
                currentFilterOption.Content = filterAll.Content;
                filterByDropdown.IsOpen = false;
                FilterPhotosDiscussions();
            }
            else if (sender.Equals(filterPhotos))
            {
                currentFilterOption.Content = filterPhotos.Content;
                filterByDropdown.IsOpen = false;
                FilterPhotos();
            }
            else if (sender.Equals(filterDiscussions))
            {
                currentFilterOption.Content = filterDiscussions.Content;
                filterByDropdown.IsOpen = false;
                FilterDiscussions();
            }
        }
    }
}
