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
    /// Interaction logic for PostDiscussionPopup.xaml
    /// </summary>
    public partial class PostDiscussionPopup : UserControl
    {
        MainWindow parent;

        public PostDiscussionPopup()
        {
            InitializeComponent();
        }

        public PostDiscussionPopup(MainWindow main)
        {
            InitializeComponent();

            parent = main;
            parent.ChangeFill(Visibility.Visible);

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(CancelPostDiscussionButton))
            {
                PostCancelPrompt prompt = new PostCancelPrompt(this);
                prompt.ShowDialog();
                //parent.ChangeFill(Visibility.Hidden);
                //this.Visibility = Visibility.Hidden;
            }
            else if (sender.Equals(ConfirmPostDiscussionButton))
            {
                bool isComplete = true;
                // check if all fields are filled in
                if (AddDiscussionTitleBox.Text.Equals(""))
                {
                    AddDiscussionTitleDefault.Foreground = new SolidColorBrush(Colors.Red);
                    isComplete = false;
                }
                if (AddDiscussionDescriptionBox.Text.Equals(""))
                {
                    AddDiscussionDescriptionDefault.Foreground = new SolidColorBrush(Colors.Red);
                    isComplete = false;
                }
                if (isComplete)
                {
                    parent.AddDiscussion(new Discussion(parent.currDiscussionPage.GetDiscussionIdCtr(), parent.currUser.UserName, AddDiscussionTitleBox.Text, AddDiscussionDescriptionBox.Text, 0, true));
                    parent.ChangeFill(Visibility.Hidden);
                    this.Visibility = Visibility.Hidden;
                }
            }
        }

        public void Cancel()
        {
            parent.ChangeFill(Visibility.Hidden);
            this.Visibility = Visibility.Hidden;
        }
    }
}
