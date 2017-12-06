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
    /// Interaction logic for SearchResultsPageEmpty.xaml
    /// </summary>
    public partial class SearchResultsPageEmpty : UserControl
    {
        private MainWindow parent;

        public SearchResultsPageEmpty(MainWindow main, string query)
        {
            InitializeComponent();

            parent = main;

            currentFilterOption.Content = filterAll.Content;
            currentSortOption.Content = sortPopular.Content;

            search.Content = query;
        }

        public void SortClick(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(sortByMenu) || sender.Equals(currentSortOption))
            {
                sortByDropdown.IsOpen = !sortByDropdown.IsOpen;
            }
            else if (sender.Equals(sortPopular))
            {
                currentSortOption.Content = sortPopular.Content;
                sortByDropdown.IsOpen = false;
            }
            else if (sender.Equals(sortNew))
            {
                currentSortOption.Content = sortNew.Content;
                sortByDropdown.IsOpen = false;
            }
            else if (sender.Equals(sortMostCommented))
            {
                currentSortOption.Content = sortMostCommented.Content;
                sortByDropdown.IsOpen = false;
            }
            else if (sender.Equals(sortMostUpvoted))
            {
                currentSortOption.Content = sortMostUpvoted.Content;
                sortByDropdown.IsOpen = false;
            }
        }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(filterByMenu) || sender.Equals(currentFilterOption))
            {
                filterByDropdown.IsOpen = !filterByDropdown.IsOpen;
            }
            else if (sender.Equals(filterAll))
            {
                currentFilterOption.Content = filterAll.Content;
                filterByDropdown.IsOpen = false;
            }
            else if (sender.Equals(filterPhotos))
            {
                currentFilterOption.Content = filterPhotos.Content;
                filterByDropdown.IsOpen = false;
            }
            else if (sender.Equals(filterDiscussions))
            {
                currentFilterOption.Content = filterDiscussions.Content;
                filterByDropdown.IsOpen = false;
            }
        }
    }
}
