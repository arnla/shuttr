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
using System.Windows.Shapes;

namespace shuttr
{
    /// <summary>
    /// Interaction logic for MessageDevelopmentPrompt.xaml
    /// </summary>
    public partial class MessageDevelopmentPrompt : Window
    {
        ProfilePageOtherUser parent;

        public MessageDevelopmentPrompt(ProfilePageOtherUser parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        public void SetMessage(string messageToDisplay)
        {
            message.Text = messageToDisplay;
        }

        public void SetCancelText(string cancelText)
        {
            cancelButton.Content = cancelText;
        }

        /// <summary>
        /// Interaction logic for closing popup prompt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.OnCloseMessagePrompt();
        }

        /// <summary>
        /// Interaction logic for clicking the cancel confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.OnCloseMessagePrompt();
        }
    }
}
