using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web.Routing;
using Orchard.Blogs.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Orchard.Blogs.Handlers {
    public class BlogPartHandler : ContentHandler {
        public BlogPartHandler() {
            OnGetDisplayShape<BlogPart>((context, blog) => {
                context.Shape.Description = blog.Description;
                context.Shape.PostCount = blog.PostCount;
            });
        }
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var blog = context.ContentItem.As<BlogPart>();
            if (blog == null)
                return;
            context.Metadata.DisplayRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Blogs"},
                {"Controller", "Blog"},
                {"Action", "Item"},
                {"blogId", context.ContentItem.Id}
            };
            context.Metadata.CreateRouteValues = new RouteValueDictionary {
                {"Controller", "BlogAdmin"},
                {"Action", "Create"}
            context.Metadata.EditorRouteValues = new RouteValueDictionary {
                {"Action", "Edit"},
            context.Metadata.RemoveRouteValues = new RouteValueDictionary {
                {"Action", "Remove"},
            context.Metadata.AdminRouteValues = new RouteValueDictionary {
    }
}
