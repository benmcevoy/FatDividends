using Fat.Umbraco.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uBlogsy.BusinessLogic;
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

        public static IEnumerable<BlogPost> GetByTag(DynamicNodeContext nodeContext, string tag = "", int count = 10)
        {
            if (string.IsNullOrEmpty(tag))
            {
                tag = GetTag();
            }

            if (string.IsNullOrEmpty(tag))
            {
                return Enumerable.Empty<BlogPost>();
            }

            int resultCount;
            var results = PostService.Instance.GetPosts(IPublishedContentHelper.GetNode(1128),
                tag, "", "", "", "", "",
                "", "", out resultCount);

            return results
                .OrderByDescending(searchResult => DateTime.Parse(searchResult.Fields["uBlogsyPostDate"]))
                .Select(searchResult => new BlogPost
                {
                    Id = searchResult.Id,
                    Author = GetAuthor(searchResult.GetLuceneField("uBlogsyPostAuthor")),
                    Date = DateTime.Parse(searchResult.GetLuceneField("uBlogsyPostDate")).ToString("dd MMM yyyy"),
                    Image = GetImageUrl(searchResult.GetLuceneField("uBlogsyPostImage")),
                    Title = searchResult.GetLuceneField("uBlogsyContentTitle").Wikify(),
                    Summary = searchResult.GetLuceneField("uBlogsyContentSummary").Wikify(),
                    Content = searchResult.GetLuceneField("uBlogsyContentBody").Wikify()
                }).Take(count).ToList();
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
                    Id = -1,
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
                    Id = post.Id,
                    Author = GetAuthor(post.GetPropertyValue("uBlogsyPostAuthor")),
                    Date = DateTime.Parse(post.GetPropertyValue("uBlogsyPostDate", DateTime.UtcNow.ToString("dd MMM yyyy"))).ToString("dd MMM yyyy"),
                    Title = post.GetPropertyValue("uBlogsyContentTitle", "Sorry, nothing found").Wikify(),
                    Summary = post.GetPropertyValue("uBlogsyContentSummary", "Sorry, nothing found").Wikify(),
                    Content = post.GetPropertyValue("uBlogsyContentBody", "Sorry, nothing found").Wikify(),
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
