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
    /// Interaction logic for FollowingPage.xaml
    /// </summary>
    public partial class FollowingPage : UserControl
    {
        public FollowingPage()
        {
            InitializeComponent();

            AddDiscussionPostsTest();
        }

        private void AddDiscussionPostsTest()
        {
            followingFeed.Children.Add(new Discussion("Anonymoose", "A nice title", 500));
            followingFeed.Children.Add(new Discussion("Admin", "Not a nice title", 1));
        }
    }
}
