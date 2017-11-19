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
    /// Interaction logic for DiscussionPopup.xaml
    /// </summary>
    public partial class DiscussionPopup : UserControl
    {
        MainWindow parent;

        public DiscussionPopup()
        {
            InitializeComponent();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        public DiscussionPopup(MainWindow main, Discussion sender)
        {
            InitializeComponent();

            parent = main;
            parent.ChangeFill();

            Username.Text = sender.GetUser();
            DiscussionTitle.Text = sender.GetTitle();
            NumRepliesButton.Content = sender.GetNumReplies();

            window.Height = System.Windows.SystemParameters.PrimaryScreenHeight * 0.6;
            window.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 0.6;
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(CloseDiscussionButton))
            {
                parent.ChangeFill();
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
