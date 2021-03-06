﻿using SyncAsyncParallelWPF.Class;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SyncAsyncParallelWPF.Methods
{
    public class ParallelAsync
    {
        public static async Task<IEnumerable<WebSiteDataModel>> RunDownloadParallelASync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            var websites = Shared.GetTestsPages();
            var output = new List<WebSiteDataModel>();
            var report = new ProgressReportModel();
            await Task.Run(() =>
            {
                Parallel.ForEach(websites, (page) =>
                {
                    try
                    {
                        output.Add(Shared.DownloadWebSiteSync(page));

                        report.SetSitesDowloaded(output);
                        report.SetPorcentage(websites);
                        progress.Report(report);

                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    catch (OperationCanceledException)
                    {
                    }
                });
            }, cancellationToken);

            return output;
        }


        public static async Task<IEnumerable<WebSiteDataModel>> RunDownloadParallelASync2(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            var websites = Shared.GetTestsPages();
            var output = new List<WebSiteDataModel>();
            var report = new ProgressReportModel();
            await Task.Run(() =>
            {
                Parallel.ForEach(websites, async (page) =>
                {
                    try
                    {
                        output.Add(await Shared.DownloadWebSiteAsync(page));

                        report.SetSitesDowloaded(output);
                        report.SetPorcentage(websites);
                        progress.Report(report);

                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    catch (OperationCanceledException)
                    {
                    }
                });
            }, cancellationToken);

            return output;
        }
    }
}

