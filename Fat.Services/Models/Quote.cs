﻿using System;

namespace Fat.Services.Models
{
    public class Quote
    {
        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public string FormattedDate { get { return Date.ToString("dd MMM"); }}
    }
}
