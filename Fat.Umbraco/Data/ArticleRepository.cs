using Fat.Umbraco.ViewModels;
using System;
using System.Linq;
using umbraco.MacroEngines;
using umbraco.cms.businesslogic.media;

namespace Fat.Umbraco.Data
{
    public static class ArticleRepository
    {
        public static BlogPost Get(DynamicNodeContext nodeContex)
        {
            // TODO:
            return GetEmptyPost();
        }

        public static BlogPost GetLatest(DynamicNodeContext nodeContext)
        {

            var post = nodeContext.Current.XPath("//HomePage/uBlogsyLanding/descendant::uBlogsyPost")
               .Items.OrderByDescending(item => DateTime.Parse(item.GetPropertyValue("uBlogsyPostDate")))
               .FirstOrDefault();

            return post != null
                       ? MapToBlogPost(post)
                       : GetEmptyPost();
        }

        private static BlogPost GetEmptyPost()
        {
            return new BlogPost
                {
                    Author = "",
                    Content = "Sorry, nothing found",
                    Title = "Sorry, nothing found",
                    Summary = "Sorry, nothing found",
                    Date = DateTime.UtcNow.ToString("dd MMM yyyy")
                };
        }

        private static BlogPost MapToBlogPost(DynamicNode post)
        {
            return new BlogPost
                {
                    Author = GetAuthor(post.GetPropertyValue("uBlogsyPostAuthor")),
                    Date = DateTime.Parse(post.GetPropertyValue("uBlogsyPostDate", DateTime.UtcNow.ToString("dd MMM yyyy"))).ToString("dd MMM yyyy"),
                    Title = post.GetPropertyValue("uBlogsyContentTitle", "Sorry, nothing found"),
                    Summary = post.GetPropertyValue("uBlogsyContentSummary", "Sorry, nothing found"),
                    Content = post.GetPropertyValue("uBlogsyContentBody", "Sorry, nothing found"),
                    Image = GetImageUrl(post.GetPropertyValue("uBlogsyPostImage"))
                };
        }

        private static string GetAuthor(string nodeId)
        {
            // TODO:
            return "Ben";
        }

        private static string GetImageUrl(string nodeId)
        {
            int id;
            int.TryParse(nodeId, out id);

            return id <= 0
                       ? string.Empty
                       : new Media(id).getProperty("umbracoFile").Value.ToString();
        }
    }
}
