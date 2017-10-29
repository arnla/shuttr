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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = new PhotosPage();
            //PhotosTab.Foreground = new SolidColorBrush(Color.FromRgb(116, 118, 119));
        }

        protected void Button_Click(Object sender, EventArgs e)
        {
            // Some stuff happens here.
            if (sender.Equals(PhotosTab))
            {
                contentControl.Content = new PhotosPage();
            }
            else if (sender.Equals(DiscussionsTab))
            {
                contentControl.Content = new DiscussionPage();
            }
            else if (sender.Equals(SavedTab))
            {
                contentControl.Content = new SavedPage();
            }
            else if (sender.Equals(PostButton))
            {
                PostButtonDropdown.IsOpen = !PostButtonDropdown.IsOpen;
            }
            else if (sender.Equals(NotificationsButton))
            {
                NotificationsButtonDropdown.IsOpen = !NotificationsButtonDropdown.IsOpen;
            }
            else if (sender.Equals(MessagesButton))
            {
                MessagesButtonDropdown.IsOpen = !MessagesButtonDropdown.IsOpen;
            }
            else if (sender.Equals(AccountButton))
            {
                contentControl.Content = new ProfilePage();
            }
            else if (sender.Equals(Message1))
            {
                contentControl.Content = new MessagingPage();
            }
            else if (sender.Equals(SeeAllMessagesButton))
            {
                contentControl.Content = new MessagesPage();
            }
        }
    }
}
