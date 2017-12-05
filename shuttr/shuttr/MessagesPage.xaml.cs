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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MessagesPage : UserControl
    {
        MainWindow main;

        public MessagesPage(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        public void MessageClick(object sender, RoutedEventArgs e)
        {
            MessageDevelopmentPrompt prompt = new MessageDevelopmentPrompt(this);
            main.ChangeFill(Visibility.Visible);
            prompt.ShowDialog();
        }

        public void OnCloseMessagePrompt()
        {
            main.ChangeFill(Visibility.Hidden);
        }
    }
}
