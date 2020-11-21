using SyncAsyncParallel.Class;
using System.Collections.Generic;
using System.Net;

namespace SyncAsyncParallel.Methods
{
    public class Sync
    {
        public static IEnumerable<WebSiteDataModel> RunDownloadSync()
        {
            var output = new List<WebSiteDataModel>();
            foreach (var page in Shared.GetTestsPages())
                output.Add(DownloadWebSiteSync(page));

            return output;
        }

        public static WebSiteDataModel DownloadWebSiteSync(string webSiteUrl)
        {
            return new WebSiteDataModel()
            {
                WebSiteUrl = webSiteUrl,
                WebSiteData = new WebClient().DownloadString(webSiteUrl)
            };
        }
    }
}


// ORIGINAL
//var output = new WebSiteDataModel();
//var client = new WebClient();

//output.WebSiteUrl = webSiteUrl;
//output.WebSiteData = client.DownloadString(webSiteUrl);

//return output;
