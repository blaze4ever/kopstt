using System.Windows;
using MahApps.Metro.Controls.Dialogs;

namespace Kopstt.Classes
{
    class ShowMessage
    {
        internal async void ShowMessageDialog(object sender, RoutedEventArgs e, MainWindow main)
        {
            MessageDialogResult result = await main.ShowMessageAsync("", "Task added successfully", MessageDialogStyle.Affirmative);
           // await main.ShowMessageAsync("Result", "You click " + result, MessageDialogStyle.Affirmative);
        }
    }
}
