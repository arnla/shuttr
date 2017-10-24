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
        }

        public void PhotoClick(object sender, MouseButtonEventArgs e)
        {
            /*
            if (sender.Equals(Image1))
            {
                ImageViewDock.Children.Add(new Image());
                ImageView.IsOpen = !ImageView.IsOpen;
            }
            else if (sender.Equals(Image2))
            {
                ImageViewDock.Children.Add(Image2);
                ImageView.IsOpen = !ImageView.IsOpen;
            }*/
        }
    }
}
