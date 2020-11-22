using SyncAsyncParallelConsole.Class;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SyncAsyncParallelConsole.Methods
{
    public static class Shared
    {
        public static IList<string> GetTestsPages()
        {
            return new List<string>
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.cnn.com",
                "https://www.amazon.com",
                "https://www.facebook.com",
                "https://www.twitter.com",
                "https://www.codeproject.com",
                "https://www.stackoverflow.com",
                "https://pt.wikipedia.org/wiki/.NET_Framework",
                "https://g1.globo.com/",
                "https://www.linkedin.com/feed/"
            };
        }

        public static WebSiteDataModel DownloadWebSiteSync(string webSiteUrl)
        {
            return new WebSiteDataModel()
            {
                WebSiteUrl = webSiteUrl,
                WebSiteData = new WebClient().DownloadString(webSiteUrl)
            };
        }

        public static async Task<WebSiteDataModel> DownloadWebSiteAsync(string webSiteUrl)
        {
            return new WebSiteDataModel()
            {
                WebSiteUrl = webSiteUrl,
                WebSiteData = await new WebClient().DownloadStringTaskAsync(webSiteUrl)
            };
        }
    }
}
