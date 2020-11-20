using SyncAsyncParallel.Class;
using System.Net;
using System.Threading.Tasks;

namespace SyncAsyncParallel.Methods
{
    public class ASync
    {
        public static async Task<WebSiteDataModel> DownloadWebSiteASync(string webSiteUrl)
        {
            return new WebSiteDataModel()
            {
                WebSiteUrl = webSiteUrl,
                WebSiteData = await new WebClient().DownloadStringTaskAsync(webSiteUrl)
            };
        }
    }
}
