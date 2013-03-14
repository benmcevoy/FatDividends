using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Fat.Services.Models;

namespace Fat.Quotes.Google
{
    public class QuoteProvider : IQuoteProvider
    {
        private const string BaseUrl = "http://finance.google.com/finance/info?client=ig&q=ASX:{0}";

        public StockQuote Get(string stockCode)
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString(string.Format(BaseUrl, stockCode));

                json = json.Remove(0, 5);
                json = json.Trim("\n]\n".ToCharArray());

                var quote = Newtonsoft.Json.JsonConvert.DeserializeObject<QuoteDTO>(json);

                var closingDate = DateTimeOffset.ParseExact(quote.lt + " " + DateTime.Now.Year.ToString(), "MMM d, h:mmtt 'GMT'zzz yyyy", CultureInfo.InvariantCulture);

                return new StockQuote(quote.t, quote.l, closingDate.Date);
            }
        }

        public StockQuote Get(string stockCode, DateTime closingDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockQuote> Get(string stockCode, DateTime openingDate, DateTime closingDate)
        {
            throw new NotImplementedException();
        }
    }
}
