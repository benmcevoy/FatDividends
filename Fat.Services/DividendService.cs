using System;
using System.Collections.Generic;
using System.Linq;
using Fat.Services.Models;

namespace Fat.Services
{
    public class DividendService : Service
    {
        public IEnumerable<StockDividend> Get(int count)
        {
            return DataContext.StockDividends
                .Include("Stock")
                .OrderBy(d => d.RecordDate)
                .Skip(Math.Max(0, DataContext.StockDividends.Count() - count))
                .Take(count);
        }

        public StockDividend Get(string stockCode)
        {
            return DataContext.StockDividends
                              .Include("Stock")
                              .OrderBy(d => d.RecordDate)
                              .FirstOrDefault(d => d.StockCode == stockCode);
        }

        public IEnumerable<StockDividend> Get(string stockCode, int count)
        {
            return DataContext.StockDividends
                .Include("Stock")
                .Where(d => d.StockCode == stockCode)
                .OrderBy(d => d.RecordDate)
                .Skip(Math.Max(0, DataContext.StockDividends.Count() - count))
                .Take(count);
        }

        public void Add(IEnumerable<StockDividend> stockDividends)
        {
            // use own context for bulk insert
            using (var context = new FatDataContext())
            {
                foreach (var dividend in stockDividends)
                {
                    AddUncomitted(context, dividend);
                }

                context.SaveChanges();
            }
        }

        private void AddUncomitted(FatDataContext context, StockDividend stockDividend)
        {
            // exists
            var dividend = context.StockDividends.Find(stockDividend.StockCode, stockDividend.ExDate);

            if (dividend == null)
            {
                context.StockDividends.Add(stockDividend);
            }
        }
    }
}
