using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using Kopstt.Core.Database;
using Kopstt.Core.Database.Models;
using Kopstt.Core.Database.Repositories;
using Kopstt.Modules;
using NHibernate.Tool.hbm2ddl;

namespace Kopstt
{
    using System;
    using System.Windows;
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
        private NHibernateJobRepository _jobRepostiory;
        private ShowMessage dialog;

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

            worker = new BackgroundWorker {WorkerReportsProgress = true};
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            var schemaUpdate = new SchemaUpdate(NHibernateHelper.Configuration);
            schemaUpdate.Execute(false, true);
            _jobRepostiory = new NHibernateJobRepository();
            dialog = new ShowMessage();

        }


        private async void sendSlackMessage(object sender, RoutedEventArgs e)
        {
            var url = "https://hooks.slack.com/services/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";
            var webhookUrl = new Uri(url);
            var slackClient = new SlackClient(webhookUrl);
            //var message = Message.Text;
            //var response = await slackClient.SendMessageAsync(message);
            //if (!response.IsSuccessStatusCode)
           // {
           //     Console.WriteLine("Cannot send message to slack");
          //  }
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

       
        private void pickMenuItem(object sender, MouseButtonEventArgs e)
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
            _fade.CreateFade(1, 0, current_module);
            _fade.CreateFade(0, 1, _new_module);

            current_module = _new_module;
        }

        private void openSettings(object sender, MouseButtonEventArgs e)
        {
            Menu.SelectedIndex = 0;
            var settings = new Settings();
            settings.ShowDialog();
        }

        private void CancelAdding(object sender, MouseButtonEventArgs e)
        {
            Adding_Task_Holder.Visibility = Visibility.Collapsed;
            Task_Content.Text = string.Empty;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            var job = new Job
            {
                name = Task_Content.Text,
                added = DateTime.Now,
                archived = false,
                category = 1,
                done = false,
                execution = DateTime.Now,
                priority = 1
            };

            _jobRepostiory.Save(job);
            var result = _jobRepostiory.IsProcessed();


            if(result)
            {
                dialog.ShowMessageDialog(this, null, this);
            }
        }

        private void TaskAddingInit(object sender, MouseButtonEventArgs e)
        {
            Adding_Task_Holder.Visibility = Visibility.Visible;
            Task_Content.Focus();
        }
    }
}
