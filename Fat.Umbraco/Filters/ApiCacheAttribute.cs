using System.Web.Http.Filters;

namespace Fat.Umbraco.Filters
{
    public class ApiCacheAttribute : ActionFilterAttribute
    {
        private readonly int _cacheDurationSeconds;

        public ApiCacheAttribute(int seconds = 0)
        {
            _cacheDurationSeconds = seconds;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // TODO: would need vary-by-param or something
            // all users are getting the same cached response
            // but there is only one user at the moment...
            actionExecutedContext.Response.Headers.Add("Cache-Control", "public, max-age=" + _cacheDurationSeconds );
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}