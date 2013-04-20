using System;

namespace Fat.Services.Models
{
    public class StockQuote
    {
        public StockQuote()
        {
            CreatedUtcDate = DateTime.UtcNow;
        }

        public StockQuote(string code, decimal price, DateTime closingDate)
        {
            StockCode = code;
            Price = price;
            ClosingDate = closingDate;
            CreatedUtcDate = DateTime.UtcNow;
        }

        public string StockCode { get; set; }

        public decimal Price { get; set; }

        public decimal? Close { get; set; }

        public decimal? Open { get; set; }

        public decimal? High { get; set; }

        public decimal? Low { get; set; }

        public int? Volume { get; set; }

        public DateTime ClosingDate { get; set; }

        public DateTime CreatedUtcDate { get; set; }

        public DateTime? ModifiedUtcDate { get; set; }

        internal virtual Stock Stock { get; set; }
    }
}