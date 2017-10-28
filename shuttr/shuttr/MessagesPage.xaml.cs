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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MessagesPage : UserControl
    {
        public MessagesPage()
        {
            InitializeComponent();
        }

        protected void Button_Click(Object sender, EventArgs e)
        {
            // Some stuff happens here.
            if (sender.Equals(CancelPostPhotoButton))
            {
                MessagesPageFill.Fill = new SolidColorBrush(Colors.Transparent);
                NewPhotoFromMessages.IsOpen = false;
            }
        }
    }
}
