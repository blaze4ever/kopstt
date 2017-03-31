using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Controls;
using Kopstt.Modules;

namespace Kopstt
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;
    using Autofac;
    using Classes;
    using Classes.SwitchingModules;

    public partial class MainWindow
    {
        private readonly SetOnStartup _addToRegistry;
        DataTable auxTable;
        private BackgroundWorker worker;
        private Today _today;
        private Inbox _inbox;
        private SevenDays _7days;
        private DependencyObject current_module;
        private FadeAnimation _fade;
        private ClearModules _clear;

        public MainWindow(SetOnStartup add_to_registry, 
                            Today today,
                            Inbox inbox,
                            SevenDays seven_days,
                            FadeAnimation fade,
                            ClearModules clear)
        {
            InitializeComponent();

            _fade = fade;
            _clear = clear;
            _addToRegistry = add_to_registry;


            _today = today;
            _inbox = inbox;
            _7days = seven_days;

            current_module = _today;

            //Content.Content = current_module;

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
           // Progress.Value = e.ProgressPercentage;
        }

       
        private void pickMenuItem(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var menu = sender as StackPanel;
            if (menu != null)
            {
                menu.Style = FindResource("PickedMenu") as Style;
                var module = menu.DataContext.ToString();
                if (module == "Inbox")
                {
                    animateContent(_inbox);

                }
                else if (module == "Today")
                {
                    animateContent(_today);
                }
                else if (module == "7days")
                {
                    animateContent(_7days);
                }

               // Content.Content = current_module;
            }
        }

       
        private void animateContent(DependencyObject _new_module)
        {
         //   _fade.CreateFade(1, 0, current_module);
         //   _fade.CreateFade(0, 1, _new_module);

        //    current_module = _new_module;
        }

    }
}
