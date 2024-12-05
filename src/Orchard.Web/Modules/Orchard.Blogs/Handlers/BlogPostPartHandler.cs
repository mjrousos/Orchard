using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Linq;
using System.Web.Routing;
using Orchard.Blogs.Models;
using Orchard.Blogs.Services;
using Orchard.ContentManagement.Handlers;
using Orchard.Core.Common.Models;

namespace Orchard.Blogs.Handlers {
    public class BlogPostPartHandler : ContentHandler {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBlogService _blogService;
        private readonly IWorkContextAccessor _workContextAccessor;
        public BlogPostPartHandler(IAuthorizationService authorizationService, IBlogService blogService, IBlogPostService blogPostService, RequestContext requestContext, IWorkContextAccessor workContextAccessor) {
            _authorizationService = authorizationService;
            _blogService = blogService;
            _workContextAccessor = workContextAccessor;
            OnGetDisplayShape<BlogPostPart>(SetModelProperties);
            OnGetEditorShape<BlogPostPart>(SetModelProperties);
            OnUpdateEditorShape<BlogPostPart>(SetModelProperties);
            OnCreated<BlogPostPart>((context, part) => ProcessBlogPostsCount(part));
            OnPublished<BlogPostPart>((context, part) => ProcessBlogPostsCount(part));
            OnUnpublished<BlogPostPart>((context, part) => ProcessBlogPostsCount(part));
            OnVersioned<BlogPostPart>((context, part, newVersionPart) => ProcessBlogPostsCount(newVersionPart));
            OnRemoved<BlogPostPart>((context, part) => ProcessBlogPostsCount(part));
            OnRemoved<BlogPart>(
                (context, b) =>
                blogPostService.Get(context.ContentItem.As<BlogPart>()).ToList().ForEach(
                    blogPost => context.ContentManager.Remove(blogPost.ContentItem)));
        }
        private void ProcessBlogPostsCount(BlogPostPart blogPostPart) {
            CommonPart commonPart = blogPostPart.As<CommonPart>();
            if (commonPart != null &&
                commonPart.Record.Container != null) {
                _blogService.ProcessBlogPostsCount(commonPart.Container.Id);
            }
        private static void SetModelProperties(BuildShapeContext context, BlogPostPart blogPost) {
            context.Shape.Blog = blogPost.BlogPart;
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var blogPost = context.ContentItem.As<BlogPostPart>();
            if (blogPost == null) {
                return;
            int blogId = 0;
            // BlogPart can be null if this is a new Blog Post item.
            if (blogPost.BlogPart == null) {
                var blogs = _blogService.Get().Where(x => _authorizationService.TryCheckAccess(Permissions.MetaListBlogs, _workContextAccessor.GetContext().CurrentUser, x)).ToArray();
                if (blogs.Count() == 1) {
                    var singleBlog = blogs.ElementAt(0);
                    if (singleBlog != null) blogId = singleBlog.Id;
                }
            } else {
                blogId = blogPost.BlogPart.Id;
            if (blogId == 0) {
                context.Metadata.CreateRouteValues = new RouteValueDictionary {
                    {"Area", "Orchard.Blogs"},
                    {"Controller", "BlogPostAdmin"},
                    {"Action", "CreateWithoutBlog"}
                };
            context.Metadata.CreateRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Blogs"},
                {"Controller", "BlogPostAdmin"},
                {"Action", "Create"},
                {"blogId", blogId}
            };
            context.Metadata.EditorRouteValues = new RouteValueDictionary {
                {"Action", "Edit"},
                {"postId", context.ContentItem.Id},
            context.Metadata.RemoveRouteValues = new RouteValueDictionary {
                {"Action", "Delete"},
    }
}
