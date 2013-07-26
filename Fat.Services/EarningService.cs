using System;
using System.Collections.Generic;
using System.Linq;
using Fat.Services.Models;

namespace Fat.Services
{
    public class EarningService : Service
    {
        public IEnumerable<StockEarning> Get(int count)
        {
            return DataContext.StockEarnings
                .Include("Stock")
                .OrderBy(d => d.ReportedDate)
                .Skip(Math.Max(0, DataContext.StockEarnings.Count() - count))
                .Take(count);
        }

        public StockEarning Get(string stockCode)
        {
            return DataContext.StockEarnings
                .Include("Stock")
                .OrderBy(e => e.ReportedDate)
                .FirstOrDefault(e => e.StockCode == stockCode);
        }

        public IEnumerable<StockEarning> Get(string stockCode, int count)
        {
            return DataContext.StockEarnings
                                               .Include("Stock")
                                               .Where(e => e.StockCode == stockCode)
                          .OrderByDescending(e => e.ReportedDate)
                          .Take(count);
        }

        public void Add(IEnumerable<StockEarning> stockEarnings)
        {
            // use own context for bulk insert
            using (var context = new FatDataContext())
            {
                foreach (var earning in stockEarnings)
                {
                    AddUncomitted(context, earning);
                }

                context.SaveChanges();
            }
        }

        private void AddUncomitted(FatDataContext context, StockEarning stockEarning)
        {
            // exists
            var earning = context.StockEarnings.Find(stockEarning.StockCode, stockEarning.ReportedDate);

            if (earning == null)
            {
                context.StockEarnings.Add(stockEarning);
            }
        }
    }
}
