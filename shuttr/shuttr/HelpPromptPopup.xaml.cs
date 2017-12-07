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
    /// Interaction logic for HelpPromptPopup.xaml
    /// </summary>
    public partial class HelpPromptPopup : Window
    {
        UserControl parent;
        MainWindow main;

        public HelpPromptPopup(ProfilePageOtherUser parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        public HelpPromptPopup(MessagesPage parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        public HelpPromptPopup(DiscussionPopup parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        public HelpPromptPopup(PhotoPopup parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        public HelpPromptPopup(MainWindow main)
        {
            InitializeComponent();

            this.main = main;
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

            if (main != null)
            {
                main.OnCloseMessagePrompt();
            }
            else if (parent.GetType() == typeof(ProfilePageOtherUser))
            {
                ProfilePageOtherUser castedParent = (ProfilePageOtherUser)parent;
                castedParent.OnCloseMessagePrompt();
            }
            else if (parent.GetType() == typeof(MessagesPage))
            {
                MessagesPage castedParent = (MessagesPage)parent;
                castedParent.OnCloseMessagePrompt();
            }
        }

        /// <summary>
        /// Interaction logic for clicking the cancel confirmation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();

            if (main != null)
            {
                main.OnCloseMessagePrompt();
            }
            else if (parent.GetType() == typeof(ProfilePageOtherUser))
            {
                ProfilePageOtherUser castedParent = (ProfilePageOtherUser)parent;
                castedParent.OnCloseMessagePrompt();
            }
            else if (parent.GetType() == typeof(MessagesPage))
            {
                MessagesPage castedParent = (MessagesPage)parent;
                castedParent.OnCloseMessagePrompt();
            }
            else if ((parent.GetType() == typeof(PhotoPopup)) || (parent.GetType() == typeof(DiscussionPopup)))
            {
                // Do nothing.
            }
        }
    }
}
