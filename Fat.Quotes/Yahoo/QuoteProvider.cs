using System;
using System.Collections.Generic;
using System.Linq;
using Fat.Services.Models;
using MaasOne.Base;
using MaasOne.Finance.YahooFinance;

namespace Fat.Quotes.Yahoo
{
    public class QuoteProvider : IQuoteProvider
    {
        private const string ASXExchangePostFix = ".AX";

        private readonly IEnumerable<QuoteProperty> _quoteProperties = new[]
            {
                QuoteProperty.Symbol,
                QuoteProperty.Name,
                QuoteProperty.LastTradePriceOnly,
                //QuoteProperty.YearHigh,
                //QuoteProperty.PreviousClose,
                QuoteProperty.LastTradeDate
            };

        /// <summary>
        /// Get the latest stock quote for this code or null if not found
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public StockQuote Get(string stockCode)
        {
            var quotesDownload = new QuotesDownload();
            var response = quotesDownload.Download(PostFixStockCode(stockCode), _quoteProperties);

            if (response.Connection.State == ConnectionState.Success)
            {
                var result = response.Result.Items.SingleOrDefault();

                if (result != null)
                {
                    return new StockQuote(result.Name,
                        Convert.ToDecimal(result.LastTradePriceOnly),
                        result.LastTradeDate);
                }
            }

            return null;
        }

        public StockQuote Get(string stockCode, DateTime closingDate)
        {
            return Get(stockCode, closingDate, closingDate).FirstOrDefault();
        }

        public IEnumerable<StockQuote> Get(string stockCode, DateTime openingDate, DateTime closingDate)
        {
            var histQuotesDownload = new HistQuotesDownload();
            var response = histQuotesDownload.Download(PostFixStockCode(stockCode),
                openingDate, closingDate, HistQuotesInterval.Daily);

            //Response/Result
            if (response.Connection.State == ConnectionState.Success)
            {
                if (response.Result.Items != null)
                {
                    return response.Result.Items.Select(q => new StockQuote(stockCode, Convert.ToDecimal(q.Close),
                                                                            q.TradingDate));
                }
            }

            return null;
        }

        private static string PostFixStockCode(string stockCode)
        {
            return string.Concat(stockCode, ASXExchangePostFix);
        }
    }
}