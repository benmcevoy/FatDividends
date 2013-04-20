using System.Linq.Expressions;
using Fat.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fat.Services
{
    public class QuoteService : Service
    {
        public IEnumerable<StockQuote> Get(string stockCode)
        {
            return DataContext.StockQuotes.Where(q => q.StockCode == stockCode);
        }

        public StockQuote Get(string stockCode, DateTime closingDate)
        {
            return DataContext.StockQuotes
                .FirstOrDefault(q => q.StockCode == stockCode && q.ClosingDate == closingDate);
        }

        public StockQuote Get(Expression<Func<StockQuote, bool>> predicate)
        {
            return DataContext.StockQuotes.FirstOrDefault(predicate);
        }
    }
}
