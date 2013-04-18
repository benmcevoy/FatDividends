using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Fat.Services;
using Fat.Services.Models;
using System.Web;
using umbraco;
using umbraco.MacroEngines;
using Fat.Umbraco.DocumentTypes;

namespace Fat.Umbraco.Data
{
    public static class StockRepository
    {
        private static volatile string _defaultStockSummary;
        private readonly static object DefaultStockSummaryLock = new object();

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

        public static string GetSummary(DynamicNodeContext nodeContext)
        {
            var stockCode = HttpContext.Current.Request.QueryString["code"];

            if (string.IsNullOrEmpty(stockCode))
                return GetDefaultStockSummary(nodeContext);

            var stockSummaryDynamicItem = nodeContext.Current.XPath("//Folder[@nodeName='Config']/Folder[@nodeName='Stock Summaries']/descendant::StockSummaryItem")
                .Items.FirstOrDefault(item => item.GetPropertyValue("StockCode", String.Empty).Equals(stockCode, StringComparison.CurrentCultureIgnoreCase));

            return stockSummaryDynamicItem != null ? 
                stockSummaryDynamicItem.GetPropertyValue("Summary", String.Empty) : 
                GetDefaultStockSummary(nodeContext);
        }

        public static string GetDefaultStockSummary(DynamicNodeContext nodeContext)
        {
            if (_defaultStockSummary == null)
            {
                lock (DefaultStockSummaryLock)
                {
                    if (_defaultStockSummary == null)
                    {
                        var config = (FatConfigSection)ConfigurationManager.GetSection("fatConfig");

                        _defaultStockSummary = Vega.USiteBuilder.ContentHelper
                            .GetByNodeId<StockSummaryItem>(config.DefaultStockSummaryNodeId).Summary;
                    }
                }
            }

            return _defaultStockSummary;
        }
    }
}