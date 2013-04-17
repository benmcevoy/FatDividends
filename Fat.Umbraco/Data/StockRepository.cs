using System;
using System.Collections.Generic;
using Fat.Services;
using Fat.Services.Models;
using System.Web;
using umbraco.MacroEngines;

namespace Fat.Umbraco.Data
{
    public static class StockRepository
    {
        public static Stock GetStock(DynamicNodeContext nodeContext)
        {
            using (var service = new StockService())
            {
                return service.Get(HttpContext.Current.Request.QueryString["code"]);
            }
        }

        public static StockQuote GetLatestQuote(DynamicNodeContext nodeContext)
        {
            using (var service = new StockService())
            {
                return service.GetLatestQuote(HttpContext.Current.Request.QueryString["code"]);
            }
        }

        public static IEnumerable<Quote> GetQuotes(DynamicNodeContext nodeContext)
        {
            using (var service = new StockService())
            {
                return service.GetQuotes(HttpContext.Current.Request.QueryString["code"],
                                              new DateTime(DateTime.Now.Year, 1, 1), DateTime.Now);
            }
        }
    }
}