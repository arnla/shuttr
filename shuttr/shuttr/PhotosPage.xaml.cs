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
        public PhotosPage()
        {
            InitializeComponent();
            //imageContentControl.Content = new PhotosPage();
        }

        /// <summary>
        /// Handles a clicked photo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PhotoClick(object sender, MouseButtonEventArgs e)
        {
            if (sender.Equals(Image2))
            {
                PhotosPage popUp = new PhotosPage();
                popUp.popUpPageFill.Fill = new SolidColorBrush(Colors.Black);
                popUp.popUpPageFill.Visibility = Visibility.Visible;
                popUp.PhotoPopUpWindow.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
                popUp.PhotoPopUpWindow.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
                imageContentControl.Content = popUp;
                popUp.PhotoPopUpWindow.IsOpen = true;
            }
        }

        private void MessageButton(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
