using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace Fat.Quotes.Google
{
    public class GoogleSummaryProvider
    {
        private const string BaseUrl = @"https://www.google.com/finance?q=ASX:{0}";

        public SummaryDto Get(string stockCode)
        {
            using (var client = new WebClient())
            {
                var html = client.DownloadString(string.Format(BaseUrl, stockCode));
                var htmlDocument = new HtmlDocument();

                htmlDocument.LoadHtml(html);

                var table = GetSummaryTable(htmlDocument);

                if (table == null) return null;

                var rows = GetRows(table);
                return GetScrapedSummary(rows);

            }
        }

        private SummaryDto GetScrapedSummary(IEnumerable<string[][]> rows)
        {
            var summary = new SummaryDto();

            foreach (var row in rows)
            {
                if (row.Count() != 1)
                    continue;

                if (row[0].Count() != 7)
                    continue;

                var index = 0;

                foreach (var cell in row[0])
                {
                    var value = cell;

                    if (value == "-") value = "0";

                    //switch (index)
                    //{
                        //case 0:
                        //    summary.Date = value;
                        //    break;
                        //case 1:
                        //    summary.Open = value.Replace(",", "");
                        //    break;
                        //case 2:
                        //    summary.High = value.Replace(",", "");
                        //    break;
                        //case 3:
                        //    summary.Low = value.Replace(",", "");
                        //    break;
                        //case 4:
                        //    summary.Close = value.Replace(",", "");
                        //    break;
                        //case 5:
                        //    summary.Volume = value.Replace(",", "");
                        //    break;
                    //}

                    index++;
                }
            }

            return summary;
        }

        private IEnumerable<string[][]> GetRows(HtmlDocument table)
        {
            return table.DocumentNode.Descendants("tr").Select(n => n.Elements("td").Select(e => e.InnerText.Split(new [] { "\n" }, StringSplitOptions.None)).ToArray());
        }

        private HtmlDocument GetSummaryTable(HtmlDocument htmlDocument)
        {
            var table = htmlDocument.DocumentNode.SelectNodes("//*[contains(@class,'historical_price')]");

            if (table == null) return null;

            var firstTable = table.FirstOrDefault();

            if (firstTable == null) return null;

            var d = new HtmlDocument();

            d.LoadHtml(firstTable.InnerHtml.Replace("<tr", "</tr><tr"));

            return d;
        }
    }
}
