using System;

namespace Fat.Services.Models
{
    public class StockDividend
    {
        public StockDividend()
        {
            CreatedUtcDate = DateTime.UtcNow;
        }

        public string StockCode { get; set; }

        public DateTime? RecordDate { get; set; }

        public DateTime ExDate { get; set; }

        public decimal Amount { get; set; }

        public decimal Franked { get; set; }

        public decimal FrankingCredit { get; set; }

        public DateTime PayableDate { get; set; }

        public DateTime CreatedUtcDate { get; set; }

        public DateTime? ModifiedUtcDate { get; set; }

        internal virtual Stock Stock { get; set; }

        public string StockName
        {
            get
            {
                return Stock != null ? Stock.Name : "";
            }
        }

        public string FormattedRecordDate
        {
            get
            {
                return (RecordDate.HasValue ? RecordDate.Value.ToString("dd MMM yy") : "");
            }
        }

        /// <summary>
        /// Closing Price of day before ExDate
        /// </summary>
        public decimal ClosingPrice { get; set; }

        public decimal GrossedAmount
        {
            get { return Amount * (1 - Franked) + (Amount * Franked) / 0.7m; }
        }

        public decimal GrossedYieldPercentage
        {
            get { return ClosingPrice == 0m ? 0m : GrossedAmount / ClosingPrice; }
        }
    }
}