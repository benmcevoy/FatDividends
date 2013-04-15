using System.Linq;
using Fat.Services.Models;
using System;
using System.Collections.Generic;

namespace Fat.Services
{
    public class IndexQuoteService
    {
        private readonly FatDataContext _context;

        public IndexQuoteService()
        {
            _context = new FatDataContext();
        }

        public IEnumerable<IndexQuote> Get(int lastCount)
        {
            return _context.IndexQuotes
                .OrderBy(q => q.ClosingDate)
                .Skip(Math.Max(0, _context.IndexQuotes.Count() - lastCount))
                .Take(lastCount);
        }

        public void AddIndexQuotes(IEnumerable<IndexQuote> quotes)
        {
            // use own context for bulk insert
            using (var context = new FatDataContext())
            {
                foreach (var quote in quotes)
                {
                    AddIndexQuoteUncommited(context, quote);
                }

                context.SaveChanges();
            }
        }

        private void AddIndexQuoteUncommited(FatDataContext context, IndexQuote quote)
        {
            // exists
            var indexQuote = context.IndexQuotes.Find(quote.ClosingDate);

            if (indexQuote == null)
            {
                // insert
                indexQuote = new IndexQuote
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

                context.IndexQuotes.Add(indexQuote);
            }
            else
            {
                // update
                indexQuote.Price = quote.Price;
                indexQuote.ModifiedUtcDate = DateTime.UtcNow;
                indexQuote.Close = quote.Close;
                indexQuote.High = quote.High;
                indexQuote.Low = quote.Low;
                indexQuote.Volume = quote.Volume;
            }
        }
    }
}
