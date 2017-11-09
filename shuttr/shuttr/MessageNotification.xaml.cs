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

        /// <summary>
        /// Creates a new MessageNotification with the specified parameters.
        /// </summary>
        /// <param name="status"> Whether or not the message is read </param>
        /// <param name="sender"> The name of the sender </param>
        /// <param name="message"> The message to be displayed in the preview </param>
        /// <param name="date"> The date or time the message was received </param>
        public MessageNotification(bool status, string sender, string message, string date)
        {
            InitializeComponent();

            if (!status)
            {
                senderName.FontWeight = FontWeights.Normal;
                messageContent.FontWeight = FontWeights.Normal;
                dateReceived.FontWeight = FontWeights.Normal;
            }

            senderName.Text = sender;

            messageContent.Text = message;

            dateReceived.Text = date;
        }
    }
}
