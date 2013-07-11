using System;

namespace Fat.Import
{
    public static class IndexImporter
    {
        public static void Import()
        {
            var quoteProvider = new Quotes.Google.IndexQuoteProvider();

            using (var service = new Services.IndexQuoteService())
            {
                var quotes = quoteProvider.Get(DateTime.Now.AddDays(-7), DateTime.Now);

                if (quotes == null) return;

                service.AddIndexQuotes(quotes);
            }
        }
    }
}
