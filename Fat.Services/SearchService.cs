using Fat.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fat.Services
{
    public class SearchService : Service
    {
        private static volatile IEnumerable<Stock> _stockCache;
        private static readonly object CacheLock = new object();

        public IEnumerable<Stock> Search(string keyword)
        {
            EnsureCache();

            if (string.IsNullOrWhiteSpace(keyword))
                return null;

            var results = _stockCache.Where(s =>
                s.Code.StartsWith(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                s.Industry.StartsWith(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                AllWords(s.Name, keyword));

            return results;
        }

        private void EnsureCache()
        {
            if (_stockCache == null)
            {
                lock (CacheLock)
                {
                    if (_stockCache == null)
                        _stockCache = DataContext.Stocks.ToList();
                }
            }
        }

        private bool AnyWord(string value, string term)
        {
            var words = term.Split(' ');
            
            value = " " + value;

            return words.Any(word => value.IndexOf(" " + word, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        private bool AllWords(string value, string term)
        {
            var words = term.Split(' ');

            value = " " + value;

            return words.All(word => value.IndexOf(" " + word, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }
    }
}
