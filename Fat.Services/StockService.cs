using System;
using System.Collections.Generic;
using System.Linq;

using Fat.Services.Models;

namespace Fat.Services
{
    public class StockService : Service
    {
        public IEnumerable<Stock> Get()
        {
            return DataContext.Stocks.AsEnumerable();
        }

        public IEnumerable<Stock> GetWithQuotes()
        {
            return DataContext.Stocks.Include("StockQuotes").AsEnumerable();
        }

        public IEnumerable<Stock> GetStocksForRefresh(DateTime staleDate)
        {
            return DataContext.Stocks
                .Where(s =>
                        (!s.LastRefreshDateTime.HasValue ||
                        s.LastRefreshDateTime <= staleDate) &&
                        s.IsActive)
                .AsEnumerable();
        }

        public Stock Get(string stockCode)
        {
            var stock = DataContext.Stocks.Find(stockCode);

            return stock;
        }

        private void AddQuoteUncommited(FatDataContext context, StockQuote quote)
        {
            // exists
            var stockQuote = context.StockQuotes.Find(quote.StockCode, quote.ClosingDate);
            var stock = context.Stocks.Find(quote.StockCode);

            if (stockQuote == null)
            {
                // insert
                stockQuote = new StockQuote
                    {
                        ClosingDate = quote.ClosingDate,
                        Price = quote.Price,
                        CreatedUtcDate = DateTime.UtcNow,
                        StockCode = quote.StockCode,
                        Close = quote.Close,
                        High = quote.High,
                        Low = quote.Low,
                        Volume = quote.Volume
                    };

                context.StockQuotes.Add(stockQuote);
            }
            else
            {
                // update
                stockQuote.Price = quote.Price;
                stockQuote.Close = quote.Close;
                stockQuote.High = quote.High;
                stockQuote.Low = quote.Low;
                stockQuote.Volume = quote.Volume;
                stockQuote.ModifiedUtcDate = DateTime.UtcNow;
            }

            stock.LastRefreshDateTime = DateTime.UtcNow;
        }

        public void AddQuotes(IEnumerable<StockQuote> quotes)
        {
            using (var context = new FatDataContext())
            {
                foreach (var quote in quotes)
                {
                    AddQuoteUncommited(context, quote);
                }

                context.SaveChanges();    
            }
        }

        public void SetLastRefreshDate(string stockCode)
        {
            var stock = Get(stockCode);

            stock.LastRefreshDateTime = DateTime.UtcNow;

            DataContext.SaveChanges();
        }


        public StockQuote GetLatestQuote(string stockCode)
        {
            return DataContext.StockQuotes
                           .OrderByDescending(q => q.ClosingDate)
                           .FirstOrDefault(q => q.StockCode == stockCode);
        }

        public IEnumerable<Quote> GetQuotes(string stockCode, DateTime startDate, DateTime endDate)
        {
            return DataContext.StockQuotes
                           .OrderBy(q => q.ClosingDate)
                           .Where(q =>
                               q.StockCode == stockCode
                               && q.ClosingDate >= startDate
                               && q.ClosingDate <= endDate).AsEnumerable()
                               .Select(q => new Quote
                                   {
                                       Date = q.ClosingDate,
                                       Price = q.Price
                                   });
        }
    }
}
