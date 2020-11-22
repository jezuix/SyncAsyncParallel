using SyncAsyncParallelConsole.Class;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SyncAsyncParallelConsole.Methods
{
    public class Async
    {
        public static async Task<IEnumerable<WebSiteDataModel>> RunDownloadAsync(CancellationToken cancellationToken)
        {
            var websites = Shared.GetTestsPages();
            var output = new List<WebSiteDataModel>();
            try
            {
                foreach (var page in websites)
                {
                    output.Add(await Shared.DownloadWebSiteAsync(page));

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
