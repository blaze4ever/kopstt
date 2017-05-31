namespace Kopstt.Modules
{
    using System.Windows;

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

        private void createDatabase(object sender, RoutedEventArgs e)
        {
           // _db.dbInit(local_database_name.Text);
        }
    }
}
