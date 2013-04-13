using Fat.Services;
using Fat.Services.Models;
using System.Collections.Generic;
using System.Web;
using umbraco.MacroEngines;

namespace Fat.Umbraco.Data
{
    public static class SearchRepository
    {
        private static readonly SearchService SearchService = new SearchService();

        public static IEnumerable<Stock> SearchStock(DynamicNodeContext nodeContext)
        {
            var keywords = HttpContext.Current.Request.QueryString["keywords"];

            if (string.IsNullOrEmpty(keywords))
                return null;

            return SearchService.Search(keywords);
        }
    }
}