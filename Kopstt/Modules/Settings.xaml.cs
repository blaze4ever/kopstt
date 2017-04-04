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

namespace Kopstt.Modules
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings
    {
        public Settings()
        {
            InitializeComponent();

            checkSlack();
        }

        private void saveUrl(object sender, RoutedEventArgs e)
        {

        }

        private void setSlack(object sender, RoutedEventArgs e)
        {
            checkSlack();
        }

        private void checkSlack()
        {
            Slack_Settings.Visibility = Check_Slack.IsChecked == false ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
