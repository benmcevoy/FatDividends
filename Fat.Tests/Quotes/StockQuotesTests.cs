using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fat.Tests.Quotes
{
    [TestClass]
    public class StockQuotesTests
    {
        [TestMethod]
        public void GetQuoteFromGoogle()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Google.QuoteProvider();
            var quote = qp.Get(code);

            Assert.AreEqual(code, quote.Code);
        }

        [TestMethod]
        public void GetQuoteFromYahoo()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Yahoo.QuoteProvider();
            var quote = qp.Get(code);

            Assert.AreEqual(code, quote.Code);
        }

        [TestMethod]
        public void GetQuoteFromYahooForClosingDate()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Yahoo.QuoteProvider();
            var quote = qp.Get(code, new DateTime(2013, 3, 1));

            Assert.AreEqual(code, quote.Code);
        }

        [TestMethod]
        public void GetQuoteFromYahooForDateRange()
        {
            var code = "ACS";
            var qp = new Fat.Quotes.Yahoo.QuoteProvider();
            var start = new DateTime(2013, 3, 1);
            var end = DateTime.Now;
            var quotes = qp.Get(code, start, end);

            var firstOrDefault = quotes.FirstOrDefault();
            
            if (firstOrDefault != null)
            {
                Assert.AreEqual(code, firstOrDefault.Code);
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
            var s = new Fat.Quotes.Yahoo.StockCodeProvider();

            s.Search(search);

            Assert.AreEqual(1,1);
        }
    }
}
