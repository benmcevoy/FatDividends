using System;

namespace Fat.Services.Models
{
    public class IndexQuote
    {
        public IndexQuote()
        {
            CreatedUtcDate = DateTime.UtcNow;
        }

        public IndexQuote(string code, decimal price, DateTime closingDate)
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
    }
}
