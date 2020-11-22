using System.Collections.Generic;
using System.Linq;

namespace SyncAsyncParallelWPF.Class
{
    public class ProgressReportModel
    {
        public int PorcentageComplete { get; private set; } = 0;
        public IEnumerable<WebSiteDataModel> SitesDowloaded { get; private set; } = new List<WebSiteDataModel>();

        public void SetSitesDowloaded(IEnumerable<WebSiteDataModel> sitesDownloaded) =>
            SitesDowloaded = sitesDownloaded;

        public void SetPorcentage<T>(IEnumerable<T> webSites) =>
            PorcentageComplete = (SitesDowloaded.Count() * 100) / webSites.Count();
    }
}
