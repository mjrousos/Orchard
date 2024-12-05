using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Blogs.Models;

namespace Orchard.Blogs.Services {
    public interface IBlogService : IDependency {
        BlogPart Get(string path);
        ContentItem Get(int id, VersionOptions versionOptions);
        IEnumerable<BlogPart> Get();
        IEnumerable<BlogPart> Get(VersionOptions versionOptions);
        void Delete(ContentItem blog);
        void ProcessBlogPostsCount(int blogPartId);
    }
}
