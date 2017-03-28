using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Controls;
using Kopstt.Classes;
using Kopstt.Modules;

namespace Kopstt
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;

    public partial class MainWindow
    {
        private readonly SetOnStartup _addToRegistry;
        DataTable auxTable;
        private BackgroundWorker worker;
        private Today _today;
        private Inbox _inbox;
        private SevenDays _7days;
        private DependencyObject current_module;
        public MainWindow(SetOnStartup add_to_registry)
        {
            _addToRegistry = add_to_registry;
            InitializeComponent();

            _today = new Today();
            _inbox = new Inbox();
            _7days = new SevenDays();

            current_module = _today;

            Content.Content = current_module;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void addToRegistry(object sender, RoutedEventArgs e)
        {
            _addToRegistry.AppName = "kopstt_test";
            _addToRegistry.ExecutablePath = "kopstt.exe";
            _addToRegistry.setAppOnStartup(true);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Title += " DONE";
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int j = 0; j <= 100; j++)
            {
                worker.ReportProgress(j);
                Thread.Sleep(50);
            }
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress.Value = e.ProgressPercentage;
        }

        private void clearPickedMenu()
        {
            foreach (StackPanel menu_item in Menu.Children)
            {
                menu_item.Style = FindResource("MenuItem") as Style;
            }
        }

        private void pickMenuItem(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            clearPickedMenu();
            var menu = sender as StackPanel;
            if (menu != null)
            {
                menu.Style = FindResource("PickedMenu") as Style;
                var module = menu.DataContext.ToString();
                if (module == "Inbox")
                {
                    CreateFade(1, 0, current_module);
                    CreateFade(0, 1, _inbox);

                    current_module = _inbox;

                }
                else if (module == "Today")
                {
                    CreateFade(1, 0, current_module);
                    CreateFade(0, 1, _today);

                    current_module = _today;
                }
                else if (module == "7days")
                {
                    CreateFade(1, 0, current_module);
                    CreateFade(0, 1, _7days);

                    current_module = _7days;
                }

                Content.Content = current_module;

            }
        }

        private void animateContent(object sender, DependencyPropertyChangedEventArgs e)
        {
            CreateFade(1, 0, _inbox);
            CreateFade(0, 1, _today);
        }

        private void CreateFade(double from, double to, DependencyObject element)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(3));
            da.From = from;
            da.To = to;
            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));

            Storyboard sb = new Storyboard();
            sb.Children.Add(da);
            sb.Begin();

        }

    }
}
