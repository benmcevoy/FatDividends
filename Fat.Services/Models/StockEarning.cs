using System;

namespace Fat.Services.Models
{
    public class StockEarning
    {
        public StockEarning()
        {
            CreatedUtcDate = DateTime.UtcNow;
        }

        public string StockCode { get; set; }

        public DateTime ReportedDate { get; set; }

        public string Year { get; set; }

        public string Period { get; set; }

        public decimal NPAT { get; set; }

        public string Margin { get; set; }

        public string CashFlow { get; set; }

        public decimal EPS { get; set; }

        public decimal DPS { get; set; }

        public decimal ROE { get; set; }

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
    }
}
