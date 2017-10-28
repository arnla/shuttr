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
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        public Notification()
        {
            InitializeComponent();
        }

        public Notification(bool read, string notification, string date)
        {
            InitializeComponent();

            if (!read)
            {
                ReadStatus.Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
            }

            NotificationContent.Text = notification;

            DateReceived.Text = date;
        }
    }
}
