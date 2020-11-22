using SyncAsyncParallelConsole.Class;
using SyncAsyncParallelConsole.Methods;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SyncAsyncParallelConsole
{
    class Program
    {
        public static int TestLenght { get; set; } = 10;

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            var ct = new CancellationTokenSource();

            Console.WriteLine("Sync, Async and Parallel Console Test");
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("1 - Sync");
            Console.WriteLine("2 - Async");
            Console.WriteLine("3 - ParallelSync");
            Console.WriteLine("4 - ParallelAsync");

            Console.WriteLine("Any Other - Exit");

            var key = Console.ReadLine();

            Action method = key switch
            {
                "1" => () => Logging(Sync.RunDownloadSync()),
                "2" => async () => Logging(await Async.RunDownloadAsync(ct.Token)),
                "3" => () => Logging(ParallelSync.RunDownloadParallelSync()),
                "4" => async () => Logging(await ParallelAsync.RunDownloadParallelASync(ct.Token)),
                _ => null
            };
            if (method != null)
            {
                method.Invoke();
                Menu();
            }
        }

        public static void Logging(IEnumerable<WebSiteDataModel> webSites)
        {
            foreach (var webSite in webSites)
                Console.WriteLine($"{webSite.WebSiteUrl} downloaded: {webSite.WebSiteData.Length} characters long.");
        }

    }
}
