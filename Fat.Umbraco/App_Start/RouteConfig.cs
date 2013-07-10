using System.Linq;
using System.Web.Http;
using System.Web.Routing;
using Fat.Umbraco.App_Start;

[assembly: System.Web.PreApplicationStartMethod(typeof(RouteConfig), "PreStart")]
namespace Fat.Umbraco.App_Start
{
    public class RouteConfig
    {
        public static void PreStart()
        {
            RouteTable.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            
            RouteTable.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            var appXmlType = GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}