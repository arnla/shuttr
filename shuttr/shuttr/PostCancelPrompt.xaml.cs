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
    /// Interaction logic for PostCancelPrompt.xaml
    /// </summary>
    public partial class PostCancelPrompt : Window
    {
        public UserControl parent;

        public PostCancelPrompt(PostPhotoPopup parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        public PostCancelPrompt(PostDiscussionPopup parent)
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
        }

        /// <summary>
        /// Interaction logic for clicking the cancel confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            if (parent.GetType() == typeof(PostDiscussionPopup))
            {
                PostDiscussionPopup castedParent = (PostDiscussionPopup)parent;
                castedParent.Cancel();
            }
            else if (parent.GetType() == typeof(PostPhotoPopup))
            {
                PostPhotoPopup castedParent = (PostPhotoPopup)parent;
                castedParent.Cancel();
            }

            this.Close();
        }
    }
}
