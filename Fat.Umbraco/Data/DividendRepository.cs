using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fat.Services;
using Fat.Services.Models;
using umbraco.MacroEngines;
using System;

namespace Fat.Umbraco.Data
{
    public static class DividendRepository
    {
        public static StockDividend Get(DynamicNodeContext nodeContext)
        {
            using (var service = new DividendService())
            {
                var stockCode = GetStockCode();
                var exDate = GetExDate();

                return service.Get(stockCode, exDate);
            }
        }

        public static IEnumerable<StockDividend> GetUpcoming(DynamicNodeContext context, int count)
        {
            using (var service = new DividendService())
            {
                var startDate = DateTime.UtcNow.AddDays(-1);

                return service.GetLatest(count, startDate).ToList();
            }
        }

        public static IEnumerable<StockDividend> GetLatest(DynamicNodeContext nodeContext, int count)
        {
            using (var service = new DividendService())
            {
                return service.GetLatest(count).ToList();
            }
        }

        public static IEnumerable<StockDividend> Get(DynamicNodeContext nodeContext, int count)
        {
            using (var service = new DividendService())
            {
                var stockCode = GetStockCode();

                if (string.IsNullOrEmpty(stockCode))
                {
                    return service.GetLatest(count).ToList();
                }

                return service.Get(stockCode, count).ToList();
            }
        }

        private static string GetStockCode()
        {
            return HttpContext.Current.Request.QueryString["code"];
        }

        private static DateTime GetExDate()
        {
            return DateTime.Parse(HttpContext.Current.Request.QueryString["date"]);
        }
    }
}