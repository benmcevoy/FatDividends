using System;
using System.Collections.Generic;
using System.Linq;

namespace Fat.Services
{
    public class IndustryService : Service
    {
        public IEnumerable<String> Get()
        {
            return DataContext.Stocks.Select(s => s.Industry).Distinct();
        }
    }
}
