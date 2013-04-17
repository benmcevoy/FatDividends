using System;

namespace Fat.Quotes.Google
{
    public class SummaryDto
    {
        public string StockCode { get; set; }

        public DateTime ClosingDate { get; set; }

        public decimal PE { get; set; }

        public string Week52 { get; set; }
    }
}
