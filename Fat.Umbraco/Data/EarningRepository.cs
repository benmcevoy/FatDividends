using System.Linq;
using System.Web;
using Fat.Services;
using Fat.Services.Models;
using System.Collections.Generic;
using umbraco.MacroEngines;

namespace Fat.Umbraco.Data
{
    public static class EarningRepository
    {
        public static IEnumerable<StockEarning> GetLatest(DynamicNodeContext nodeContext, int count)
        {
            using (var service = new EarningService())
            {
                return service.Get(count).ToList();
            }
        }

        public static IEnumerable<StockEarning> Get(DynamicNodeContext nodeContext, int count)
        {
            using (var service = new EarningService())
            {
                var stockCode = HttpContext.Current.Request.QueryString["code"];
                return service.Get(stockCode, count).ToList(); 
            }
        }
    }
}