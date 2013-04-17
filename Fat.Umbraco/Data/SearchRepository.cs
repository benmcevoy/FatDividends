using Fat.Services;
using Fat.Services.Models;
using System.Collections.Generic;
using System.Web;
using umbraco.MacroEngines;

namespace Fat.Umbraco.Data
{
    public static class SearchRepository
    {
        public static IEnumerable<Stock> SearchStock(DynamicNodeContext nodeContext)
        {
            var keywords = HttpContext.Current.Request.QueryString["keywords"];

            if (string.IsNullOrEmpty(keywords))
                return null;

            using (var service = new SearchService())
            {
                return service.Search(keywords);
            }
        }
    }
}