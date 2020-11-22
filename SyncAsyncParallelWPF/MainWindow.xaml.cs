using SyncAsyncParallelWPF.Class;
using SyncAsyncParallelWPF.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;

namespace SyncAsyncParallel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Diagnostics.Stopwatch watch;
        IEnumerable<WebSiteDataModel> results;

        CancellationTokenSource cts = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            InitTest("SYNC");

            results = Sync.RunDownloadSync();

            EndTest();
        }

        private async void btnAsync_Click(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress;

            InitTest("ASYNC");

            results = await Async.RunDownloadAsync(progress, cts.Token);

            EndTest();

        }

        private void btnParallelSync_Click(object sender, RoutedEventArgs e)
        {
            InitTest("PARALLEL SYNC");

            results = ParallelSync.RunDownloadParallelSync();

            EndTest();
        }

        private async void btnParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress;

            InitTest("PARALLEL ASYNC");

            results = await ParallelAsync.RunDownloadParallelASync(progress, cts.Token);

            EndTest();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
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
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            PrintResults(results);

            if (cts.IsCancellationRequested)
            {
                txtContantDownloadProgress.Text += $"The async download was cancelled.{Environment.NewLine}";
                cts = new CancellationTokenSource();
            }

            txtContantDownloadProgress.Text += $"Total execution time: {elapsedMs}";

            ButtonSwitch(true);
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            pgbContantDownload.Value = e.PorcentageComplete;
            PrintResults(e.SitesDowloaded);
        }

        private void PrintResults(IEnumerable<WebSiteDataModel> list)
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
