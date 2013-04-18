using System;

namespace Fat.Services.Models
{
    public class StockDividend
    {
        public string StockCode { get; set; }

        public DateTime RecordDate { get; set; }

        public DateTime ExDate { get; set; }

        public decimal Amount { get; set; }

        public decimal Franked { get; set; }

        public DateTime PayableDate { get; set; }

        public DateTime CreatedUtcDate { get; set; }

        public DateTime? ModifiedUtcDate { get; set; }

        internal virtual Stock Stock { get; set; }

        public string StockName
        {
            get
            {
                if (Stock != null)
                {
                    return Stock.Name;
                }

                return "";
            }
        }

        // TODO: also the import
        // ClosingPrice?? not sure for what date? set on import

        //public decimal GrossedAmount { get; private set; }
        // Amount * (1 - Franked) + (Amount * Franked) / 0.7

        //public decimal GrossedYieldPercentage { get; set; }
        // is GrossedAmount / ClosingPrice on the date payable?
    }
}
