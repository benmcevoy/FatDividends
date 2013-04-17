using Fat.Quotes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Fat.Tests.Quotes
{
    [TestClass]
    public class StockQuotesTests
    {
        [TestMethod]
        public void GetQuoteFromGoogle()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Google.QuoteProvider() as IQuoteProvider;
            var quote = qp.Get(code);

            Assert.AreEqual(code, quote.StockCode);
        }

        [TestMethod]
        public void GetQuoteFromYahoo()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Yahoo.QuoteProvider() as IQuoteProvider;
            var quote = qp.Get(code);

            Assert.AreEqual(code, quote.StockCode);
        }

        [TestMethod]
        public void GetQuoteFromYahooForClosingDate()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Yahoo.QuoteProvider() as IQuoteProvider;
            var quote = qp.Get(code, new DateTime(2013, 3, 1));

            Assert.AreEqual(code, quote.StockCode);
        }

        [TestMethod]
        public void GetQuoteFromYahooForDateRange()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Yahoo.QuoteProvider() as IQuoteProvider;
            var start = new DateTime(2013, 3, 1);
            var end = DateTime.Now;
            var quotes = qp.Get(code, start, end);

            var firstOrDefault = quotes.FirstOrDefault();
            
            if (firstOrDefault != null)
            {
                Assert.AreEqual(code, firstOrDefault.StockCode);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SearchYahooForSymbol()
        {
            var search = "ACS";
            var s = new Fat.Quotes.Yahoo.StockCodeProvider() as IStockCodeProvider;

            s.Search(search);

            Assert.AreEqual(1,1);
        }

        [TestMethod]
        public void GetQuoteFromGoogleScrapeForDateRange()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Google.ScrapeProvider() as IQuoteProvider; 
            var start = new DateTime(2013, 3, 1);
            var end = DateTime.Now;
            var quotes = qp.Get(code, start, end);

            var firstOrDefault = quotes.FirstOrDefault();

            if (firstOrDefault != null)
            {
                Assert.AreEqual(code, firstOrDefault.StockCode);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
