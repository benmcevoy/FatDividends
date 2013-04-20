using System.Linq;
using Fat.Services.Models;
using System;
using System.Collections.Generic;

namespace Fat.Services
{
    public class IndexQuoteService : Service
    {
        public IEnumerable<IndexQuote> Get(int lastCount)
        {
            return DataContext.IndexQuotes
                .OrderBy(q => q.ClosingDate)
                .Skip(Math.Max(0, DataContext.IndexQuotes.Count() - lastCount))
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
                context.IndexQuotes.Add(quote);
            }
        }
    }
}
