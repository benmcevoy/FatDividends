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
                .OrderBy(d => d.ReportedDate)
                .FirstOrDefault(d => d.StockCode == stockCode);
        }

        public IEnumerable<StockEarning> Get(string stockCode, int count)
        {
            return DataContext.StockEarnings
                .Include("Stock")
                .Where(d => d.StockCode == stockCode)
                .OrderBy(d => d.ReportedDate)
                .Skip(Math.Max(0, DataContext.StockEarnings.Count() - count))
                .Take(count);
        }

        public void Add(IEnumerable<StockEarning> stockEarnings)
        {
            // use own context for bulk insert
            using (var context = new FatDataContext())
            {
                foreach (var dividend in stockEarnings)
                {
                    AddUncomitted(context, dividend);
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
                // insert
                earning = new StockEarning
                {
                    ReportedDate = stockEarning.ReportedDate,
                    Year = stockEarning.Year,
                    CreatedUtcDate = DateTime.UtcNow,
                    StockCode = stockEarning.StockCode,
                    Period = stockEarning.Period,
                    NPAT = stockEarning.NPAT,
                    Margin = stockEarning.Margin,
                    CashFlow = stockEarning.CashFlow,
                    EPS = stockEarning.EPS,
                    DPS = stockEarning.DPS,
                    ROE = stockEarning.ROE,
                };

                context.StockEarnings.Add(earning);
            }
            else
            {
                // update
                earning.ReportedDate = stockEarning.ReportedDate;
                earning.ModifiedUtcDate = DateTime.UtcNow;
                earning.Year = stockEarning.Year;
                earning.Period = stockEarning.Period;
                earning.NPAT = stockEarning.NPAT;
                earning.Margin = stockEarning.Margin;
                earning.CashFlow = stockEarning.CashFlow;
                earning.EPS = stockEarning.EPS;
                earning.DPS = stockEarning.DPS;
                earning.ROE = stockEarning.ROE;
            }
        }
    }
}
