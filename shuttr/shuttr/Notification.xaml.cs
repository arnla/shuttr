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

        /// <summary>
        /// Creates a new notification with the specified attributes.
        /// </summary>
        /// <param name="read"> Whether or not the notification is read </param>
        /// <param name="message"> The message the notification will contain </param>
        /// <param name="date"> The age of the notification (e.g. 17h) </param>
        public Notification(bool read, string message, string date)
        {
            InitializeComponent();

            if (!read)
            {
                readStatus.Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
            }

            notificationContent.Text = message;

            dateReceived.Text = date;
        }
    }
}
