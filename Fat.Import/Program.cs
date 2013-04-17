using System;
using System.Linq;
using System.Threading;

namespace Fat.Import
{
    class Program
    {
        static void Main(string[] args)
        {
           // RefreshIndex();
            RefreshStockQuotes();
        }

        private static void RefreshIndex()
        {
            var quoteProvider = new Quotes.Google.IndexQuoteProvider();

            using (var service = new Services.IndexQuoteService())
            {
                var quotes = quoteProvider.Get(new DateTime(2013, 4, 1), DateTime.Now);

                if (quotes == null) return;

                service.AddIndexQuotes(quotes);
            }
        }

        private static void RefreshStockQuotes()
        {
            var staleDate = new DateTime(2013, 4, 15);

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

        private static void ImportStocks()
        {
            var repository = new Data.ImportRepository();

            var file = System.IO.File.ReadAllLines(@"D:\Dev\git\FatDividends\_documentation\SQL\insert stocks.TXT");

            foreach (var line in file)
            {
                repository.Execute(line);
            }
        }
    }
}
