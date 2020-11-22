using SyncAsyncParallel.Class;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SyncAsyncParallel.Methods
{
    public class ASync
    {
        public static async Task<IEnumerable<WebSiteDataModel>> RunDownloadASync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            var websites = Shared.GetTestsPages();
            var output = new List<WebSiteDataModel>();
            var report = new ProgressReportModel();
            try
            {
                foreach (var page in websites)
                {
                    output.Add(await Shared.DownloadWebSiteAsync(page));

                    report.SetSitesDowloaded(output);
                    report.SetPorcentage(websites);
                    progress.Report(report);

                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
            }

            return output;
        }
    }
}
