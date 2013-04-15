using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Fat.Services;
using Fat.Services.Models;

namespace Fat.Umbraco.API
{
    public class IndexQuoteController : ApiController
    {
        private readonly IndexQuoteService _indexQuoteService;

        public IndexQuoteController()
        {
            _indexQuoteService = new IndexQuoteService();
        }

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