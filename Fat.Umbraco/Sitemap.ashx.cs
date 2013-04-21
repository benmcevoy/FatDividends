using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Fat.Services;
using Fat.Umbraco.DocumentTypes;
using Vega.USiteBuilder;
using umbraco.NodeFactory;

namespace Fat.Umbraco
{
    /// <summary>
    /// Summary description for Sitemap
    /// </summary>
    public class Sitemap : IHttpHandler
    {
        private const string XmlHead = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">";
        private const string XmlFoot = "</urlset>";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();

            context.Response.ContentType = "text/xml";

            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(1));
            context.Response.Cache.SetMaxAge(TimeSpan.FromDays(1));
            context.Response.Cache.SetValidUntilExpires(true);

            context.Response.Write(GetSitemap(context));
        }

        private string GetSitemap(HttpContext context)
        {
            var urls = new StringBuilder(524288); // alloc 1mb

            urls.Append(XmlHead);

            AddMainNav(ref urls, context);
            AddContact(ref urls);
            AddStocks(ref urls);

            urls.Append(XmlFoot);

            return urls.ToString();
        }

        private void AddStocks(ref StringBuilder urls)
        {
            using (var stockService = new StockService())
            {
                var stocks = stockService.Get();

                foreach (var stock in stocks)
                {
                    urls.AppendFormat(@"<url>
<loc>http://fatdividends.com.au/stock-information/{0}</loc>
<lastmod>{1}</lastmod>
<changefreq>daily</changefreq>
</url>", stock.Code, stock.LastRefreshDateTime);
                }
            }
        }

        private void AddContact(ref StringBuilder urls)
        {
            var node = Node.GetNodeByXpath("//HomePage/ContactFormPage");

            urls.AppendFormat(@"<url>
<loc>http://fatdividends.com.au/contact</loc>
<lastmod>{0}</lastmod>
<changefreq>monthly</changefreq>
</url>", node.UpdateDate.ToString("yyyy-MM-dd"));
        }

        private void AddMainNav(ref StringBuilder urls, HttpContext context)
        {
            var config = (FatConfigSection)ConfigurationManager.GetSection("fatConfig");
            var mainNavStartNode = config.MainNavigationStartNodeId;

            if (mainNavStartNode <= 0) return;

            var startNode = new Node(mainNavStartNode);

            foreach (var linkItem in startNode.ChildrenAsList
                    .Select(node => 
                        ContentHelper.GetByNodeId<LinkItem>(node.Id))
                        .Where(linkItem => !linkItem.IsExternalLink))
            {
                urls.AppendFormat(@"<url>
<loc>http://{0}{1}</loc>
<lastmod>{2}</lastmod>
<changefreq>monthly</changefreq>
</url>",
       context.Request.ServerVariables["HTTP_HOST"],
       linkItem.EffectiveUrl, linkItem.UpdateDate.ToString("yyyy-MM-dd"));
            }
        }

        public bool IsReusable { get { return true; } }
    }
}