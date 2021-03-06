﻿using System;
using System.Collections.Generic;

namespace Fat.Services.Models
{
    public class Stock
    {
        public Stock()
        {
            StockQuotes = new HashSet<StockQuote>();
            StockEarnings = new HashSet<StockEarning>();
            StockDividends = new HashSet<StockDividend>();
        }

        public string Code { get; set; }

        public string Name { get; set; }
        
        public DateTime CreatedUtcDate { get; set; }
        
        public DateTime? ModifiedUtcDate { get; set; }

        public DateTime? LastRefreshDateTime { get; set; }
        
        public bool IsActive { get; set; }
        
        public string Industry { get; set; }

        public virtual ICollection<StockQuote> StockQuotes { get; set; }

        public virtual ICollection<StockEarning> StockEarnings { get; set; }

        public virtual ICollection<StockDividend> StockDividends { get; set; }
    }
}