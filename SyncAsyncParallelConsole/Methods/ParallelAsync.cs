using SyncAsyncParallelConsole.Class;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SyncAsyncParallelConsole.Methods
{
    public class ParallelAsync
    {
        public static async Task<IEnumerable<WebSiteDataModel>> RunDownloadParallelASync(CancellationToken cancellationToken)
        {
            var websites = Shared.GetTestsPages();
            var output = new List<WebSiteDataModel>();
            await Task.Run(() =>
            {
                Parallel.ForEach(websites, (page) =>
                {
                    try
                    {
                        output.Add(Shared.DownloadWebSiteSync(page));

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

//await Task.Run(() =>
//{
//    Parallel.ForEach(websites, async (page) =>
//    {
//        try
//        {
//            output.Add(await Shared.DownloadWebSiteAsync(page));

//            report.SetSitesDowloaded(output);
//            report.SetPorcentage(websites);
//            progress.Report(report);

//            cancellationToken.ThrowIfCancellationRequested();
//        }
//        catch (OperationCanceledException)
//        {
//        }
//    });
//});