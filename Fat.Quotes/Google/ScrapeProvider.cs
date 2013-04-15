using Fat.Services.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Fat.Quotes.Google
{
    public class ScrapeProvider : IQuoteProvider
    {
        private const string LatestBaseUrl = @"https://www.google.com/finance/historical?q=ASX:{0}&p=1D&start=0&num=1";
        private const string RangeBaseUrl = @"https://www.google.com/finance/historical?q=ASX:{0}&p=1D&start=0&num=200&{1}";

        public StockQuote Get(string stockCode)
        {
            using (var client = new WebClient())
            {
                var html = client.DownloadString(string.Format(LatestBaseUrl, stockCode));
                var htmlDocument = new HtmlDocument();

                htmlDocument.LoadHtml(html);

                var table = GetHistoricalPriceTable(htmlDocument);

                if (table == null) return null;

                var rows = GetRows(table);
                var quote = GetScrapedQuotes(rows).FirstOrDefault();

                if (quote == null) return null;

                return new StockQuote(stockCode, Convert.ToDecimal(quote.Close), DateTime.Parse(quote.Date))
                    {
                        Close = Convert.ToDecimal(quote.Close),
                        Open = Convert.ToDecimal(quote.Open),
                        High = Convert.ToDecimal(quote.High),
                        Low = Convert.ToDecimal(quote.Low),
                        Volume = Convert.ToInt32(quote.Volume)
                    };
            }
        }

        private IEnumerable<ScrapeQuoteDto> GetScrapedQuotes(IEnumerable<string[][]> rows)
        {
            var quotes = new List<ScrapeQuoteDto>();

            foreach (var row in rows)
            {
                if (row.Count() != 1)
                    continue;

                if (row[0].Count() != 7)
                    continue;

                var quote = new ScrapeQuoteDto();
                var index = 0;
                var isSkip = false;

                foreach (var cell in row[0])
                {
                    var value = cell;

                    if (index == 4 && (value == "" || value == "-"))
                    {
                        isSkip = true;
                        break;
                    }

                    if (value == "-") value = "0";

                    switch (index)
                    {
                        case 0:
                            quote.Date = value;
                            break;
                        case 1:
                            quote.Open = value.Replace(",", "");
                            break;
                        case 2:
                            quote.High = value.Replace(",", "");
                            break;
                        case 3:
                            quote.Low = value.Replace(",", "");
                            break;
                        case 4:
                            quote.Close = value.Replace(",", "");
                            break;
                        case 5:
                            quote.Volume = value.Replace(",", "");
                            break;
                    }

                    index++;
                }

                if(!isSkip)
                    quotes.Add(quote);
            }

            return quotes;
        }

        private IEnumerable<string[][]> GetRows(HtmlDocument table)
        {
            return table.DocumentNode.Descendants("tr").Select(n => n.Elements("td").Select(e => e.InnerText.Split(new string[] { "\n" }, StringSplitOptions.None)).ToArray());
        }

        private HtmlDocument GetHistoricalPriceTable(HtmlDocument htmlDocument)
        {
            var table = htmlDocument.DocumentNode.SelectNodes("//*[contains(@class,'historical_price')]");
            
            if(table == null) return null;

            var firstTable = table.FirstOrDefault();
            
            if (firstTable == null) return null;

            var d = new HtmlDocument();

            d.LoadHtml(firstTable.InnerHtml.Replace("<tr", "</tr><tr"));
            
            return d;
        }

        public StockQuote Get(string stockCode, DateTime closingDate)
        {
            using (var client = new WebClient())
            {
                var html = client.DownloadString(string.Format(RangeBaseUrl, stockCode, GetPeriod(closingDate, closingDate)));
                var htmlDocument = new HtmlDocument();

                htmlDocument.LoadHtml(html);

                var table = GetHistoricalPriceTable(htmlDocument);

                if (table == null) return null;

                var rows = GetRows(table);
                var quote = GetScrapedQuotes(rows).FirstOrDefault();

                if (quote == null) return null;

                return new StockQuote(stockCode, Convert.ToDecimal(quote.Close), DateTime.Parse(quote.Date))
                {
                    Close = Convert.ToDecimal(quote.Close),
                    Open = Convert.ToDecimal(quote.Open),
                    High = Convert.ToDecimal(quote.High),
                    Low = Convert.ToDecimal(quote.Low),
                    Volume = Convert.ToInt32(quote.Volume)
                };
            }
        }

        public IEnumerable<StockQuote> Get(string stockCode, DateTime openingDate, DateTime closingDate)
        {
            using (var client = new WebClient())
            {
                var html = client.DownloadString(string.Format(RangeBaseUrl, stockCode, GetPeriod(openingDate, closingDate)));
                var htmlDocument = new HtmlDocument();

                htmlDocument.LoadHtml(html);

                var table = GetHistoricalPriceTable(htmlDocument);

                if (table == null) return null;

                var rows = GetRows(table);
                var quotes = GetScrapedQuotes(rows);

                if (quotes == null) return null;

                return quotes.Select(quote => new StockQuote(stockCode, Convert.ToDecimal(quote.Close), DateTime.Parse(quote.Date))
                {
                    Close = Convert.ToDecimal(quote.Close),
                    Open = Convert.ToDecimal(quote.Open),
                    High = Convert.ToDecimal(quote.High),
                    Low = Convert.ToDecimal(quote.Low),
                    Volume = Convert.ToInt32(quote.Volume)
                });
            }
        }

        private string GetPeriod(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                return "";

            return string.Format("startdate={0}&enddate={1}", startDate.ToString("MMM dd, yyyy"),
                                 endDate.ToString("MMM dd, yyyy"));
        }
    }
}
