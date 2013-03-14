using System;

namespace Fat.Services.Models
{
    public class StockQuote
    {
        public StockQuote(string code, decimal price, DateTime closingDate)
        {
            Code = code;
            ClosingPrice = price;
            ClosingDate = closingDate;
        }

        public string Code { get; private set; }

        public decimal ClosingPrice { get; private set; }

        public DateTime ClosingDate { get; private set; }
    }
}