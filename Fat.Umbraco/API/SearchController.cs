using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Fat.Services.Models;

namespace Fat.Umbraco.API
{
    public class SearchController : ApiController
    {
        private readonly FatDataContext _context;
        private volatile IEnumerable<Stock> _stockCache;
        private static readonly object CacheLock = new object();

        public SearchController()
        {
            _context = new FatDataContext();
        }

        [AcceptVerbs("GET")]
        public IEnumerable<Stock> Search(string id)
        {
            if (_stockCache == null)
            {
                lock (CacheLock)
                {
                    if (_stockCache == null)
                        _stockCache = _context.Stocks.ToList();
                }
            }
            var results = _stockCache.Where(
                s =>
                s.Code.StartsWith(id, StringComparison.CurrentCultureIgnoreCase) ||
                s.Name.StartsWith(id, StringComparison.CurrentCultureIgnoreCase) ||
                AnyWord(s.Name, id));

            return results;
        }

        private bool AnyWord(string value, string term)
        {
            var words = value.Split(' ');

            return words.Any(w => w.StartsWith(term, StringComparison.CurrentCultureIgnoreCase));
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}