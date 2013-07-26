using System;
using System.Collections.Generic;
using System.Linq;
using Fat.Services.Models;

namespace Fat.Services
{
    public class DividendService : Service
    {
        public IEnumerable<StockDividend> Get(Func<StockDividend, bool> predicate)
        {
            return DataContext.StockDividends.Where(predicate);
        }

        public IEnumerable<StockDividend> GetLatest(int count)
        {
            return DataContext.StockDividends
                .Include("Stock")
                .OrderByDescending(d => d.ExDate)
                .Take(count);
        }

        public IEnumerable<StockDividend> GetLatest(int count, DateTime startDate)
        {
            return DataContext.StockDividends
                .Include("Stock")
                .Where(d => d.ExDate >= startDate)
                .OrderByDescending(d => d.ExDate)
                .Take(count);
        }

        public StockDividend Get(string stockCode)
        {
            return DataContext.StockDividends
                              .Include("Stock")
                              .OrderBy(d => d.ExDate)
                              .FirstOrDefault(d => d.StockCode == stockCode);
        }

        public StockDividend Get(string stockCode, DateTime exDate)
        {
            return DataContext.StockDividends
                              .Include("Stock")
                              .OrderBy(d => d.ExDate)
                              .FirstOrDefault(d => d.StockCode == stockCode
                                  && d.ExDate == exDate);
        }


        public IEnumerable<StockDividend> Get(string stockCode, int count)
        {
            return DataContext.StockDividends
                .Include("Stock")
                .Where(d => d.StockCode == stockCode)
                .OrderByDescending(d => d.ExDate)
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
