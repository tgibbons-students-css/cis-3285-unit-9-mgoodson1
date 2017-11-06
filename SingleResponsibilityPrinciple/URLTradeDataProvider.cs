using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Policy;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class URLTradeDataProvider : IURLTradeDataProvider
    {
        public URLTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }

        public IEnumerable<string> GetURLTradeData()
        {
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        private readonly Stream stream;
        private string url;
    }
}
