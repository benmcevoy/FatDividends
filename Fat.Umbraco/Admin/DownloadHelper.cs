using System.Linq;
using System.Web;

namespace Fat.Umbraco.Admin
{
    public static class DownloadHelper
    {
        public static void DownloadAsCsv<T>(HttpContext httpContext, IQueryable<T> query, string fileName, int pageSize = 500) where T : class
        {
            var pageNumber = 0;

            while (true)
            {
                var results = query.Skip(pageSize * pageNumber).Take(pageSize);

                if (!results.Any()) break;

                var csv = results.ToCsv();

                if (pageNumber == 0)
                {
                    var properties = typeof(T).GetProperties();
                    var header = properties.Aggregate("", (current, propertyInfo) => current + string.Format("{0},", propertyInfo.Name));

                    header = header.TrimEnd(',');
                    header += "\r\n";

                    csv = csv.Insert(0, header);

                    httpContext.Response.Clear();
                    httpContext.Response.AddHeader("Content-Disposition",
                                                   "attachment; filename='" + fileName + "'");
                    httpContext.Response.ContentType = "text/comma-separated-values";
                }

                pageNumber++;

                httpContext.Response.Write(csv);
                httpContext.Response.Flush();
            }

            httpContext.Response.End();
        }
    }
}