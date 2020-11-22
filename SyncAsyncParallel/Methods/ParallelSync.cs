using SyncAsyncParallel.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncAsyncParallel.Methods
{
    public class ParallelSync
    {
        public static IEnumerable<WebSiteDataModel> RunDownloadParallelSync()
        {
            var output = new List<WebSiteDataModel>();
            Parallel.ForEach(Shared.GetTestsPages(), (page) =>
            {
                output.Add(Shared.DownloadWebSiteSync(page));
            });

            return output;
        }
    }
}
