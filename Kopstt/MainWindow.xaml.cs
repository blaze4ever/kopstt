using Kopstt.Classes;

namespace Kopstt
{
    using System.Windows;

    public partial class MainWindow : Window
    {
        private readonly SetOnStartup _addToRegistry;

        public MainWindow(SetOnStartup add_to_registry)
        {
            _addToRegistry = add_to_registry;
            InitializeComponent();
        }

        private void addToRegistry(object sender, RoutedEventArgs e)
        {
            _addToRegistry.AppName = "kopstt_test";
            _addToRegistry.ExecutablePath = "kopstt.exe";
            _addToRegistry.setAppOnStartup(true);
        }
    }
}
