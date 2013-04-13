using System;
using System.Configuration;
using System.Linq;
using System.Web;
using umbraco.MacroEngines;

namespace Fat.Umbraco
{
    public static class HtmlHelper
    {
        private static volatile FatConfigSection _config;
        private readonly static object ConfigLock = new object();

        static HtmlHelper()
        {
            if (_config == null)
            {
                lock (ConfigLock)
                    if (_config == null)
                        _config = (FatConfigSection)ConfigurationManager.GetSection("fatConfig");
            }
        }

        public static string RenderHomeNodeActiveClass(int nodeId)
        {
            return _config.HomeNodeId == nodeId ?  "active" : "";
        }

        public static string GetPropertyWithFallbacks(this DynamicNode item, bool lastFallbackAsItemName, params string[] properties)
        {
            if (properties.Length == 0)
            {
                return lastFallbackAsItemName ? item.Name : string.Empty;
            }

            var propertyName = properties[0];
            var propertyValue = item.GetPropertyValue(propertyName);

            if (!String.IsNullOrEmpty(propertyValue))
            {
                return propertyValue;
            }

            var remainingProperties = properties.Where((property, index) => index > 0).ToArray();
            return item.GetPropertyWithFallbacks(lastFallbackAsItemName, remainingProperties);
        }

        public static string GetResolvedLinkUrl(this DynamicNode item, string internalLinkPropertyName, string externalLinkPropertyName)
        {
            var externalLink = item.GetPropertyValue(externalLinkPropertyName);
            var internalLink = item.GetPropertyValue(internalLinkPropertyName);
            var url = string.Empty;

            if (!string.IsNullOrWhiteSpace(externalLink))
            {
                url = externalLink;
            }
            else if (!string.IsNullOrWhiteSpace(internalLink))
            {
                var internalItem = item.NodeById(internalLink);
                url = internalItem.NiceUrl;
            }

            return url;
        }

        public static string GetMediaUrl(this DynamicNode item, DynamicNodeContext context, string mediaPropertyName)
        {
            var mediaItemId = item.GetPropertyValue(mediaPropertyName);

            return string.IsNullOrEmpty(mediaItemId) ? 
                string.Empty : 
                context.Library.MediaById(mediaItemId).NiceUrl;
        }

        public static IHtmlString AsHtmlString(this string instance)
        {
            return new HtmlString(instance);
        }

        public static string AsString(this bool instance, string trueString, string falseString)
        {
            return instance ? trueString : falseString;
        }
    }
}