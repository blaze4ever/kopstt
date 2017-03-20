using System.Windows;
using Autofac;
using Kopstt.Core.AutoFac;

namespace Kopstt
{
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var container = DI.CreateBuilder().Build();

            var splash_screen_view = container.Resolve<MainWindow>();

            splash_screen_view.Show();
        }
    }
}
