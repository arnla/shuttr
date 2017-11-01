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
    /// Interaction logic for DiscussionPage.xaml
    /// </summary>
    public partial class MessagingPage : UserControl
    {
        public MessagingPage()
        {
            InitializeComponent();

            FillMessages();
        }

        private void FillMessages()
        {
            string user2 = "Other User";
            string user1 = "User 1";
            MessageThread.Children.Add(new Message(true, user1, "Hello! My name is Derrick. I saw your designs and was really interested if we could collaborate together.", "3:04pm"));
            MessageThread.Children.Add(new Message(false, user2, "Okay, sure.", "3:04pm"));
            MessageThread.Children.Add(new Message(true, user1, "I am in the YYC area tomorrow, let's go shoot at the Peace Bridge?", "3:04pm"));
            MessageThread.Children.Add(new Message(false, user2, "Peace Bridge? I'd rather get on a roof of a building.", "3:04pm"));
            MessageThread.Children.Add(new Message(true, user1, "And shoot pictures of our shoes hanging off the ends?", "3:04pm"));
            MessageThread.Children.Add(new Message(false, user2, "Yeah...", "3:04pm"));
            MessageThread.Children.Add(new Message(true, user1, "Alright, I'm down for that.", "3:04pm"));
            MessageThread.Children.Add(new Message(false, user2, "Let's go grab some village ice cream after and shoot a pic with the logo.", "3:04pm"));
        }

        public void Text_Changed(object sender, EventArgs e)
        { }
    }
}
