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
    /// Interaction logic for MessageNotification.xaml
    /// </summary>
    public partial class MessageNotification : UserControl
    {
        public MessageNotification()
        {
            InitializeComponent();
        }

        public MessageNotification(string message, string date)
        {
            InitializeComponent();

            MessageContent.Text = message;

            DateReceived.Text = date;
        }
    }
}
