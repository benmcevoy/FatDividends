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
        private static readonly StockService StockService = new StockService();

        public static Stock GetStock(DynamicNodeContext nodeContext)
        {
            return StockService.Get(HttpContext.Current.Request.QueryString["code"]);
        }

        public static StockQuote GetLatestQuote(DynamicNodeContext nodeContext)
        {
            return StockService.GetLatestQuote(HttpContext.Current.Request.QueryString["code"]);
        }

        public static IEnumerable<Quote> GetQuotes(DynamicNodeContext nodeContext)
        {
            return StockService.GetQuotes(HttpContext.Current.Request.QueryString["code"], 
                new DateTime(DateTime.Now.Year, 1, 1), DateTime.Now);
        }

    }
}