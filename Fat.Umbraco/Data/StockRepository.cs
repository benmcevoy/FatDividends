using Fat.Services;
using Fat.Services.Models;
using System.Web;
using umbraco.MacroEngines;

namespace Fat.Umbraco.Data
{
    public static class StockRepository
    {
        private static readonly StockService StockService = new StockService();

        public static Stock GetStock(DynamicNodeContext nodeContext)
        {
            return StockService.Get(HttpContext.Current.Request.QueryString["code"]);
        }
    }
}