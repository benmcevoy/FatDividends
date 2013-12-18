using System;
using System.Linq;
using System.Threading;

namespace Fat.Import
{
    public static class QuoteImporter
    {
        public static void Import(DateTime staleDate)
        {
            var quoteProvider = new Quotes.Google.ScrapeProvider();
            using (var service = new Services.StockService())
            {
                var stocks = service.GetStocksForRefresh(staleDate).ToList();
                var i = 0;

                foreach (var stock in stocks)
                {
                    i++;

                    Console.WriteLine("{0}/{1} - {2}", i, stocks.Count, stock.Code);

                    var quotes = quoteProvider.Get(stock.Code, staleDate.AddDays(-7), DateTime.Now);

                    if (quotes == null)
                    {
                        service.SetLastRefreshDate(stock.Code);
                        continue;
                    }

                    service.AddQuotes(quotes);

                    Thread.Sleep(1000);
                }
            }
        }

        public static void Import(DateTime startDate, DateTime endDate)
        {
            var quoteProvider = new Quotes.Google.ScrapeProvider();
            using (var service = new Services.StockService())
            {
                var stocks = service.Get().ToList();
                var i = 0;

                foreach (var stock in stocks)
                {
                    i++;

                    Console.WriteLine("{0}/{1} - {2}", i, stocks.Count, stock.Code);

                    var quotes = quoteProvider.Get(stock.Code, startDate, endDate);

                    if (quotes == null)
                    {
                        continue;
                    }

                    service.AddQuotes(quotes);

                    Thread.Sleep(1000);
                }
            }
        }
    }
}
