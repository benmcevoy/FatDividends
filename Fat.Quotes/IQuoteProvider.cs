using Fat.Services.Models;
using System;
using System.Collections.Generic;

namespace Fat.Quotes
{
    public interface IQuoteProvider
    {
        StockQuote Get(string stockCode);

        StockQuote Get(string stockCode, DateTime closingDate);

        IEnumerable<StockQuote> Get(string stockCode, DateTime openingDate, DateTime closingDate);
    }
}
