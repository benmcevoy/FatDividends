using System;
using System.Collections.Generic;
using System.Linq;

using Fat.Services.Models;

namespace Fat.Services
{
    public class StockService
    {
        private readonly FatDataContext _context;

        public StockService()
        {
            _context = new FatDataContext();
        }

        public IEnumerable<Stock> Get()
        {
            return _context.Stocks.AsEnumerable();
        }

        public IEnumerable<Stock> GetWithQuotes()
        {
            return _context.Stocks.Include("StockQuotes").AsEnumerable();
        }

        public IEnumerable<Stock> GetStocksForRefresh(DateTime staleDate)
        {
            return _context.Stocks.Include("StockQuotes")
                .Where(s =>
                        !s.LastRefreshDateTime.HasValue ||
                        s.LastRefreshDateTime <= staleDate)
                .AsEnumerable();
        }

        public Stock Get(string stockCode)
        {
            var stock = _context.Stocks.Find(stockCode);

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

            _context.SaveChanges();
        }


        public StockQuote GetLatestQuote(string stockCode)
        {
            return _context.StockQuotes
                           .OrderByDescending(q => q.ClosingDate)
                           .FirstOrDefault(q => q.StockCode == stockCode);
        }

        public IEnumerable<Quote> GetQuotes(string stockCode, DateTime startDate, DateTime endDate)
        {
            return _context.StockQuotes
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
