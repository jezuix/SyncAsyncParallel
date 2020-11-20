using System;
using System.Collections;
using System.Collections.Generic;

namespace SyncAsyncParallel.Methods
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

        public static string BrokenLines(IEnumerable<string> list)
        {
            return string.Join(Environment.NewLine, list);
        }
    }
}
