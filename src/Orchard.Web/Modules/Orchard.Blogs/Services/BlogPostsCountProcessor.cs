using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Blogs.Models;
using Orchard.Core.Common.Models;

namespace Orchard.Blogs.Services {
    public class BlogPostsCountProcessor : IBlogPostsCountProcessor {
        private readonly IContentManager _contentManager;
        public BlogPostsCountProcessor(
            IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public void Process(int blogPartId) {
            var blogPart = _contentManager.Get<BlogPart>(blogPartId);
            if (blogPart != null) {
                var count = _contentManager.Query(VersionOptions.Published, "BlogPost")
                    .Join<CommonPartRecord>().Where(
                        cr => cr.Container.Id == blogPartId)
                    .Count();
                blogPart.PostCount = count;
            }
    }
}
