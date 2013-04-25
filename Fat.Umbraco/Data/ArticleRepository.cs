using Fat.Umbraco.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uHelpsy.Helpers;
using umbraco.MacroEngines;
using Media = umbraco.cms.businesslogic.media.Media;

namespace Fat.Umbraco.Data
{
    public static class ArticleRepository
    {
        public static BlogPost Get(DynamicNodeContext nodeContext, int postId = -1)
        {
            if (postId == -1)
            {
                postId = GetBlogPostId();
            }

            if (postId <= 0)
            {
                return GetEmptyPost();
            }

            var post = new DynamicNode(postId);

            return MapToBlogPost(post);
        }

        public static IEnumerable<BlogPost> GetByTag(DynamicNodeContext nodeContext, string tag = "")
        {
            if (string.IsNullOrEmpty(tag))
            {
                tag = GetTag();
            }

            if (string.IsNullOrEmpty(tag))
            {
                return Enumerable.Empty<BlogPost>();
            }

            int count;
            var results = uBlogsy.BusinessLogic.PostService.Instance.GetPosts(IPublishedContentHelper.GetNode(1128),
                tag, "", "", "", "", "",
                "", "", out count);

            return results.Select(searchResult => new BlogPost
                {
                    Author = GetAuthor(searchResult.Fields["uBlogsyPostAuthor"]),
                    Date = DateTime.Parse(searchResult.Fields["uBlogsyPostDate"]).ToString("dd MMM yyyy"),
                    Image = GetImageUrl(searchResult.Fields["uBlogsyPostImage"]),
                    Title = searchResult.Fields["uBlogsyContentTitle"], 
                    Summary = searchResult.Fields["uBlogsyContentSummary"], 
                    Content = searchResult.Fields["uBlogsyContentBody"]
                }).ToList();
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

        private static int GetBlogPostId()
        {
            int id;
            int.TryParse(HttpContext.Current.Request.QueryString["post"], out id);
            return id;
        }

        private static string GetTag()
        {
            return HttpContext.Current.Request.QueryString["tag"];
        }
    }
}
