using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fat.Services;
using Fat.Services.Models;
using umbraco.MacroEngines;

namespace Fat.Umbraco.Data
{
    public static class DividendRepository
    {
        public static IEnumerable<StockDividend> GetLatest(DynamicNodeContext nodeContext, int count)
        {
            using (var service = new DividendService())
            {
                return service.Get(count).ToList();
            }
        }

        public static IEnumerable<StockDividend> Get(DynamicNodeContext nodeContext, int count)
        {
            using (var service = new DividendService())
            {
                return service.Get(HttpContext.Current.Request.QueryString["code"], count).ToList();
            }
        }
    }
}