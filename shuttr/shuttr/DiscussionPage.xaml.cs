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
    /// Interaction logic for DiscussionPage.xaml
    /// </summary>
    public partial class DiscussionPage : UserControl
    {
        public DiscussionPage()
        {
            InitializeComponent();
        }

        private void DiscussionClick(object sender, MouseButtonEventArgs e)
        {
            if (sender.Equals(Discussion1))
            {
                DiscussionPage popUp = new DiscussionPage();
                popUp.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                popUp.popUpPageFill.Visibility = Visibility.Visible;
                DiscussionContentControl.Content = popUp;
                popUp.DiscussionPopUpWindow.IsOpen = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
