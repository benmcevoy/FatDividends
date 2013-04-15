using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Fat.Services;
using Fat.Services.Models;
using Fat.Umbraco.Filters;

namespace Fat.Umbraco.API
{
    public class IndexQuoteController : ApiController
    {
        private readonly IndexQuoteService _indexQuoteService;

        public IndexQuoteController()
        {
            _indexQuoteService = new IndexQuoteService();
        }

        [ApiCache(600)]
        public IEnumerable<Quote> Get()
        {
            return _indexQuoteService.Get(30).Select(q =>
                new Quote
                    {
                        Date = q.ClosingDate,
                        Price = q.Price
                    });
        }

    }
}