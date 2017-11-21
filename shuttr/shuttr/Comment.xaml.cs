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
    /// Interaction logic for Comment.xaml
    /// </summary>
    public partial class Comment : UserControl
    {
        private string username;
        private string comment;

        public Comment()
        {
            InitializeComponent();
        }

        public Comment(string username, string comment)
        {
            InitializeComponent();
            this.username = username;
            this.comment = comment;
            usernameText.Text = username;
            commentBox.Text = comment;
        }
    }
}
