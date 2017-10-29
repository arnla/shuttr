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
            if (sender.Equals(Image1))
            {
                PopUpPicture popUp = new PopUpPicture();
                //popUp.PhotosPageFill.Fill = new SolidColorBrush(Colors.Black);
                imageContentControl.Content = popUp;
                popUp.PhotoPopUpWindow.IsOpen = true;
            }
        }
    }
}
