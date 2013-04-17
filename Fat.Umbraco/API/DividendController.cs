using System.Collections.Generic;
using Fat.Services;
using Fat.Services.Models;
using System.Web.Http;

namespace Fat.Umbraco.API
{
    public class DividendController : ApiController
    {
        private readonly DividendService _dividendService;

        public DividendController()
        {
            _dividendService = new DividendService();
        }

        public IEnumerable<StockDividend> Get()
        {
            return _dividendService.Get(5);
        }

        public StockDividend Get(string id)
        {
            return _dividendService.Get(id);
        }

        protected override void Dispose(bool disposing)
        {
            _dividendService.Dispose();
            base.Dispose(disposing);
        }
    }
}