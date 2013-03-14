using System.Collections.Generic;

namespace Fat.Services.Models
{
    public class Stock
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string IndustryGroup { get; set; }

        public IEnumerable<StockQuote> Quotes { get; set; }
    }
}