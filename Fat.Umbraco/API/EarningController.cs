using System.Collections.Generic;
using Fat.Services;
using Fat.Services.Models;
using System.Web.Http;

namespace Fat.Umbraco.API
{
    public class EarningController : ApiController
    {
        private readonly EarningService _earningService;

        public EarningController()
        {
            _earningService = new EarningService();
        }

        public IEnumerable<StockEarning> Get()
        {
            return _earningService.Get(5);
        }

        public StockEarning Get(string id)
        {
            return _earningService.Get(id);
        }

        protected override void Dispose(bool disposing)
        {
            _earningService.Dispose();
            base.Dispose(disposing);
        }
    }
}