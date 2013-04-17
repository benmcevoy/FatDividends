using Fat.Services;
using Fat.Services.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Fat.Umbraco.API
{
    public class SearchController : ApiController
    {
        private readonly SearchService _searchService;

        public SearchController()
        {
            _searchService = new SearchService();
        }

        [AcceptVerbs("GET")]
        public IEnumerable<Stock> Search(string id)
        {
            return _searchService.Search(id);
        }

        protected override void Dispose(bool disposing)
        {
            _searchService.Dispose();
            base.Dispose(disposing);
        }
    }
}