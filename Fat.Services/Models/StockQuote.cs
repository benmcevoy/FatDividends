using System;

namespace Fat.Services.Models
{
    public class StockQuote
    {
        public StockQuote(string code, decimal price, DateTime closingDate)
        {
            Code = code;
            Price = price;
            ClosingDate = closingDate;
        }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public DateTime ClosingDate { get; set; }

        public DateTime CreatedUtcDate { get; set; }

        public DateTime? ModifiedUtcDate { get; set; }

        internal virtual Stock Stock { get; set; }
    }
}