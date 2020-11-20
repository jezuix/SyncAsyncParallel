using SyncAsyncParallel.Class;
using SyncAsyncParallel.Methods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SyncAsyncParallel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Diagnostics.Stopwatch watch;
        private List<WebSiteDataModel> results;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            InitTest("SYNC");
            foreach (var page in Shared.GetTestsPages())
            {
                results.Add(Sync.DownloadWebSiteSync(page));
            }

            EndTest();
        }

        private async void btnAsync_Click(object sender, RoutedEventArgs e)
        {
            InitTest("ASYNC");
            foreach (var page in Shared.GetTestsPages())
            {
                results.Add(await ASync.DownloadWebSiteASync(page));
            }

            EndTest();
        }

        private void btnParallelSync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnParallelAsync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InitTest(string message)
        {
            txtContantDownloadProgress.Text = message;

            ButtonSwitch(false);
            watch = System.Diagnostics.Stopwatch.StartNew();

            results = new List<WebSiteDataModel>();
        }

        private void EndTest()
        {
            PrintResults(results);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            txtContantDownloadProgress.Text += $"Total execution time: {elapsedMs}";
            ButtonSwitch(true);
        }

        private void PrintResults(IList<WebSiteDataModel> list)
        {
            txtContantDownloadProgress.Text = Shared.BrokenLines(list.Select(x => $"{x.WebSiteUrl} downloaded: {x.WebSiteData.Length} characters long."));
            txtContantDownloadProgress.Text += Environment.NewLine;
            txtContantDownloadProgress.Text += Environment.NewLine;
        }

        private void ButtonSwitch(bool newStats)
        {
            btnSync.IsEnabled = newStats;
            btnAsync.IsEnabled = newStats;
            btnParallelSync.IsEnabled = newStats;
            btnParallelAsync.IsEnabled = newStats;
        }
    }
}
