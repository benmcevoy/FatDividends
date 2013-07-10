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
        [AllowCrossOrigin]
        public IEnumerable<Quote> Get(int id)
        {
            return _indexQuoteService.Get(id).Select(q =>
                new Quote
                {
                    Date = q.ClosingDate,
                    Price = q.Price
                });
        }


        [ApiCache(600)]
        [AllowCrossOrigin]
        public IEnumerable<Quote> Get()
        {
            return Get(30);
        }

        protected override void Dispose(bool disposing)
        {
            _indexQuoteService.Dispose();
            base.Dispose(disposing);
        }
    }
}